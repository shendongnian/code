    public void CaesarCipher()
    {
        label2.Text = "";
        foreach (var character in textBox1.Text.ToLower())
        {
            var intVal = character + 3;
            label2.Text += intVal > 22 ? intVal - 26 : intVal;
        }
    }
