    private void textBox1_TextChanged(object sender, EventArgs e)
            {
                string text = textBox1.Text;
                foreach (Control c in this.Controls)
                {
                    if (c is Button)
                    {
                        if (!c.Text.ToUpper().Contains((text.ToUpper())))
                        {
                           //You can set the hightlight, or anything here
                            c.Visible = false;
                        }
                        else
                        {
                            //You can set the hightlight, or anything here
                            c.Visible = true;
                        }
                    }
                }
            }
