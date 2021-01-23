        static void Main(string[] args)
        {
            Foo f = new Foo();
            f.BindToVisibleObjects();
            // add more dummy data
            f.Add(false);
            f.Add(true);
            // There will be 2 visible objects in MyVisibleObjects
            foreach (var d in f.MyVisibleObjects)
            {
                Console.WriteLine(d.IsVisible);
            }
            Console.ReadKey();
        }
        public class Foo
        {
            ObservableCollection<MyObj> myObjs = new ObservableCollection<MyObj>();
            public ReadOnlyObservableCollection<MyObj> MyVisibleObjects;
            public Foo()
            {
                // add some dummy data
                myObjs.Add(new MyObj() { IsVisible = true });
                myObjs.Add(new MyObj() { IsVisible = false });
            }
            public void BindToVisibleObjects()
            {
                myObjs.ToObservableChangeSet()
                    .Filter(o => o.IsVisible)
                    .Bind(out MyVisibleObjects)
                    .DisposeMany()
                    .Subscribe();
            }
            public void Add(bool vis)
            {
                myObjs.Add(new MyObj() { IsVisible = vis });
            }
        }
