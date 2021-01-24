        void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                string sourceCode = FastColoredTextBox1.Text;
                // not sure what's going on for you "location" but you need to do that logic here too
                File.WriteAllText(location, sourceCode);
                e.SuppressKeyPress = true;
            }
        }
