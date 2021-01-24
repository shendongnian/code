    public partial class Form1 : Form
    {
        private bool FlagEnterKey = false;
        public Form1()
        {
            InitializeComponent();
            Control[] controls = Controls.Find("btnTest", true);    //find control by name
        
            controls[0].Click += Form1_Click;                       //generate button click
            
          }
        private void btnTest_Click( object sender, EventArgs e )
        {
            if (FlagEnterKey) MessageBox.Show( "control click" );     //don't want to be displayed  
           
        }
        private void Form1_Click(object sender, EventArgs e )
        {
            if (!FlagEnterKey) MessageBox.Show( "button click" );  //don't want to be displayed
            FlagEnterKey = false; // Restore initial status of Flag
        }
               
        private void btnTest_PreviewKeyDown( object sender, PreviewKeyDownEventArgs e )
        {
            if (e.KeyCode == Keys.Enter) FlagEnterKey = true; // enterkey was pressed
        }
       
    }       
