    string cesta3 = cesta + "database.txt";
    //string file = new StreamReader(cesta3).ReadToEnd();
    string file = File.ReadAllText(cesta3);
    
    var linesToKeep = File.ReadLines(cesta3)
        .Where(l => l != "Meno: " + textBox1.Text + " PN " + textBox2.Text);
    File.WriteAllLines(cesta3, linesToKeep); // <== exception
    var tempFile = Path.GetTempFileName();
    File.Move(tempFile + ".txt", cesta3);
