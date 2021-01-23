            LinkButton lb = new LinkButton();
            lb = new LinkButton();
            lb.Text = songName + "</br>"; //LinkButton Text
            lb.ID = song.Key.ToString(); // LinkButton ID’s
            lb.CommandArgument = Convert.ToString(song.Key); 
            lb.CommandName = Convert.ToString(song.Key); 
            lb.Click += new EventHandler(test_Click);                      
            this.form1.Controls.Add(lb);
            PlaceHolder1.Controls.Add(lb);
