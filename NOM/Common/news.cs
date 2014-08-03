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
        AMarker dot;
        string local;
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

        public string Local
        {
            get
            {
                return local;
            }
            set
            {
                local = value;
            }
        }

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

        public News()
        {

        }
        public News(AMarker dot)
        {
            this.dot = dot;
        }
    }
}

