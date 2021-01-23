    public override void Input0_ProcessInputRow(Input0Buffer Row)
    {   
        string path = Path.Combine( "C:\\", Row.TYPE + ".txt");
        if (File.Exists(path))
            {
                 using (StreamWriter file = new StreamWriter(@path, true))
                       { file.WriteLine(Row.Record);}
            }
        else
            { 
                 File.WriteAllText(@path, "File HEADER  " );
                 using (StreamWriter file = new StreamWriter(@path, true))
                       { file.WriteLine("\n");}
            }
    }
