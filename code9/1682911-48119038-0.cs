    while(!sr.EndOfStream)
    {
        linha = sr.ReadLine();
        if(!string.IsNullOrWhiteSpace(linha))
        {
            string[] vetorUtilizadores = linha.Split(';');
        }
    }
