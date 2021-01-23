    public void generateButtonsCard(Panel cardPanel)
    {
        for (int y = 0; y <= 4; y++)
        {
            for (int x = 0; x <= 4; x++)
            {
                cardButtons[x, y] = new XYButton(x,y);
                cardButtons[x, y].Size = new Size(80, 80);
                cardButtons[x, y].Name = "btn" + x + "" + y;
                cardButtons[x, y].Location = new Point(80 * x, 80 * y);
                cardButtons[x, y].Click += btn_Click;
                cardPanel.Controls.Add(cardButtons[x, y]);
    
            }
    
        }
    
        RNGCard();
        cardButtons[2, 2].Text = "Free Space";
    
    }
    
    private void btn_Click(object sender, EventArgs e){
       var xyButton = sender as XYButton;
       // now you can get the x and y position from xyButton.
    }
