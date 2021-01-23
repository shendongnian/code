     private void button5_Click(object sender, EventArgs e)
            {
                foreach (Button item in this.Controls.OfType<Control>().Where(c => c.GetType() == typeof(Button)))
                {
                    if (item.Name == (sender as Button).Name)
                        continue;
                    item.Enabled = false;
                }
                Button button = (Button)sender;
                switch (button.Name)
                {
                    case "button1":
                        textBox.Text = "Hey ! you may get a car after one year";
    
                        break;
                    case "button2":
                        textBox.Text = "Hey ! you may get a big super duper House after a year";
                        break;
                    case "button3":
                        textBox.Text = "something";
                        break;
                    case "button4":
                        textBox.Text = "something";
                        break;
                    case "button5":
                        textBox.Text = "somehting";
                         break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
    
                }
    
            }
