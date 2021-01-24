    Pontos aa = new Pontos();
    aa.Add(new Ponto(2, 3));
    aa.Add(new Ponto(3, 4));
    StringBuilder s = new StringBuilder();
    s.Append("(");
    s.Append(String.Join(",", aa));
    s.Append(")");
    
    textBox1.Text = s.ToString();
