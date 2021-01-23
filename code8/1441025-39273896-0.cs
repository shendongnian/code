        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var d = new DoTheWork();
            d.SerializeSample();
        }
    }
    public class Sample
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }
    public class DoTheWork
    {
        public string SerializeSample()
        {
            List<Sample> sampleList = new List<Sample>();
            sampleList.Add(new Sample { Id = "1", Description = "Karthik" });
            sampleList.Add(new Sample { Id = "1", Description = "Sujit" });
            sampleList.Add(new Sample { Id = "1", Description = "John\"s" });
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(sw, sampleList);
            }
            System.Diagnostics.Debug.Write(sb.ToString());
            return sb.ToString();
        }
    }
