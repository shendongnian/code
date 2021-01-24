        public MyClass(int set, int set2, int size)
        {
            this.Size = size;
            this.Set = set;
            this.Set2 = set2;
        }
        public IEnumerator<int> GetEnumerator()
        {
            foreach (var i in Enumerable.Range(0, this.Size))
                yield return i;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public void Dispose()
        {
            Console.WriteLine("Disposed: {0}/{1}", this.Set, this.Set2);
        }
        public int Size { get; private set; }
        public int Set { get; private set; }
        public int Set2 { get; private set; }
    }
