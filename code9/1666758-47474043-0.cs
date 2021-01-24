    class Program
    {
        static ListView listView1 = new ListView();
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("C:\\testfiles");
           
            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                ListViewItem item = new ListViewItem(fileName);
                item.Tag = file;
                listView1.Items.Add(item);
            }
        }
        static void ClearList()
        {
            listView1.Items.Clear();
        }
    }
