        public class MyEventArgs : EventArgs
        {
            // class members
        }
        public abstract class Lib
        {
            public event EventHandler ShapeChanged;
            public virtual void OnShapeChanged(MyEventArgs e)
            {
                if (ShapeChanged != null)
                {
                    ShapeChanged(this, e);
                }
            }
        }
        public class LibClass1 : Lib
        {
            //Raise event here.
        }
        public class LibClass2 : Lib
        {
            //Raise event here
        }
        static void Main(string[] args)
        {
            LibClass1 lib1 = new LibClass1();
            LibClass2 lib2 = new LibClass2();
            lib1.ShapeChanged += Lib1_ShapeChanged;
            lib2.ShapeChanged += Lib1_ShapeChanged;
            lib1.OnShapeChanged(new MyEventArgs());
        }
