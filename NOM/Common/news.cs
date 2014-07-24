using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 地图2.Common
{

    //enum locat 
    //#region 省份枚举
    //{ anhui,aomen,beijing,chongqing,fujian,gansu,guangdong,guangxi,guizhou,hainan,hebei,heilongjiang,henan,hubei,hunan,jiangsu,jiangxi,jilin,liaoning,neimeng,ningxia,qinghai,shaanxi,shandong,shanghai,shanxi,sichuan,taiwan,tianjin,xianggang,xinjiang,xizang,yunnan,zhejiang}
//    dictionary<string,string>={ "beijing","http://news.baidu.com/n?cmd=7&loc=0&name=%B1%B1%BE%A9&tn=rss",
//"shanghai","http://news.baidu.com/n?cmd=7&loc=2354&name=%C9%CF%BA%A3&tn=rss",
//"tianjin","http://news.baidu.com/n?cmd=7&loc=125&name=%CC%EC%BD%F2&tn=rss",
//"chongqing",http://news.baidu.com/n?cmd=7&loc=6425&name=%D6%D8%C7%EC&tn=rss",
//"hebei","http://news.baidu.com/n?cmd=7&loc=250&name=%BA%D3%B1%B1&tn=rss",
//"liaoning","http://news.baidu.com/n?cmd=7&loc=1481&name=%C1%C9%C4%FE&tn=rss",
//"jilin","http://news.baidu.com/n?cmd=7&loc=1783&name=%BC%AA%C1%D6&tn=rss",
//"heilongjiang","http://news.baidu.com/n?cmd=7&loc=1967&name=%BA%DA%C1%FA%BD%AD&tn=rss",
//"shanxi","http://news.baidu.com/n?cmd=7&loc=812&name=%C9%BD%CE%F7&tn=rss",
//"sichuan","http://news.baidu.com/n?cmd=7&loc=6692&name=%CB%C4%B4%A8&tn=rss",
//"gansu","http://news.baidu.com/n?cmd=7&loc=8534&name=%B8%CA%CB%E0&tn=rss",
//"shaanxi","http://news.baidu.com/n?cmd=7&loc=8205&name=%C9%C2%CE%F7&tn=rss",
//"henan","http://news.baidu.com/n?cmd=7&loc=4371&name=%BA%D3%C4%CF&tn=rss",
//"shandong","http://news.baidu.com/n?cmd=7&loc=3996&name=%C9%BD%B6%AB&tn=rss",
//"hunan","http://news.baidu.com/n?cmd=7&loc=5161&name=%BA%FE%C4%CF&tn=rss",
//"hubei","http://news.baidu.com/n?cmd=7&loc=4811&name=%BA%FE%B1%B1&tn=rss",
//"jiangxi","http://news.baidu.com/n?cmd=7&loc=3636&name=%BD%AD%CE%F7&tn=rss",
//"jiangsu","http://news.baidu.com/n?cmd=7&loc=2493&name=%BD%AD%CB%D5&tn=rss",
//"zhejiang","http://news.baidu.com/n?cmd=7&loc=2809&name=%D5%E3%BD%AD&tn=rss",
//"anhui","http://news.baidu.com/n?cmd=7&loc=3072&name=%B0%B2%BB%D5&tn=rss",
//"fujian","http://news.baidu.com/n?cmd=7&loc=3372&name=%B8%A3%BD%A8&tn=rss",
//"guangdong","http://news.baidu.com/n?cmd=7&loc=5495&name=%B9%E3%B6%AB&tn=rss",
//"guangxi","http://news.baidu.com/n?cmd=7&loc=5886&name=%B9%E3%CE%F7&tn=rss",
//"guizhou","http://news.baidu.com/n?cmd=7&loc=7230&name=%B9%F3%D6%DD&tn=rss",
//"yunnan","http://news.baidu.com/n?cmd=7&loc=7527&name=%D4%C6%C4%CF&tn=rss",
//"neimeng","http://news.baidu.com/n?cmd=7&loc=1167&name=%C4%DA%C3%C9%B9%C5&tn=rss",
//"qinghai","http://news.baidu.com/n?cmd=7&loc=8782&name=%C7%E0%BA%A3&tn=rss",
//"ningxia","http://news.baidu.com/n?cmd=7&loc=8907&name=%C4%FE%CF%C4&tn=rss",
//"xinjiang","http://news.baidu.com/n?cmd=7&loc=9001&name=%D0%C2%BD%AE&tn=rss",
//"xizang","http://news.baidu.com/n?cmd=7&loc=7915&name=%CE%F7%B2%D8&tn=rss",
//"xianggang","http://news.baidu.com/n?cmd=7&loc=9337&name=%CF%E3%B8%DB&tn=rss",
//"aomen","http://news.baidu.com/n?cmd=7&loc=9436&name=%B0%C4%C3%C5&tn=rss",
//"taiwan","http://news.baidu.com/n?cmd=7&loc=9442&name=%CC%A8%CD%E5&tn=rss"}
    //#endregion
    public class News
    {

        string title;
        string link;
        string description;
        string pubdate;
        string source;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Link
        {
            get { return link; }
            set { link = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Pubdate
        {
            get { return pubdate; }
            set { pubdate = value; }
        }

        public string Source
        {
            get { return source; }
            set { source = value; }
        }
    }
}

