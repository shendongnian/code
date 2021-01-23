        var aux =listBox1.Items;
        int sumpeople = aux.Count;
        List<int> numbers = new List<int>();
        foreach(var i in aux)
        {
            numbers.Add(Convert.ToInt32(Regex.Match(i.ToString(), @"\d+").Value)); // only gets numbers
        }
        int sumnumbers = 0;
        foreach(int k in numbers)
        {
            sumnumbers = sumnumbers + k;
        }
        MessageBox.Show("People: " + sumpeople + " Sum of numbers: " + sumnumbers);
