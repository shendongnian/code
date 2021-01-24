    string[] separators = { ",", " " };
    int rowCount = Convert.ToInt32("2");
    string value = "2 5 6 7 8 9 0 2 1 3 4 5 6";
    string[] words = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    string[] rows = new string[rowCount];
    for (int i = 0; i < words.Length; i++)
    {
        int mod = i % rowCount;
        rows[mod] += words[i] + " ";
    }
    foreach (string item in rows)
    {
        listView1.Items.Add(item);
    }
    listView1.View = View.List;
