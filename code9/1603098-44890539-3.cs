     private void DrawButtons()
     {
         for (int i = 0; i < 90; i++)
         {
             ...
             button.Anchor = AnchorStyles.Left;
             ...
             panel4.Controls.Add(button);//Add this also
             ...
         }
         panel4.AutoScroll = true;
     }
