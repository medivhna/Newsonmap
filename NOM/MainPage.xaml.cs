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
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
using Windows.Data.Json;
using 地图2.Common;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;

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

            map.Zoom = 4;
            map.Center = new Com.AMap.Maps.Api.BaseTypes.ALngLat(108, 34);
            map.ZoomEnded += map_ZoomEnded;

            #region AddDistinct
            distinct.Add("北京市", 1); distinct.Add("上海市", 0); distinct.Add("天津市", 0); distinct.Add("重庆", 0); distinct.Add("河北", 0); distinct.Add("辽宁", 0); distinct.Add("吉林", 0); distinct.Add("黑龙江", 0); distinct.Add("山西", 0); distinct.Add("四川", 0); distinct.Add("甘肃", 0); distinct.Add("陕西", 2); distinct.Add("河南", 0); distinct.Add("山东", 3); distinct.Add("湖南", 0); distinct.Add("湖北", 0); distinct.Add("江西", 0); distinct.Add("江苏", 0); distinct.Add("浙江", 0); distinct.Add("安徽", 0); distinct.Add("福建", 0); distinct.Add("广东", 0); distinct.Add("广西", 0); distinct.Add("贵州", 0); distinct.Add("云南", 0); distinct.Add("内蒙古", 0); distinct.Add("青海", 0); distinct.Add("海南", 0); distinct.Add("宁夏", 0); distinct.Add("新疆", 0); distinct.Add("西藏", 0); distinct.Add("香港", 0); distinct.Add("澳门", 0); distinct.Add("台湾", 0);
            #endregion
        }

        private void map_ZoomEnded(object sender, RoutedEventArgs e)
        {
            if (map.Zoom >= 5)
                map.Zoom = 5;
            if (map.Zoom <= 4)
                map.Zoom = 4;
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
        Dictionary<string, int> distinct = new Dictionary<string, int>();

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

        }


        public class Item
        {
            public string Id { get; set; }

            [JsonProperty(PropertyName = "text")]
            public string Text { get; set; }

            [JsonProperty(PropertyName = "complete")]
            public bool Complete { get; set; }
        }

        // 为地图右键设置预留方法
        private void map_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            lv1.Visibility = Visibility.Collapsed;
            img1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            grid1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }


        ALngLat picked;
        int locatId = 0;
        List<News> data = new List<News>();
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

                string peopleJsonPath = "http://newsonmap.chinacloudsites.cn/getNewsPage?page=" + "0" + "&maxNums=" + "5" + "&typeId=" + (locatId.ToString()) + "&pic=" + "true" + "";

                JsonSerializer json = new JsonSerializer();
                json.NullValueHandling = NullValueHandling.Ignore;
                json.ObjectCreationHandling = ObjectCreationHandling.Replace;
                json.MissingMemberHandling = MissingMemberHandling.Ignore;
                json.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                WebRequest request = WebRequest.Create(peopleJsonPath);
                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string t1, t2;
                string responseFromServer = reader.ReadToEnd();
                t1=responseFromServer.Replace("{\"posts\":", "");
                t2=t1.Replace(",\"page\":0}", "");
                data = JsonConvert.DeserializeObject<List<News>>(t2);

                if (data.Count == 0)
                {
                    MessageDialog msg = new MessageDialog("暂无新闻，目前只支持北京山东陕西三地的新闻浏览");
                    await msg.ShowAsync();
                }
                else
                    lv1.ItemsSource = data;

            }
            else
            {
                MessageDialog msg = new MessageDialog("无法读取地点，请尝试选取邻近地点");
                await msg.ShowAsync();
            }
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

        // 点击listview
        News selected = new News();
        public static News show = new News();
        private async void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            selected = e.ClickedItem as News;
            string peopleJsonPath = "http://newsonmap.chinacloudsites.cn/newsRecord?userId="+"liux"+"&id="+selected._Id+"&jsonData="+"true";
            JsonSerializer json = new JsonSerializer();
            json.NullValueHandling = NullValueHandling.Ignore;
            json.ObjectCreationHandling = ObjectCreationHandling.Replace;
            json.MissingMemberHandling = MissingMemberHandling.Ignore;
            json.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            WebRequest request = WebRequest.Create(peopleJsonPath);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            show = (News)JsonConvert.DeserializeObject(responseFromServer, typeof(News));
            Frame.Navigate(typeof(newpage1));
        }


    }



}

