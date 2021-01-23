    int counter = 0;
        private string replaceSpecial(string A)
        {
            if (A.Equals("A")) return "C";
            else if (A.Equals("F")) return "H";
            else if (A.Equals("C")) return "W";
            else if (A.Equals("B")) return "G";
            else if (A.Equals("|")) return "";
            else return A;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('|'))
            {
                counter++;
            }
            if (counter == 0 || counter % 2 == 0)
                textBox2.Text += replaceSpecial(e.KeyChar.ToString());
            else
                textBox2.Text += e.KeyChar.ToString().Replace("|", "");
        }
