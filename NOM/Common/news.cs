using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.AMap.Maps;
using Com.AMap.Maps.Api;
using Com.AMap.Maps.Api.BaseTypes;
using Com.AMap.Maps.Api.Overlays;
namespace 地图2.Common
{
    public class News
    {

        string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        string pubDate;
        public string Pubdate
        {
            get { return pubDate; }
            set { pubDate = value; }
        }

        bool isImg;
        public bool IsImg
        {
            get { return isImg; }
            set { isImg = value; }
        }

        string imgPath;
        public string ImgPath
        {
            get { return imgPath; }
            set { imgPath = value; }
        }

        int typeId;
        public int TypeId
        {
            get { return typeId; }
            set { typeId = value; }
        }

        string context;
        public string Context
        {
            get { return context; }
            set { context = value; }
        }

        int page;
        public int Page
        {
            get { return page; }
            set { page = value; }
        }

        string descimg;
        public string Descimg
        {
            get { return descimg; }
            set { descimg = value; }
        }


        public News()
        {

        }


        
    }
}

