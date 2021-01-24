    using Microsoft.Maps.MapControl;
    using Microsoft.Maps.MapControl.Core;
    using System;
    
    namespace MR.CommandBridge.VEMap.MapExtensions
    {
        public class TrafficTileSource : TileSource
        {
            public TrafficTileSource()
                : base("http://ecn.t{0}.tiles.virtualearth.net/tiles/t{1}.png?time={2}")
            {
            }
    
            public override Uri GetUri(int x, int y, int zoomLevel)
            {
                var quadKey = new QuadKey(x, y, zoomLevel);
                return new Uri(
    				String.Format(
    					this.UriFormat, 
    					quadKey.Key[quadKey.Key.Length - 1]
    					quadKey.Key, 
    					DateTime.Now.ToString("g", System.Globalization.DateTimeFormatInfo.InvariantInfo)));
            }
         }
     }
