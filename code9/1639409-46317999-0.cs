    public partial class Form1 : Form
    {
        string output = "path to .txt file"
        string filename = "path to .h C++ file"
        public Form1()
        { 
            InitializeComponent();
        }
        private void button1_Click(object sender, EventsArgs e)
        {
            string text;
            StreamReader reader = new StreamReader(filename);
            try 
            {
                text = reader.ReadToEnd();
                string[] array = text.Split('\n');
                // You can use array
                // If you want change words, use Replace method
                // like array[n].Replace("word1", "word2")
                reader.Close(); reader.Dispose();
    
                // If you want put array elements together again
                // string joined = String.Join("\n", array);
            }
            catch (Exception ex)
            {
                new ApplicationExpection("Error: File could not be read", ex);
            }
        }
    }
