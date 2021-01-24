    public PinLoginPageModel()
        {
    
            NumberCommand = new Command<string>(NumpadToNumber);
        }
    
        void NumpadToNumber(string obj)
        {
            if(obj == "0")
            {
                PincodeMasked = "0";
            }
        }
