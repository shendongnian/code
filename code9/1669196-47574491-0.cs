    public partial class Form1 : Form
    {
        private Panel myPanel = null;
        private void adatB_Click(object sender, EventArgs e)
        {
		    ...
			
            Panel szamok = new Panel
            {
                Location = new Point(MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y),
                Size = new Size(100, 100)
            };
            if (this.myPanel != null)
            {
                this.Controls.Remove(this.myPanel);
            }
            this.myPanel = szamok;
            
            Controls.Add(szamok);
            szamok.BringToFront();
            
			...
        }
        private void szamokB_Click(object sender, EventArgs e)
        {
            if (this.myPanel != null)
            {
                this.Controls.Remove(this.myPanel);
                this.myPanel = null;
            }
           
            ...
        }
    }
