            listView1.Scrollable = true;
            int itemHeight = listView1.GetItemRect(0).Height;
            int numItemsPerColumn = 10;
            //One needs to add 21 to the height, because even if no Scrollbar
            //is needed, that space will stay reserved.
            listView1.Size = new Size(500, itemHeight * numItemsPerColumn + 21);
            Panel P = new Panel();
            P.BackColor = listView1.BackColor;
            P.Location = listView1.Location;
            //The height you actually want
            P.Size = new Size(500, itemHeight * numItemsPerColumn + 3);
            P.BorderStyle = listView1.BorderStyle;
            listView1.BorderStyle = BorderStyle.None;
            listView1.Parent = P;
            listView1.Location = new Point(0, 0);
            this.Controls.Add(P);
