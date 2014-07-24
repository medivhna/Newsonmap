using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.AMap.Maps.Api;
using Com.AMap.Maps.Api.BaseTypes;
namespace 地图2.Common
{
    public class News
    {
        string localId;
        string timeId;
        string Id;
        string title;
        bool isImg;
        string imgPath;
        string link;
        string description;
        string pubdate;
        string source;
        ALngLat location;

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

