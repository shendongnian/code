                SynchronizingCollection<string> c1 = new SynchronizingCollection<string>();
                SynchronizingCollection<string> c2 = new SynchronizingCollection<string>();
                c1.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(c1_CollectionChanged);
                c2.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(c2_CollectionChanged);
                c1.SetSynchronizedCollection(c2);
                c1.AddRange(new string[] { "d", "s" });
                c1.ClearAll();
                c1.Add("a");
                c1.Add("b");
                c1.Add("c");
                c1.Add("d");
                c2.Remove("c");
                List<string> l = new List<string> { "x1", "x2", "x3", "x4", "x5" };
                c2.AddRange(l);
                c1.RemoveItems(new string[] { "x2", "b" });
                c2.ReplaceAll(l);
    //....
        void c1_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine(e.Action + " Collection 1 changed");
        }
        void c2_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine(e.Action + " Collection 2 changed");
        }
