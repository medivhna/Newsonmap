using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using Newtonsoft.Json;
using System.Xml.Linq;
using Windows.ApplicationModel;
using Com.AMap.Maps.Api;
<<<<<<< HEAD
using Com.AMap.Maps.Api.Layers;
using Com.AMap.Maps.Api.BaseTypes;
using Com.AMap.Maps.Api.Overlays;
using Com.AMap.Maps.Api.Events;
using Com.AMap.Search.API.Options;
using Com.AMap.Search.API.Result;
using Com.AMap.Search.API;
// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍
=======
using Com.AMap.Maps.Api.Overlays;
>>>>>>> ad969a6ce7a8762ad58dc0308d8f4108470085cb


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
<<<<<<< HEAD

        }

=======
        }


>>>>>>> ad969a6ce7a8762ad58dc0308d8f4108470085cb
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
<<<<<<< HEAD

        #region Will be deleted
        //public static News selected;
        //Dictionary<string, string> Website = new System.Collections.Generic.Dictionary<string, string>();
        #endregion

        // 通用项目定义
        List<News> news = new List<News>();
        List<string> distinct = new List<string>();
        
        

=======
        public static News selected;
        Dictionary<string, string> Website = new System.Collections.Generic.Dictionary<string, string>();
>>>>>>> ad969a6ce7a8762ad58dc0308d8f4108470085cb
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
        protected override /*async*/ void OnNavigatedTo(NavigationEventArgs e)
        {
            //await Authenticate();
            Com.AMap.Maps.Api.AMapConfig.Key = "b746eb6d990e1c31daa6c5c64aeb41f4";

            map.Zoom = 4;
            map.Center = new Com.AMap.Maps.Api.BaseTypes.ALngLat(108, 34);
<<<<<<< HEAD

            #region AddDistinct
            distinct.Add("北京"); distinct.Add("上海"); distinct.Add("天津"); distinct.Add("重庆"); distinct.Add("河北"); distinct.Add("辽宁"); distinct.Add("吉林"); distinct.Add("黑龙江"); distinct.Add("山西"); distinct.Add("四川"); distinct.Add("甘肃"); distinct.Add("陕西"); distinct.Add("河南"); distinct.Add("山东"); distinct.Add("湖南"); distinct.Add("湖北"); distinct.Add("江西"); distinct.Add("江苏"); distinct.Add("浙江"); distinct.Add("安徽"); distinct.Add("福建"); distinct.Add("广东"); distinct.Add("广西"); distinct.Add("贵州"); distinct.Add("云南"); distinct.Add("内蒙古"); distinct.Add("青海"); distinct.Add("海南"); distinct.Add("宁夏"); distinct.Add("新疆"); distinct.Add("西藏"); distinct.Add("香港"); distinct.Add("澳门"); distinct.Add("台湾");
=======
            AMarker dot = new AMarker(new Com.AMap.Maps.Api.BaseTypes.ALngLat(108, 34));
            map.Children.Add(dot);
            dot.Tapped += new TappedEventHandler(this.dot_tapped);


            #region Add Websites
            Website.Add("beijing", "http://news.baidu.com/n?cmd=7&loc=0&name=%B1%B1%BE%A9&tn=rss"); 
            Website.Add("shanghai", "http://news.baidu.com/n?cmd=7&loc=2354&name=%C9%CF%BA%A3&tn=rss"); 
            Website.Add("tianjin", "http://news.baidu.com/n?cmd=7&loc=125&name=%CC%EC%BD%F2&tn=rss");
            Website.Add("chongqing", "http://news.baidu.com/n?cmd=7&loc=6425&name=%D6%D8%C7%EC&tn=rss");
            Website.Add("hebei", "http://news.baidu.com/n?cmd=7&loc=250&name=%BA%D3%B1%B1&tn=rss"); 
            Website.Add("liaoning", "http://news.baidu.com/n?cmd=7&loc=1481&name=%C1%C9%C4%FE&tn=rss");
            Website.Add("jilin", "http://news.baidu.com/n?cmd=7&loc=1783&name=%BC%AA%C1%D6&tn=rss"); 
            Website.Add("heilongjiang", "http://news.baidu.com/n?cmd=7&loc=1967&name=%BA%DA%C1%FA%BD%AD&tn=rss");
            Website.Add("shanxi", "http://news.baidu.com/n?cmd=7&loc=812&name=%C9%BD%CE%F7&tn=rss");
            Website.Add("sichuan", "http://news.baidu.com/n?cmd=7&loc=6692&name=%CB%C4%B4%A8&tn=rss");
            Website.Add("gansu", "http://news.baidu.com/n?cmd=7&loc=8534&name=%B8%CA%CB%E0&tn=rss");
            Website.Add("shaanxi", "http://news.baidu.com/n?cmd=7&loc=8205&name=%C9%C2%CE%F7&tn=rss");
            Website.Add("henan", "http://news.baidu.com/n?cmd=7&loc=4371&name=%BA%D3%C4%CF&tn=rss"); 
            Website.Add("shandong", "http://news.baidu.com/n?cmd=7&loc=3996&name=%C9%BD%B6%AB&tn=rss");
            Website.Add("hunan", "http://news.baidu.com/n?cmd=7&loc=5161&name=%BA%FE%C4%CF&tn=rss"); 
            Website.Add("hubei", "http://news.baidu.com/n?cmd=7&loc=4811&name=%BA%FE%B1%B1&tn=rss"); 
            Website.Add("jiangxi", "http://news.baidu.com/n?cmd=7&loc=3636&name=%BD%AD%CE%F7&tn=rss"); 
            Website.Add("jiangsu", "http://news.baidu.com/n?cmd=7&loc=2493&name=%BD%AD%CB%D5&tn=rss");
            Website.Add("zhejiang", "http://news.baidu.com/n?cmd=7&loc=2809&name=%D5%E3%BD%AD&tn=rss"); 
            Website.Add("anhui", "http://news.baidu.com/n?cmd=7&loc=3072&name=%B0%B2%BB%D5&tn=rss"); 
            Website.Add("fujian", "http://news.baidu.com/n?cmd=7&loc=3372&name=%B8%A3%BD%A8&tn=rss");
            Website.Add("guangdong", "http://news.baidu.com/n?cmd=7&loc=5495&name=%B9%E3%B6%AB&tn=rss");
            Website.Add("guangxi", "http://news.baidu.com/n?cmd=7&loc=5886&name=%B9%E3%CE%F7&tn=rss"); 
            Website.Add("guizhou", "http://news.baidu.com/n?cmd=7&loc=7230&name=%B9%F3%D6%DD&tn=rss"); 
            Website.Add("yunnan", "http://news.baidu.com/n?cmd=7&loc=7527&name=%D4%C6%C4%CF&tn=rss"); 
            Website.Add("neimenggu", "http://news.baidu.com/n?cmd=7&loc=1167&name=%C4%DA%C3%C9%B9%C5&tn=rss");
            Website.Add("qinghai", "http://news.baidu.com/n?cmd=7&loc=8782&name=%C7%E0%BA%A3&tn=rss"); 
            Website.Add("ningxia", "http://news.baidu.com/n?cmd=7&loc=8907&name=%C4%FE%CF%C4&tn=rss"); 
            Website.Add("xinjiang", "http://news.baidu.com/n?cmd=7&loc=9001&name=%D0%C2%BD%AE&tn=rss");
            Website.Add("xizang", "http://news.baidu.com/n?cmd=7&loc=7915&name=%CE%F7%B2%D8&tn=rss");
            Website.Add("xianggang", "http://news.baidu.com/n?cmd=7&loc=9337&name=%CF%E3%B8%DB&tn=rss");
            Website.Add("aomen", "http://news.baidu.com/n?cmd=7&loc=9436&name=%B0%C4%C3%C5&tn=rss"); 
            Website.Add("taiwan", "http://news.baidu.com/n?cmd=7&loc=9442&name=%CC%A8%CD%E5&tn=rss");
            Website.Add("hainan","http://news.baidu.com/n?cmd=7&loc=6245&name=%BA%A3%C4%CF&tn=rss");
>>>>>>> ad969a6ce7a8762ad58dc0308d8f4108470085cb
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

<<<<<<< HEAD
        #region Will be replaced
        //// Will be replaced
        //private void Buttons_Clicked(object sender, RoutedEventArgs e)
        //{
        //    Button ClickedButton = (Button)sender;
        //    string peopleXMLPath = Website[ClickedButton.Name];
        //    // test on news of Beijing
        //    XDocument loadedData = XDocument.Load(peopleXMLPath);

        //    var data = from query in loadedData.Descendants("item")
        //               select new News
        //               {
        //                   Title = (string)query.Element("title"),
        //                   Link = (string)query.Element("link"),
        //                   Description = (string)query.Element("description"),
        //                   Pubdate = (string)query.Element("pubDate"),
        //                   Source = (string)query.Element("source"),
        //               };
        //   // lv1.DataContext = data;
        //}
        #endregion

        // 为地图右键设置预留方法，未实现
=======
        // Will be replaced
        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            selected = e.ClickedItem as News;
            Frame.Navigate(typeof(newpage1));
        }

        // Will be replaced
        private void Buttons_Clicked(object sender, RoutedEventArgs e)
        {
            Button ClickedButton = (Button)sender;
            string peopleXMLPath = Website[ClickedButton.Name];
            // test on news of Beijing
            XDocument loadedData = XDocument.Load(peopleXMLPath);

            var data = from query in loadedData.Descendants("item")
                       select new News
                       {
                           Title = (string)query.Element("title"),
                           Link = (string)query.Element("link"),
                           Description = (string)query.Element("description"),
                           Pubdate = (string)query.Element("pubDate"),
                           Source = (string)query.Element("source"),
                       };
           // lv1.DataContext = data;
        }
        
        // 为右键设置预留方法
