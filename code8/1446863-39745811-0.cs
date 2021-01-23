        List<string> s = new List<string>();
        s.Add("abc");
        s.Add("aaa");
        s.Add("acb");           
        textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
        textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        AutoCompleteStringCollection data = new  AutoCompleteStringCollection();
        data.AddRange(s.ToArray());
        textBox1.AutoCompleteCustomSource = data;
