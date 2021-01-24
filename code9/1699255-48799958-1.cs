     public partial class Form1 : Form
    {
        private bool FlagEnterKey = false;
        public Form1()
        {
            InitializeComponent();
            // For Try the code
            for (int i = 0; i < 5; i++)
            {
                Button btn = new Button {Text= "btn "+ (i+1), Name="btn "+ (i+1), TabIndex= (i+1) , Location= new Point(20, 30*(i+1)) };
                btn.Click += btnTest_Click; //Asign default Click event handle.
                this.Controls.Add( btn );   // Add Button to control.
            }
            
            // Asign Handles
            foreach (Control t in this.Controls)
            {
                Button btn= t as Button;
                if (btn != null)
                {
                    btn.Click += Form1_Click;
                    btn.PreviewKeyDown += btnTest_PreviewKeyDown;
                }
            }
            
        }
        private void btnTest_Click( object sender, EventArgs e )
        {
            if (FlagEnterKey)
            {
                MessageBox.Show( "control click " + ((Button)sender).Name );
                SendKeys.Send( "{Tab}" );                                                  // Send Key Tab, for navigate
            }  
        }
        private void Form1_Click( object sender, EventArgs e )
        {
            if (!FlagEnterKey) MessageBox.Show( "button click" + ((Button)sender).Name );
            FlagEnterKey = false;
        }
        private void btnTest_PreviewKeyDown( object sender, PreviewKeyDownEventArgs e )
        {
            if (e.KeyCode == Keys.Enter) FlagEnterKey = true;
        }
    }
}    
