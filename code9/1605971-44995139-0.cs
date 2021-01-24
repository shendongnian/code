    class class1
        {
            private int _p1;
            private int _p2;
            //and etc depending on the need of it
    
            public class1(int p1, int p2)
            {
                _p1 = p1;
                _p2 = p2;
            }
    
            public int getp1()
            {
                return 1;
            }
        }
    
        class class2<T>
        {
            private Func<T> getValue;
    
            public class2(Func<T> getValue)
            {
                this.getValue = getValue;
            }
    
            public void Add(class1 cs)
            {
                //here is where i want to execute getValue on cs itself to compare them to one another. 
                getValue();
            }
        }
    class Program
            {
            static void Main(string[] args)
            {
                class1 c1 = new class1(1, 2);
                Func<int> getp1 = c1.getp1;
                class2<int> c2 = new class2<int>(getp1);
                c2.Add(c1);
            }
        }
