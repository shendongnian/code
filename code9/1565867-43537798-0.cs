    public static class AvailableWidgets
    {
        private static readonly Lazy<Dictionary<int, Widget>> LazyWidgets = new Lazy<Dictionary<int, Widget>>(LoadWidgets);
        public static IEnumerable<Widget> All => LazyWidgets.Value.Values;
        public static Widget GetById(int id)
        {
            Widget widget;
            if (LazyWidgets.Value.TryGetValue(id, out widget))
                return widget;
            return null;
        }
        private static Dictionary<int, Widget> LoadWidgets()
        {
            return new Dictionary<int, Widget>()
            {
                {1, new Widget() {Id = 1, Title = "Foo", Description = ".", ApiUrl = "/api/Foo"}},
                {2, new Widget() {Id = 2, Title = "Bar", Description = "..", ApiUrl = "/api/Bar"}},
                {3, new Widget() {Id = 3, Title = "FooBar", Description = "...", ApiUrl = "/api/FooBar"}}
            };
        }
    }
