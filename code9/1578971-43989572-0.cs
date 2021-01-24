    class Foo
    {
        public int ID;
        public string Description;
        public long Location;
        public bool IsInstanciated()
        {
            return this.ID != default(int) && this.Description != default(string) && this.Location != default(long);
        }
    }
    List<Foo> filteredFooList = fooList.Where(f => f.IsInstanciated());
