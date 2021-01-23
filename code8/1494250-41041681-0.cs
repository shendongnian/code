    You may want to check this out.    
    
        public class LinesOne : ILines<Item1>
            {
                public ILine<Item1>[] Lines
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
            }
        
            public class LinesTwo : ILines<Item2>
            {
                public ILine<Item2>[] Lines
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
            }
            public interface ILines<T>
            {
        
                ILine<T>[] Lines { get; set; }
            }
        
            public interface ILine<T>
            {
                T Item { get; set; }
            }
        
            public class Item1
            {
            }
        
            public class Item2
            {
            }
        
            public class Line1 : ILine<Item1>
            {
                public Item1 Item { get; set; }
            }
        
            public class Line2 : ILine<Item2>
            {
                public Item2 Item { get; set; }
            }
