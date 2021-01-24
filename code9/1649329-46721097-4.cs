    public partial class GameBoard : Form
    {
        public GameBoard ()
        {
            InitializeComponent();
    
            tileClass.Dock = DockStyle.Fill;
            this.Controls.Add(tileClass);
        }
    
        TileClass tileClass = new TileClass();
    
        private void txtEnter_Click(object sender, EventArgs e)
        {
    
            tileClass.IncomingCollum = int.Parse(txtCollum.Text);
            tileClass.IncomingRow = int.Parse(txtRow.Text);
                
            this.ResumeLayout(); //Important
            tileClass.CreateGrid();
            this.Invalidate(); // Important
        }
    }
