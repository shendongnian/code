    void WriteToTxt(string[] table,string fileName)
    {
     StreamWriter writer = new StreamWriter(fileName);
     int column=1;
     writer.WriteLine(" _________");
     for(int i =0;i<table.Length;i++)
     {
       writer.WriteLine("|"+table[i]+" |");
       column++;
       if(column == 3)
       {
        column =1;
        writer.WriteLine("|__|__|__|");
       }
     }
     writer.Close();
    }
