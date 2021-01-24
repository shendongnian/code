    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO;
    
    namespace Employees_1
    {
        public partial class Form2 : Form
        {
    
            string pathuser = @"//192.168.1.10/Shared-Public/testfile.txt";
            int check = 0;
    
            public Form2()
            {
                InitializeComponent();
            }
    
            private void Form2_Load(object sender, EventArgs e)
            {
    
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                //  string username = username.Text;
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                //string usernam = username.Text;
                // MessageBox.Show(usernam);
    
    
                while (check != 1)
                {
                    userpass();
    
    
                }
                this.Close();
    
    
            }
    
            public void userpass()
            {
                int us = 0; //for user pass
                string readText2 = File.ReadAllText(pathuser);
                using (StreamReader sr2 = new StreamReader(pathuser))
                {
                    string usernam = username.Text;
                    string line;
                    string[] lines = new String[500];
    
                    while ((line = sr2.ReadLine()) != null)
                    {
                        lines[us] = line;
    
    
                        if (lines[us] == usernam)
                        {
                            check = 1;
                            MessageBox.Show(usernam);
                            Form2 f2 = new Form2();
                            this.Hide();
                            break;
                        }
                        us++;
                    }
    
                    if (lines[us] != usernam && usernam != null)
                    {
                        this.DialogResult = DialogResult.None;
                        DialogResult result = new DialogResult();
                        result = MessageBox.Show("Invalid Username or Password?", "Retry", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                           
                            //DialogResult result = MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK);
                            // MessageBox.Show("Invalid Username or Password");
                            username.Clear();
                       
    
                        }
                    }
                }
    
    
             /*   string[] lines = File.ReadAllLines(pathuser, Encoding.UTF8);
    
                bool found = false;
                string usernam = username.Text;
                if (lines != null)
                {
                    foreach (var l in lines)
                    {
                        if (string.IsNullOrEmpty(l))
                            continue;
    
                        if (l.ToLower() == usernam.ToLower())
                        {
                            found = true;
                            break;
                        }
                    }
                }
    
                if (found)
                    MessageBox.Show("Welcome " + usernam + "!", "Protected", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                    MessageBox.Show("User not found!", "Protected", MessageBoxButtons.OK, MessageBoxIcon.Error);
    
            }
                */
    
        }
    }
