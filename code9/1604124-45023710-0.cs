    using Microsoft.Maps.MapControl;
    using Microsoft.Maps.MapControl.Core;
    using System;
    
    namespace MR.CommandBridge.VEMap.MapExtensions
    {
        public class TrafficTileSource : TileSource
        {
            public TrafficTileSource()
                : base("http://t0.tiles.virtualearth.net/tiles/t{0}.png?time={1}")
            {
            }
    
            public override Uri GetUri(int x, int y, int zoomLevel)
            {
                var quadKey = new QuadKey(x, y, zoomLevel);
                return new Uri(String.Format(this.UriFormat, quadKey.Key, DateTime.Now.Ticks));
            }
         }
     }
