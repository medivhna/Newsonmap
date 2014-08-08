using Com.AMap.Maps.Api;
using Com.AMap.Maps.Api.BaseTypes;
using Com.AMap.Maps.Api.Events;
using Com.AMap.Maps.Api.Layers;
using Com.AMap.Maps.Api.Overlays;
using Com.AMap.Search.API;
using Com.AMap.Search.API.Options;
using Com.AMap.Search.API.Result;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
using System.Xml.Linq;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using 地图2.Common;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace 地图2
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            map.Tapped += map_Tapped;
            Com.AMap.Maps.Api.AMapConfig.Key = "b746eb6d990e1c31daa6c5c64aeb41f4";
            Com.AMap.Search.API.AMapSearchConfig.Key = "b746eb6d990e1c31daa6c5c64aeb41f4";
        }


        private async void InsertTodoItem(Item item)
        {
            await itemTable.InsertAsync(item);

            items.Add(item);
        }

        private async void RefreshTodoItems()
        {
            items = await itemTable.ToCollectionAsync();
            // <summary>
            // 将控件的信息更新
            // </summary>
        }

        private async void UpdateCheckedTodoItem(Item item)
        {
            await itemTable.UpdateAsync(item);
        }

        // 通用项目定义
        List<News> news = new List<News>();
        Dictionary<string,int> distinct = new Dictionary<string,int>();

        private MobileServiceCollection<Item, Item> items;
        private IMobileServiceTable<Item> itemTable =
            App.MobileService.GetTable<Item>();

        private MobileServiceUser user;
        private async System.Threading.Tasks.Task Authenticate()
        {
            while (user == null)
            {
                string message;
                try
                {
                    user = await App.MobileService
                        .LoginAsync(MobileServiceAuthenticationProvider.MicrosoftAccount);
                    message =
                        string.Format("You are now logged in - {0}", user.UserId);
                }
                catch (InvalidOperationException)
                {
                    message = "You must log in. Login Required";
                }

                var dialog = new MessageDialog(message);
                dialog.Commands.Add(new UICommand("OK"));
                await dialog.ShowAsync();
            }
        }

        // 页面初始化
        protected override /*async*/ void OnNavigatedTo(NavigationEventArgs e)
        {
            //await Authenticate();


            map.Zoom = 4;
            map.Center = new Com.AMap.Maps.Api.BaseTypes.ALngLat(108, 34);

            #region AddDistinct
            distinct.Add("北京市",1); distinct.Add("上海市",0); distinct.Add("天津市",0); distinct.Add("重庆",0); distinct.Add("河北",0); distinct.Add("辽宁",0); distinct.Add("吉林",0); distinct.Add("黑龙江",0); distinct.Add("山西",0); distinct.Add("四川",0); distinct.Add("甘肃",0); distinct.Add("陕西",2); distinct.Add("河南",0); distinct.Add("山东",3); distinct.Add("湖南",0); distinct.Add("湖北",0); distinct.Add("江西",0); distinct.Add("江苏",0); distinct.Add("浙江",0); distinct.Add("安徽",0); distinct.Add("福建",0); distinct.Add("广东",0); distinct.Add("广西",0); distinct.Add("贵州",0); distinct.Add("云南",0); distinct.Add("内蒙古",0); distinct.Add("青海",0); distinct.Add("海南",0); distinct.Add("宁夏",0); distinct.Add("新疆",0); distinct.Add("西藏",0); distinct.Add("香港",0); distinct.Add("澳门",0); distinct.Add("台湾",0);
            #endregion
        }


        public class Item
        {
            public string Id { get; set; }

            [JsonProperty(PropertyName = "text")]
            public string Text { get; set; }

            [JsonProperty(PropertyName = "complete")]
            public bool Complete { get; set; }
        }


        // 为地图右键设置预留方法，未实现
        private void map_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {

        }

        // 点击事件处理
        ALngLat picked;
        int locatId = 0;
        private async void map_Tapped(object sender, TappedRoutedEventArgs e)
        {
            double[] x = new double[1];
            double[] y = new double[1];

            picked = map.FromScreenPixelToLngLat(e.GetPosition(null));
            AMarker dot = new AMarker(picked);
            dot.IconURI = new Uri("//定位.png");
            map.Children.Clear();
            map.Children.Add(dot);
            map.Center = picked;
            x[0] = picked.LngX;
            y[0] = picked.LatY;

            ReverseGeocodingOption rgo = new ReverseGeocodingOption();
            rgo.XCoors = x;
            rgo.YCoors = y;

            lv1.Visibility = Visibility.Visible;
            img1.Visibility = Windows.UI.Xaml.Visibility.Visible;
            grid1.Visibility = Windows.UI.Xaml.Visibility.Visible;
            ReverseGeoCodingResult rgcs = await ReGeoCode.GeoCodeToAddressWithOption(rgo);

            if (rgcs.Erro == null && rgcs.resultList != null)
            {
                IEnumerable<ReverseGeocodingInfo> reverseGeocodeResult = rgcs.resultList;
                List<string> localPosition = new List<string>();
                foreach (ReverseGeocodingInfo r in reverseGeocodeResult)
                {
                    localPosition.Add(r.ToString());
                    break;
                }
                string[] tmp = localPosition.ToArray();

                locatId = distinct[search(tmp[0])];  // 只查找第一个地址的省份信息，准确度待考量
                string peopleXMLPath = "http://newsonmap.chinacloudsites.cn/getNewsPage?page="+"0"+"&maxNums="+"5"+"&typeId="+(locatId.ToString())+"&pic="+"true"+"";
                // test on news of Beijing
                XDocument loadedData = XDocument.Load(peopleXMLPath);

                var data = from query in loadedData.Descendants("item")
                           select new News
                           {
                               Title = (string)query.Element("title"),
                               Pubdate = (string)query.Element("pubDate"),
                               TypeId = (int)query.Element("typeId"),
                               Id = (string)query.Element("_id"),
                               Page = (int)query.Element("page"),
                               Descimg = (string)query.Element("descimg")
                           };

                lv1.DataContext = data;

            }
            else
            {
                img1.Visibility = Visibility.Collapsed;
                grid1.Visibility = Visibility.Collapsed;
                lv1.Visibility = Visibility.Collapsed;
            }
        }

        // 用于查找判断的函数
        private bool findAll(News obj)
        {
            return obj.TypeId == locatId;
        }

        // searching
        private string search(string s)
        {
            foreach (string a in distinct.Keys)
            {
                if (s.Contains(a))
                    return a;
            }
            return null;
        }

         //点击listview，等待完成
        public static News selected = new News();
        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            selected = e.ClickedItem as News;
            Frame.Navigate(typeof(newpage1));
        }

    
} 
        
    

    }

