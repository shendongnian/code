    public Game(string name, string characterClass)
        {
            InitializeComponent();
    
            #region CreateCharacter
            Entity player = null;
            switch (characterClass)
            {
                case "Mage":
                    {
                        player = new Mage(name); // create player
    
                        #region PrintPicture
    
                        pbPlayer.Image = Image.FromFile("C:/Users/mircea/Documents/Visual Studio 2015/Projects/RPG/Artwork/Characters/Mage.png");
                        pbPlayer.BackgroundImageLayout = ImageLayout.Center;
                        pbPlayer.Size = new Size(145, 200);
    
                        #endregion
    
                        lblName.Text = player.Name.ToString(); // show player name
                        txtLog.Text += "Welcome to game title, " + name + "!"; // greet log
                        break;
                    }
                case "Rogue":
                    {
                        player = new Rogue(name); // create player
    
                        #region PrintPicture
    
                        pbPlayer.Image = Image.FromFile("C:/Users/mircea/Documents/Visual Studio 2015/Projects/RPG/Artwork/Characters/Rogue.bmp");
                        pbPlayer.BackgroundImageLayout = ImageLayout.Center;
                        pbPlayer.Size = new Size(145, 200);
    
                        #endregion
    
                        lblName.Text = player.Name.ToString(); // show player name
                        txtLog.Text += "Welcome to game title, " + name + "!"; // greet log
                        break;
                    }
                case "Warrior":
                    {
                        player = new Warrior(name); // create player
    
                        #region PrintPicture
    
                        pbPlayer.Image = Image.FromFile("C:/Users/mircea/Documents/Visual Studio 2015/Projects/RPG/Artwork/Characters/Warrior.png");
                        pbPlayer.BackgroundImageLayout = ImageLayout.Center;
                        pbPlayer.Size = new Size(145, 200);
    
                        #endregion
    
                        lblName.Text = player.Name.ToString(); //show player name
                        txtLog.Text += "Welcome to game title, " + name + "!"; // greet log
                        break;
                    }
            } 
    
            #endregion
    
    
        }
