    public static ArrayList topFive(string nomFitxer){
        ArrayList totEnArray = new ArrayList();
    
        string totElText = File.ReadAllText(nomFitxer); 
        string PH = File.ReadAllText(GetValues.obtenirRutaFitxerBlackList());
        char[] delimiterCharsText = { ' ',',', '.', ':', '\t' };
        string[] arrayPH = PH to.Split(',');
        string[] textEnArray = totElText.Split(delimiterCharsText);
    
        foreach (string text in textEnArray){
           if (!(arrayPH.Contains(text))){
                totEnArray.Add(text);
           }   
        }
    }
