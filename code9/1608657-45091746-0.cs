    var NBSref = textBox3.Text;
    var Lenght = textBox1.Text;
    var Width = textBox2.Text;
    var separator = ",";
    string csvpath = "FILE LOCATION";
    StringBuilder csvcontentNew = new StringBuilder();
    csvcontentNew.Append(NBSref + separator  + Lenght + separator  + Width);  // Try it like this
    //String that will define CSV Location
    File.AppendAllText(csvpath, csvcontentNew.ToString());
    textBox1.Clear();
    textBox2.Clear();
    textBox3.Clear();
