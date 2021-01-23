    BaseCharacterClass myChar;
 
    public Form1()
            {
                InitializeComponent();
    
                myChar = new BaseCharacterClass();
            }
    
            public void setLabels()
            {
                lbName.Text = myChar.CharacterName;
                lbHealthPoints.Text = (myChar.CharHPcurrent + "/" + myChar.CharHPmax);
                lbMagicPoints.Text = (myChar.CharHPcurrent + "/" + myChar.CharMPmax);
                lbClass.Text = myChar.CharacterClass;
            }
