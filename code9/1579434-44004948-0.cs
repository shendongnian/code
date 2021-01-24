    public void caesarcipher()
        {
            char c, a;
            string PT = textBox1.Text;
            PT = PT.ToLower();
            label2.Text = " "; //added this line
            for (int i = 0; i < PT.Length; i++)
            {
                c = PT[i]; //changed
                //c = Convert.ToChar(PT.Substring(i, 1));
                if ((int)c + 3 > 122) a = (char)(c + 3 - 26);
                else a = (char)(c + 3);
                label2.Text += a.ToString(); //changes here solved the error
             }
        }
