    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    System.Data;
    System.Drawing;
    using System.Linq;
    System.Text;
    System.Threading.Tasks;
    System.Windows.Forms;
    namespace WindowsFormsApplication3
    {
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
             //hide the current winform
             this.Hide();
             //create game  winform
             WindowsFormsApplication1 frmGame = new WindowsFormsApplication1();
             //show the game winform
             frmGame.ShowDialog();
             //when the game winform closes show again the menu 
             this.Show();
        }
    }
    }
