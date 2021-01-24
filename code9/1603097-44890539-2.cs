     private void DrawButtons()
     {
         for (int i = 0; i < 90; i++)
         {
             Button button = new Button();
             button.Location = new Point(15 + 40 * i, 10);
             button.Size = new Size(35, 30);
             button.Parent = panel4;
             button.Anchor = AnchorStyles.Left;
             button.Tag = i;
             panel4.Controls.Add(button);//Add this also
             button.BringToFront();
         }
         panel4.AutoScroll = true;
     }
