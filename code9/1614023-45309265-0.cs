    string caminho = @"C:\Users\User1\Desktop\Test\";
    DirectoryInfo dir = new DirectoryInfo(caminho);
    FileInfo[] fi = dir.GetFiles();
    foreach (var ficheiro in fi)
    {
        string caminhoF = caminho + ficheiro.ToString();
        string extension = Path.GetExtension(caminhoF);
        if (!comboBox1.Items.Contains(extension))
        {
            comboBox1.Items.Add(extension);
        }
    }
