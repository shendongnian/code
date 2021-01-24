    public class Option
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public Option()
        {
            ID = 0;
            Text = "";
        }
        public static List<Option> CreateListOption()
        {
            List<Option> list = new List<Option>();
            Option A = new Option();
            A.ID = 1;
            A.Text = "A";
            Option B = new Option();
            B.ID = 2;
            B.Text = "B";
            list.Add(A);
            list.Add(B);
            return list;
        }
        public override string ToString()
        {
            return Text;
        }
    }
