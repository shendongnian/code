        public class Obj{
          int Size;
          List<Point> Pos = new List<Point>();
          public Obj(int size){
            this.Size = size;
          }
          public set_coord(int index, int x, int y){
            if(index >= this.Size){
              Console.Writeline("Catch OutOfRangeException")
            }else{
              this.Pos.Add(new Point(x,y));
            }
          }
        }
        class Point{
          int x = 0;
          int y = 0;
          public Point(int xCor, int yCor){
            this.x = xCor;
            this.y = yCor;
          }
        }
