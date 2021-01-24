    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace Tick_Tack_Toe
    {
        public partial class Form1 : Form
        {   
            public Form1()
            {
                InitializeComponent();
                MyButton.buttons = new List<MyButton>() { 
                    new MyButton() { button = xButton1, label = xLabel1},
                    new MyButton() { button = xButton2, label = xLabel2},
                    new MyButton() { button = xButton3, label = xLabel3},
                    new MyButton() { button = oButton1, label = oLabel1},
                    new MyButton() { button = oButton2, label = oLabel2},
                    new MyButton() { button = oButton3, label = oLabel3}
                };
                foreach (MyButton button in MyButton.buttons)
                {
                    button.button.Click += new EventHandler(Button_Click);
                }
            }
            private void Button_Click(object sender, EventArgs e)
            {
                MyButton button = sender as MyButton;
                button.label.Visible = true;
                button.button.Enabled = false;
                switch (button.button.Text)
                {
                    case "X":
                        //enter your code here
                        break;
                    case "Y":
                        //enter your code here
                        break;
                }
            }
            private void resetToolStripMenuItem_Click(object sender,
            EventArgs e)
            {
                foreach (MyButton button in MyButton.buttons)
                {
                    button.button.Enabled = true;
                    button.label.Visible = false;
                }
            }
        }
        public class MyButton
        {
            public static List<MyButton> buttons { get; set; }
            public Button button { get; set; }
            public Label label { get; set; }
        }
    }   
