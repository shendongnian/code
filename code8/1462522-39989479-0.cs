     public Form1()
            {
                InitializeComponent();
                int x = 5;
                var buffor = new Queue<string>(x);
                foreach (var headerLine in File.ReadLines("C:/NewMap.csv").Take(1))
                {
                    foreach (var headerItem in headerLine.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        dataGridView1.Columns.Add(headerItem.ToString().Trim(), headerItem.ToString());
                    }
                }
                var log = new StreamReader("C:/NewMap.csv");
    
                while (!log.EndOfStream)
                {
                    string line = log.ReadLine();
    
                    if (buffor.Count >= x)
                        buffor.Dequeue();
                    buffor.Enqueue(line);
                }
    
                foreach (var line in buffor)
                {
                    if (line != string.Empty || line != string.Empty)
                    {
                        dataGridView1.Rows.Add(line);
                    }
                }
            }
