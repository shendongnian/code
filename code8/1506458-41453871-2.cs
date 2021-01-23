    public StartingForm() {
        InitializeComponent(); 
        for(int x = 0; x < 9; x++)
        for(int y = 0; y < 9; y++) {
            // note: after initialization, you will need to assign position values
            all[x, y] = new Button();
        }  
    }
