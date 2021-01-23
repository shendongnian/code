        public class MenuEntry
        {
            public string Name { get; set; }
            public string Text { get; set; }
            public string Guid { get; set; }
            public string ParentGuid { get; set; }
            public List<object> MenuEntries { get; set; }
        }
        public class RootObject
        {
            public string Name { get; set; }
            public string Text { get; set; }
            public string Guid { get; set; }
            public string ParentGuid { get; set; }
            public List<MenuEntry> MenuEntries { get; set; }
        }
