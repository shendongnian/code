    class SomeWindow
    {
        private SomeControl tagNameBoxAMT1;
        private SomeControl tagNameBoxAMT2;
        private SomeControl tagNameBoxAMT3;
        public SomeWindow()
        {
            tagNameBoxAMT1 = new SomeControl() { Text = "Text1" };
            tagNameBoxAMT2 = new SomeControl() { Text = "Text2" };
            tagNameBoxAMT3 = new SomeControl() { Text = "Text3" };
        }
        public void GiveMeWithReflection()
        {
            var thisType = typeof(SomeWindow);
            var controlType = typeof(SomeControl);
            var textProperty = controlType.GetProperty("Text");
            var props = thisType.GetFields(System.Reflection.BindingFlags.Instance |
                                           System.Reflection.BindingFlags.NonPublic)
                                .Where(fi => fi.Name.StartsWith("tagNameBoxAMT"));
            foreach (var prop in props)
            {
                var control = prop.GetValue(this);
                var tagName = textProperty.GetValue(control);
            }
        }
    }
