     private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "insertion sort")
            {  
                for ( i = 0; i < 5; i++)
                {
                    if (c != 0)
                    {
                        myLabel[i].Dispose();
                    }
        
                    myLabel[i] = new Label();
                    myLabel[i].Location = new Point(a, b);
                    myLabel[i].Width = 70;
                    myLabel[i].Height = 70;
                    myLabel[i].BackColor=Color.White;
                    myLabel[i].BorderStyle = BorderStyle.FixedSingle;
                    panel1.Controls.Add(myLabel[i]);
                    a = a + 100;
                    myLabel[i].Visible = true;
                }
        
                timer1.Start();
                c++;
            }
        
                    var list = new List<KeyValuePair<string, string>>();
                    list.Add(new KeyValuePair<string, string>(textBox1.Text, textBox1.Text.Value));
                    list.Add(new KeyValuePair<string, string>(textBox2.Text, textBox2.Text.Value));
                    list.Add(new KeyValuePair<string, string>(textBox3.Text, textBox3.Text.Value));
                    list.Add(new KeyValuePair<string, string>(textBox4.Text, textBox4.Text.Value));
                    list.Add(new KeyValuePair<string, string>(textBox5.Text, textBox5.Text.Value));
        			list.Sort(Compare2);
                    int increment = 0;
                    foreach(var item in list)
                    {                
        				myLabel[increment].Text=item.Value;
                        increment++;
                    }			
        }
 
    static int Compare2(KeyValuePair<string, string> a, KeyValuePair<string, string> b)
            {
                return a.Value.CompareTo(b.Value);
            }
