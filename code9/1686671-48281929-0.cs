            string[] show = richTextBox1.Text.Replace(Convert.ToChar(13).ToString(), " ").Replace(Convert.ToChar(10).ToString(), " ").Split(' ');
            string type = textBox1.Text;
            int num = 0;
            for (int i = 0; i < show.Length; i++)
            {
                
                if (show[i].Trim() == textBox1.Text)
                    num++;
            }
            textBox1.Text = num.ToString();
