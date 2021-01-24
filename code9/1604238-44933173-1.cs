    public string ressources()
    {
        string ressourcesText = "Ressources:"
                            + "\n Wood :" + wood
                            + "\n Stone : " + stone
                            + "\n Wheat : " + wheat
                            + "\n Food : " + food;
        return ressourcesText;
    }
    
    public void Form1_Load(object sender, EventArgs e)
    { 
        LblRessources.Text = ressources();
    }
    
