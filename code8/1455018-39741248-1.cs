    // to read from assets folder 
        string content;
        AssetManager assets = this.Assets;
        using (StreamReader sr = new StreamReader (assets.Open ("file.json")))
        {
            content = sr.ReadToEnd ();
        }
     
                Console.WriteLine (content );  
           
    
          
