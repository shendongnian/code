    private readonly List<int> theNumbers = new List<int>();
    private void gerarNumeros() // method to generate numbers
    {
        int a = Gerar.Next(1, 50);
        int b = Gerar.Next(1, 50);
        int c = Gerar.Next(1, 50);
        int d = Gerar.Next(1, 50);
        int e = Gerar.Next(1, 50);
        int f = Gerar.Next(1, 12);
        int g = Gerar.Next(1, 12);
        theNumbers.Clear();
        theNumbers.Add(a);
        theNumbers.Add(b);
        theNumbers.Add(c);
        theNumbers.Add(d);
        theNumbers.Add(e);
        theNumbers.Add(f);
        theNumbers.Add(g);
        theNumbers.Sort();
        num1.Content = a.ToString();
        num2.Content = b.ToString();
        num3.Content = c.ToString();
        num4.Content = d.ToString();
        num5.Content = e.ToString();
        num6.Content = f.ToString();
        num7.Content = g.ToString();
    }
    private void button_ordenar_Click(object sender, RoutedEventArgs e)
    {
        if (theNumbers.Count == 7)
        {
            num1.Content = theNumbers[0];
            num2.Content = theNumbers[1];
            num3.Content = theNumbers[2];
            num4.Content = theNumbers[3];
            num5.Content = theNumbers[4];
            num6.Content = theNumbers[5];
            num7.Content = theNumbers[6];
        }
    }
