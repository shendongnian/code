    public class CustomButton : System.Windows.Forms.Button
    {
        private System.Windows.Forms.Label lb = new System.Windows.Forms.Label ();
    
        public CustomButton ()
        {
            this.Width = 120;
            this.Height = 65;
            this.Font = new System.Drawing.Font (this.Font.FontFamily, 24);
            lb = new System.Windows.Forms.Label ();
            lb.Font = new System.Drawing.Font (lb.Font.FontFamily, 9);
            lb.Location = new System.Drawing.Point (4, 35);
            lb.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            lb.BackColor = System.Drawing.Color.Transparent;
            lb.Width = 70;
            lb.Click += (sender, args) => InvokeOnClick (this, args); //Add this line
            this.Controls.Add (lb);
        }
    
        public System.Windows.Forms.Label getLb ()
        {
            return lb;
        }
    
        public System.Windows.Forms.Button get_btn ()
        {
            return this;
        }
    }
