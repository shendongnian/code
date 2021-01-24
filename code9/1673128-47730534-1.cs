    using (StreamWriter writer2 = new StreamWriter(outputFileName2))
    {
            do
            {
                //...more code lines
            }
            while (!reader.EndOfStream);
            do
            {
               //...more code lines
            }while (!reader2.EndOfStream);
            reader.Close();
            writer.Close();
    } 
