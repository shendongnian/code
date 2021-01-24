    string ressourcesText;
    public void ressources()
    {
        ressourcesText = "Ressources:"
                            + "\n Wood :" + wood
                            + "\n Stone : " + stone
                            + "\n Wheat : " + wheat
                            + "\n Food : " + food;
    }
    public void Form1_Load(object sender, EventArgs e)
    { 
        LblRessources.Text = ressourcesText;
    }
   
