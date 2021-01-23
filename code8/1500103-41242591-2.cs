    public abstract class Brain<T>
     {
         protected int width;
         protected int height;
         public Dictionary<Tuple<Point, Direction>, T> r = 
                     new Dictionary<Tuple<Point, Direction>, T>();
         public void Set(Point state, Direction direction, T reward)
         {
             r[Tuple.Create(state, direction)] = reward;
         }
         public T Get(Point state, Direction direction)
         {
             return r[Tuple.Create(state, direction)];
         }
     }
