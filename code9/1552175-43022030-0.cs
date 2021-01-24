    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (textBox1.Text != "".Trim())
        {
            int w = TextRenderer.MeasureText(textBox1.Text, textBox1.Font).Width;
            int h = TextRenderer.MeasureText(textBox1.Text, textBox1.Font).Height;
            int sizeContent = w * h;
            int sizeTb = (textBox1.Width * textBox1.Height);
            if (sizeContent < sizeTb)
            {
                while (sizeContent < sizeTb)
                {
                    textBox1.Font = new Font(textBox1.Font.FontFamily, textBox1.Font.SizeInPoints + 1);
                    w = TextRenderer.MeasureText(textBox1.Text, textBox1.Font).Width;
                    h = TextRenderer.MeasureText(textBox1.Text, textBox1.Font).Height;
                    sizeContent = w * h;
                }
            }
            if (sizeContent >= sizeTb)
            {
                while (sizeContent >= sizeTb)
                {
                    textBox1.Font = new Font(textBox1.Font.FontFamily, textBox1.Font.SizeInPoints - 1);
                    w = TextRenderer.MeasureText(textBox1.Text, textBox1.Font).Width;
                    h = TextRenderer.MeasureText(textBox1.Text, textBox1.Font).Height;
                    sizeContent = w * h;
                }
            }
        }
    }
