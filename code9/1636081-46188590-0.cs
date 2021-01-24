     private void GenerateSeats()
    {
        const int seatSpacing = 6;
        const int middleRowWidth = 50;
        const int seatWidth = 40;
        const int seatHeight = 30;
        char[] Seatletter = { 'A', 'B', 'C', 'D', 'E', 'F' };
        //panel1.Width = 6 * (seatHeight + seatSpacing) + seatSpacing + middleRowWidth;
        //panel1.Width = 1200;
        var buttonSize = new Size(seatWidth, seatHeight);
        for (int i = 0; i <= 155; i++)
        {
            int SeatRow = i / 6;
            for (int j = 0; j <= 5; j++)
            {
                int thisRow = i / 6;
                int thisColumn = j % 6;
                int seatTop = thisRow * (seatHeight + seatSpacing);
                int seatLeft = thisColumn * (seatWidth + seatSpacing);
                string SeatCode = (SeatRow + 1).ToString() + Seatletter[j];
                if (thisColumn >= 3) seatLeft += middleRowWidth;
                Button SButton = new Button();
                SButton.Click += new EventHandler(SButton_Click);
                SButton.Size = buttonSize;
                SButton.BackgroundImageLayout = ImageLayout.Stretch;
                SButton.TextAlign = ContentAlignment.MiddleRight;
                SButton.Text = SeatCode;
                SButton.Location = new Point(seatTop, seatLeft);
                SeatMapPanel.Controls.Add(SButton);
            }
        }
    }
