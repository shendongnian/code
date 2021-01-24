        private List<FileLine> Source { get; set; }
        public class FileLine
        {
            public string Text { get; set; }
            public int Id { get; set; }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Source = GetFiles();
            comboBox1.Items.AddRange(Source.ToArray());
        }
        public List<FileLine> GetFiles()
        {
            var files = new List<FileLine>();
            int counter = 0;
            string line;
            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader("Items.txt");
            while ((line = file.ReadLine()) != null)
            {
                var item = line.Split(';').ToList();
                files.Add(new FileLine { Text = item.FirstOrDefault(), Id = int.Parse(item.LastOrDefault()) });
                counter++;
            }
            file.Close();
            return files;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = comboBox1.SelectedItem as FileLine;
            IdLabel.Text = item.Id.ToString();
        }