>>>>>>> ad969a6ce7a8762ad58dc0308d8f4108470085cb
        private void map_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            //lv1.Visibility = Visibility.Collapsed;



        }

<<<<<<< HEAD

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
            map.Children.Add(dot);
            map.Center = picked;
            x[0] = picked.LngX;
            y[0] = picked.LatY;

            ReverseGeocodingOption rgo = new ReverseGeocodingOption();
            rgo.XCoors = x;
            rgo.YCoors = y;

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
                locat = search(tmp[0]);  // 只查找第一个地址的省份信息，准确度待考量
                Predicate<News> match = findAll;
                select = news.FindAll(match);
                //lv1.DataContext = select;
                //lv1.Visibility = Visibility.Visible;
            }
        }
        
        // 用于查找判断的函数
        private bool findAll(News obj)
        {
            return obj.Local == locat;
        }
        // searching
        private string search(string s)
=======
        // 事件处理
        private void dot_tapped(object sender, TappedRoutedEventArgs e)
>>>>>>> ad969a6ce7a8762ad58dc0308d8f4108470085cb
        {
            foreach (string a in distinct)
            {
                if (s.Contains(a))
                    return a;
            }
            return null;
        }

<<<<<<< HEAD
        // 点击listview，等待完成
        //News selected = new News();
        //private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    selected = e.ClickedItem as News;
        //    Frame.Navigate(typeof(newpage1));
        //}
=======
    
} 
        
    
>>>>>>> ad969a6ce7a8762ad58dc0308d8f4108470085cb

    }

