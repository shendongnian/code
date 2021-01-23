    public class Program
    {
        public static void Main(string[] args)
        {
            MyForm form = new MyForm();
            form.LoadJson();
            while (form.HasNext)
            {
                // simulate button click with a keypress
                Console.ReadKey(true);
                form.ButtonClick();
            }
        }
    }
    public class MyForm
    {
        private IEnumerator<JObject> Enumerator { get; set; }
        public bool HasNext { get; private set; }
        public void LoadJson()
        {
            string json = @"{""data"":[{""q_id"":""1"",""q_text"":""banana.""},{""q_id"":""2"",""q_text"":""apple.""}, {""q_id"":""3"",""q_text"":""mango.""},{""q_id"":""4"",""q_text"":""strawberries.""}],""tag"":""question"",""error"":null}";
            JObject IDObject = JObject.Parse(json);
            Enumerator = IDObject["data"].Children<JObject>().GetEnumerator();
            ButtonClick();  // Advance to first fruit
        }
        public void ButtonClick()
        {
            HasNext = Enumerator.MoveNext();
            if (HasNext)
            {
                JObject nextfruit = Enumerator.Current;
                Console.WriteLine(nextfruit["q_text"] + "  Press any key to advance to the next fruit.");
            }
            else
            {
                Console.WriteLine("No more fruits.");
            }
        }
    }
