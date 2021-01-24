    public class MyLabel
    {
        private System.Windows.Forms.Label label 
        = new System.Windows.Forms.Label { Text = "Nope", BackColor = Color.Green };
        //a public accessor and setter
        public Font Font { get { return label.Font; } set { label.Font = value; } }     
        //only this class can set the color, any class can read the color
        public Color ForeColor { get { return label.ForeColor; } private set { label.ForeColor = value; } }
        public AllMyStuffIWantToDo()....
        //fill in your stuff here
    }
