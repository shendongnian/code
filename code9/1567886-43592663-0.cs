    int Strings = 3;
    string[] a1 = new[] {
      "Apple",
      "Banana",
      "Orange",
    }
    Random r1 = new Random();
    string b1 = a1[r1.Next(0, a1.Length)];
    listBox1.Items.Add(b1);
    string b2 = a1[r1.Next(0, a1.Length)];
    if (listBox1.Items.Contains(b2))
    {
      b2 = a1[r1.Next(0, a1.Length)];
      listBox1.Items.Add(b2);
    }
    else
    {
      listBox1.Items.Add(b2);
    }
    string b3 = a1[r1.Next(0, a1.Length)];
    if (listBox1.Items.Contains(b3))
    {
      b3 = a1[r1.Next(0, a1.Length)];
      listBox1.Items.Add(b3);
    }
    else
    {
      listBox1.Items.Add(b3);
    }
