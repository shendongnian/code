    string login = @"utilizadores.txt";
    using (StreamReader sr = File.OpenText(login))
    {
        string linha = sr.ReadLine();
        while(linha != null)
        {
            string[] vetorUtilizadores = linha.Split(';');
            linha = sr.ReadLine();
        }
    }
