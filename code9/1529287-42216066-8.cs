    public class Drone {
      public Point Position { get; set; }
      public Point[] SafeArea { get; set; }
      public bool CheckIfDroneWithinMySafeArea(Drone drone) {
         return IsWithinPolygon( this.SafeArea, drone.Position );
      }
      public static bool IsWithinPolygon(Point[] poly, Point dronePosition) {
         bool isWithinPolygon = false;
         if( poly.Length < 3 ) {
            return isWithinPolygon;
         }
         var oldPoint = new
            Point( poly[ poly.Length - 1 ].X, poly[ poly.Length - 1 ].Y );
         Point p1, p2;
         for( int i = 0; i < poly.Length; i++ ) {
            var newPoint = new Point( poly[ i ].X, poly[ i ].Y );
            if( newPoint.X > oldPoint.X ) {
               p1 = oldPoint;
               p2 = newPoint;
            }
            else {
               p1 = newPoint;
               p2 = oldPoint;
            }
            if( ( newPoint.X < dronePosition.X ) == ( dronePosition.X <= oldPoint.X )
                  && ( dronePosition.Y - ( long ) p1.Y ) * ( p2.X - p1.X )
                  < ( p2.Y - ( long ) p1.Y ) * ( dronePosition.X - p1.X ) ) {
               isWithinPolygon = !isWithinPolygon;
            }
            oldPoint = newPoint;
         }
         return isWithinPolygon;
      }
    }
