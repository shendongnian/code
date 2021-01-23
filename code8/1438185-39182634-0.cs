     for (i = 0; i < satir; i++)
        {
            for (j = 0; j < sutun; j++)
            {
                Button btn = new Button();
                btn.Name = "btn" + i + j;
               // btn.Text = "Button" + i + " , " + j;
                btn.Size = new Size(80, 60);
                btn.BackColor = System.Drawing.Color.AliceBlue;
                btn.Location = new Point(i * 80, j * 60);
                btn.Click += buttonClick;
                panel.Controls.Add(btn);
                buttonList.Add(btn);
            }
        }
