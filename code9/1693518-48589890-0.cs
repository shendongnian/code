    //Example with mutliple coordinates before creating an arc. AREA DEFINED AS 133830N1450807E TO 132836N1444449E TO 133043N1443814E TO 133515N1443710E THEN CLOCKWISE ON A 15.3 NM ARC CENTERED ON 133416N1445256E TO THE POINT OF ORIGIN
                        //Abbreviation
                        //    a
                        //    b
                        //    m(midangle)   (cx,cy,ax,ay,bx,by)
                        //    x(lat)
                        //    y(long)
                        //Xc=latitude provided in text for center point
                        //Yc=longitude provided in text for center point
                 
                        //point is the last point
                        var startPointStr = generateCircleLine[generateCircleLine.Length - 1].Split(' ');
    
                        var startPoint = new TfrXY { LngX = Convert.ToDouble(startPointStr[0]), LatY = Convert.ToDouble(startPointStr[1]) };
                        //point before the last point
    
                        var stopPointStr = generateCircleLine[generateCircleLine.Length - 2].Split(' ');
    
                        var stopPoint = new TfrXY { LngX = Convert.ToDouble(stopPointStr[0]), LatY = Convert.ToDouble(stopPointStr[1]) };
                        var centerPoint = new TfrXY { LngX = Convert.ToDouble(centerPointStr[0]), LatY = Convert.ToDouble(centerPointStr[1]) };
    
                        var a = Math.Atan2(stopPoint.LatY- centerPoint.LatY, stopPoint.LngX-centerPoint.LngX);
                        var b = Math.Atan2(startPoint.LatY-centerPoint.LatY, startPoint.LngX-centerPoint.LngX);
    
                        var m = MidAngle(centerPoint.LngX, centerPoint.LatY, startPoint.LngX, startPoint.LatY, stopPoint.LngX, stopPoint.LatY);
    
                        var d = Math.Sqrt(      
                            Math.Pow(Convert.ToDouble(centerPointStr[0]) - startPoint.LngX, 2) +
                            Math.Pow(Convert.ToDouble(centerPointStr[1]) - startPoint.LatY, 2)   );
    
                        var ym = (centerPoint.LatY) +( d * Math.Sin(m));
                        var xm = (centerPoint.LngX) + (d * Math.Cos(m));
    
    
    
    
    
    
    
    
    The latidude and longitude would be  ym  and xml
      
    You will also need to use this function.
    
    
            /// <summary>
            /// Find mid angle
            /// </summary>
            /// <param name="cx">center point longitude</param>
            /// <param name="cy">center point latitude</param>
            /// <param name="ax">Starting point longitude </param>
            /// <param name="ay">Starting point latitude</param>
            /// <param name="bx">Stopping point longitude</param>
            /// <param name="by">Stopping point latitude</param>
            /// <returns></returns>
            public static double MidAngle(double cx, double cy, double ax, double ay, double bx, double by)
            {
               
                var a = Math.Atan2(ay - cy, ax - cx);
                var b = Math.Atan2(by - cy, bx - cy);
    
                //Fixing infinite loop issue
                if ((ax == cx) && (ay > cy))
                    a = Math.PI / 2.0;
                else if ((ax == cx) && (ay <= cy))
                    a = -Math.PI / 2.0;
                else
                    a = Math.Atan2(ay - cy, ax - cx);
    
                if ((bx == cx) && (by > cy))
                    b = Math.PI / 2.0;
                else if ((bx == cx) && (by <= cy))
                    b = -Math.PI / 2.0;
                else
                    b = Math.Atan2(by - cy, bx - cx);
    
    
    
                var delta = a - b;
                while (delta < 0)
                {
                    delta += 2 * Math.PI;
                }
                return a - (delta / 2);
            }
