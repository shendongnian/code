        public void textBox1_Click(Object ob, EventArgs eventArgs){
            if (textBox1.Text.Length > 0)
            {
                string text = textBox1.Text;
                string tmpText = "";
                if (textBox1.Text.Length == 1)
                {
                    tmpText = text.ToUpper();
                }
                else
                {
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (i < text.Length - 1)
                            tmpText += text[i];
                        else if (text[text.Length - 2] == ' ')
                            tmpText += text[text.Length - 1].ToString().ToUpper();
                        else
                            tmpText += text[i];
                    }
                }
                textBox1.Text = tmpText;
                textBox1.Focus();
                textBox1.Select(textBox1.Text.Length, 0);
            }
        }
