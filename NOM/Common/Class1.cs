using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Com.AMap.Maps;
using Com.AMap.Maps.Api;
using Com.AMap.Maps.Api.Overlays;
using Com.AMap.Maps.Api.BaseTypes;

namespace 地图2.Common
{
    class NewsMark :Windows.UI.Xaml.Controls.Canvas, Com.AMap.Maps.Api.Overlays.IOverlay
    {
        public NewsMark();
        public NewsMark(ALngLat lngLat);

        public int a;

        public ALngLatBounds GetLngLatBounds()
        {
            throw new NotImplementedException();
        }

        public AMap MapInstance
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void ReDraw()
        {
            throw new NotImplementedException();
        }
    }
}
