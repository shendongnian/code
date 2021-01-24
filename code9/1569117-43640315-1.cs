    class Foo : IDisposable {
        string _bar = "init";
        void Fooy() { _bar = "fooy"; }
        public void Dispose() {
            _bar = null;       
        }
        static void Main()
        {
            var v = new Foo();
            Console.WriteLine(v._bar);
            if(v is IDisposable id) using(id)
                v.Fooy();
            else
                v.Fooy();
            
            Console.WriteLine(v._bar ?? "null");;
           
        }
    }
