using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.AMap.Maps;
using Com.AMap.Maps.Api;
using Com.AMap.Maps.Api.BaseTypes;
using Com.AMap.Maps.Api.Overlays;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;

namespace 地图2.Common
{

    public class News
    {
        string _id;
        public string _Id
        {
            get { return _id; }
            set { _id = value; }
        }

        string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        int typeId;
        public int TypeId
        {
            get { return typeId; }
            set { typeId = value; }
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



        string content;
        public string Content
        {
            get { return content; }
            set { content = value; }
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

        public override string ToString()
        {
            return this.Title;
        }
        
    }
}

