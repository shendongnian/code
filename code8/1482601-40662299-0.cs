        for(int x = 0; x < breite; x++)
        {
            for(int y = 0; y < hoehe; y++)
            {
                CheckBox ledcheck = new CheckBox();
                ledcheck.Location = new Point(x * 20, y * 20);
                panel1.Controls.Add(ledcheck);
            }
        }
