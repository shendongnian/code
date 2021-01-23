    public class MyTestClass
    {
		[JsonConverter(typeof(ArrayListConverter<string []>))]
        public ArrayList Items { get; private set; }
        public MyTestClass()
        {
            this.Items = new ArrayList();
        }
    }
