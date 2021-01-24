        void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                File.WriteAllText(location, sourceCode);
                e.SuppressKeyPress = true;
            }
        }
