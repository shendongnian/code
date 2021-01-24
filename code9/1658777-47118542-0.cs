    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            enum stringLocation : int
            {
                label1,label2, label3, label4
            }
            int location =(int) stringLocation.label1;
            string contentToMove= "0";
            public Form1()
            {
                InitializeComponent();
            }
    
            private void forward_Click(object sender, EventArgs e)
            {
                location = (location+1) % 4;
                switch (location){
                case (int) stringLocation.label1:
                        label1.Text = contentToMove;
                        label2.Text = "";
                        label3.Text = "";
                        label4.Text = "";
                        break;
                case (int) stringLocation.label2:
                        label1.Text = "";
                        label2.Text = contentToMove;
                        label3.Text = "";
                        label4.Text = "";
                        break;
                case (int) stringLocation.label3:
                        label1.Text =  "";
                        label2.Text = "";
                        label3.Text = contentToMove;
                        label4.Text = "";
                        break;
                case (int)stringLocation.label4:
                        label1.Text = "";
                        label2.Text = "";
                        label3.Text = "";
                        label4.Text = contentToMove; 
                        break;
                default:
                    break;
                }
        
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                label1.Text = contentToMove;
                label2.Text = "";
                label3.Text = "";
                label4.Text = "";
            }
        }
    }
