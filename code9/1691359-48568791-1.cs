    private void ColorAt() //colore variaveis
        {
            for (int a = 0; a < ctrlAt; a++)
            {
                if (atIndex[0, a] != -1)
                {
                    richTextBox1.Select(atIndex[0, a], atIndex[1, a]);
                    richTextBox1.SelectionBackColor = Color.Green;
                }
                else richTextBox1.SelectionBackColor = Color.Empty;
            }
        }
