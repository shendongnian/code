    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApplicationTest
    {
    public partial class Form1 : Form
    {
       public Form1()
        {
            InitializeComponent( );
            this.MouseDown += Form1_MouseDown;
        }
        private void Form1_MouseDown( object sender, MouseEventArgs e )
        {
            if( e.Clicks == 1 )
            {
            }
            else if( e.Clicks == 2 )
            {
            }
            else if( e.Clicks == 3 )
            {
            }
        }
    }
    }
