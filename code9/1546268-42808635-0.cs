    public MainWindow()
    {
        InitializeComponent();      
        using (var fs = File.OpenRead(filepath))
        using (var reader = new StreamReader(fs))
        {
            var dict = new Dictionary<string, int>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                // Discard header line
                if (("Name" == values[0]) && ("Score" == values[1]))
                    continue;
                if (dict.ContainsKey(values[0]))
                    dict[values[0]] += Convert.ToInt32(values[1]);
                else
                    dict[values[0]] = Convert.ToInt32(values[1]);
            }
            // Now you can create some lists to display
            var list0 = new List<string>();
            var list1 = new List<string>();
            foreach (KeyValuePair<string, string> entry in dict)
            {
                list0.Add(entry.Key);
                list1.Add(entry.Value.ToString());
            }
            List0.ItemsSource = list0;
            List1.ItemsSource = list1; 
         }
    }
