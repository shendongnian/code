        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                BoardButtons[x, y] = new Button();
                Controls.Add(BoardButtons[x, y]);
                BoardButtons[x, y].Visible = true;
                int tmpX = x;
                int tmpY = y;
                BoardButtons[x, y].Click += (s, ev) =>
                {
                    MyFunction(tmpX, tmpY);
                };
            }
        }
