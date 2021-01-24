     [TestMethod]
        public void DoCopy()
        {
            var source = new SomeObject();
            var Destination = new SomeObject();
            Destination.A = new AnotherObject();
            Destination.C = new LastOne();
            Destination.B = new AnotherObject();
            var type = source.GetType();
            BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            PropertyInfo[] properties = type.GetProperties(flags);
            foreach (PropertyInfo property in properties)
            {
                var insideSource = property.GetValue(source);
                var insideType = insideSource.GetType();
                var insideDestination = property.GetValue(Destination);
                insideType.GetProperties(flags).Where(s => s.Name == "Text" || s.Name == "Checked").ToList().ForEach(p =>
                {
                    p.SetValue(insideDestination, p.GetValue(insideSource)); 
                });
                
            }
            Trace.WriteLine(JsonConvert.SerializeObject(Destination));
        }
        public class SomeObject
        {
            public AnotherObject A { get; set; } = new AnotherObject() {Text = "Text"};
            public AnotherObject B { get; set; } = new AnotherObject() {Text = "Text2"};
            public LastOne C { get; set; } = new LastOne() {Checked = true};
        }
        public class AnotherObject
        {
            public string Text { get; set; }
        }
        public class LastOne
        {
            public bool Checked { get; set; }
        }
