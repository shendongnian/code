     interface IFigures
        {
            int Getarea
            {
                get;
    
            }
            int GetPerm
            {
                get;
            }
            int CS
            {
                //get;
                set;
            }
        }
      abstract class Figures:IFigures
        {
            int _Cs;
            public Figures( int _Cs)
            {
                CS = _Cs;
            }
    
            public abstract int Getarea
            {
                get;
    
            }
            public abstract int GetPerm
            {
                get;
    
            }
            public abstract int CS
            {
                //get;
                set;
            }
            public abstract void display();
    
        }
    class Circle:Figures
        {
            int _r, _csc;
            public Circle(int _r):base(_r)
            {
                CS = _r;
            }
             
            public override int Getarea
            {
                get
                {
                    return (_r * _r);
                }
    
               
            }
            public override int GetPerm
            {
                get
                {
                    return (2* _csc * _csc);
                }
    
               
            }
            public override void display()
            {
                Console.WriteLine("area of Circle={0}", (_r * _r));
                Console.WriteLine("perimeter of rectangle={0}", (2 * _r * _r));
            }
            public override int CS
            {
                //get
                //{
                //    return _csc;
                //}
    
                set
                {
                    _csc = value;
                }
            }
    
        }
    
    class Rectangle:Figures
        {
            int _L, _csr;
            public Rectangle(int _L,int _W):base(_W)
            {
             this._L = _L;
                CS = _W;
            }
            public override int Getarea
            {
                get
                {
                    return _csr * _L;
                }
    
               
            }
            public override int GetPerm
            {
                get
                {
                    return (2* _csr * _L);
                    
                }
    
                
               
            }
            public override void display()
            {
                Console.WriteLine("area of rectangle={0}", (_csr * _L));
                Console.WriteLine("perimeter of rectangle={0}", (2* _csr * _L));
            }
            public override int CS
            {
                //get
                //{
                //    return _csr;
                //}
    
                set
                {
                    _csr = value;
                }
            }
    }
    class Program
        {
            static void Main(string[] args)
            {
                Figures f = new Rectangle(3, 4);
                f.display();
                //f.CS = 5;
                f.display();
    
                Console.ReadKey();
            }
        }
