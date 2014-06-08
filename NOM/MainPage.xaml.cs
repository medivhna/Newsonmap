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
        public static News selected;
        Dictionary<string, string> Website = new System.Collections.Generic.Dictionary<string, string>();
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
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //await Authenticate();

            map.SetZoomLevel(1.0);

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
        }

        public class Item
        {
            public string Id { get; set; }

            [JsonProperty(PropertyName = "text")]
            public string Text { get; set; }

            [JsonProperty(PropertyName = "complete")]
            public bool Complete { get; set; }
        }
        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            selected = e.ClickedItem as News;
            Frame.Navigate(typeof(newpage1));
        }

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


    }
}
