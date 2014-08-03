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
        List<string> distinct = new List<string>();

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
            Com.AMap.Maps.Api.AMapConfig.Key = "b746eb6d990e1c31daa6c5c64aeb41f4";

            map.Zoom = 4;
            map.Center = new Com.AMap.Maps.Api.BaseTypes.ALngLat(108, 34);

            #region AddDistinct
            distinct.Add("北京"); distinct.Add("上海"); distinct.Add("天津"); distinct.Add("重庆"); distinct.Add("河北"); distinct.Add("辽宁"); distinct.Add("吉林"); distinct.Add("黑龙江"); distinct.Add("山西"); distinct.Add("四川"); distinct.Add("甘肃"); distinct.Add("陕西"); distinct.Add("河南"); distinct.Add("山东"); distinct.Add("湖南"); distinct.Add("湖北"); distinct.Add("江西"); distinct.Add("江苏"); distinct.Add("浙江"); distinct.Add("安徽"); distinct.Add("福建"); distinct.Add("广东"); distinct.Add("广西"); distinct.Add("贵州"); distinct.Add("云南"); distinct.Add("内蒙古"); distinct.Add("青海"); distinct.Add("海南"); distinct.Add("宁夏"); distinct.Add("新疆"); distinct.Add("西藏"); distinct.Add("香港"); distinct.Add("澳门"); distinct.Add("台湾");
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
        string locat = null;
        List<News> select = new List<News>();
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

            if (rgcs.Erro == null && rgcs.resultList != null&&false)
            {
                IEnumerable<ReverseGeocodingInfo> reverseGeocodeResult = rgcs.resultList;
                List<string> localPosition = new List<string>();
                foreach (ReverseGeocodingInfo r in reverseGeocodeResult)
                {
                    localPosition.Add(r.ToString());
                    break;
                }
                string[] tmp = localPosition.ToArray();
                locat = search(tmp[0]);  // 只查找第一个地址的省份信息，准确度待考量
                Predicate<News> match = findAll;
                select = news.FindAll(match);
                lv1.DataContext = select;

            }
            else
            {
                //img1.Visibility = Visibility.Collapsed;
                //grid1.Visibility = Visibility.Collapsed;
                //lv1.Visibility = Visibility.Collapsed;
            }
        }

        // 用于查找判断的函数
        private bool findAll(News obj)
        {
            return obj.Local == locat;
        }
        // searching
        private string search(string s)
        {
            foreach (string a in distinct)
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

