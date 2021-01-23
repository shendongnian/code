     using System;
        using System.Windows.Forms;
        
        namespace Javell_Administratie_Software
        {
        
            public partial class Toevoegen : Form
            {
        
                public Toevoegen()
                {
                    InitializeComponent();
                }       
                public object Row{get;set;}
                public void Toevoegen2_Click(object sender, EventArgs e)
                {
                    Row=  new object[]{
                    tv.dateTimePicker1.Value, tv.textBox1.Text,
                    tv.textBox2.Text, tv.textBox3.Text, tv.textBox4.Text,    
                    tv.textBox5.Text, tv.comboBox1.Text
                    };
                this.Close();
                }
            }
        }
