    private void BunifuFlatButton1_Click(object sender, EventArgs e)
            { // Log in button
                this.MainPanel.Controls.Clear();
                this.MainPanel.Controls.Add(new LoginTab());
            }
            
            private void News_Click(object sender, EventArgs e)
            { // News button
                this.MainPanel.Controls.Clear();
                this.MainPanel.Controls.Add(new NewsTab());
            }
