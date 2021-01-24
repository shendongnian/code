            private void AddButtons_Click(object sender, EventArgs e)
            {
                Button btn = new Button();
                btn.Click += new EventHandler(StoreTheFirstButton_Click);
                flowLayoutPanel1.Controls.Add(btn);
            }
            private void StoreTheFirstButton_Click(object sender, EventArgs e)
            {
                Button button = sender as Button;
                Button ButtonToSave = button;
                //ButtonToSave = "First button in flowLayoutPanel1";
            }
