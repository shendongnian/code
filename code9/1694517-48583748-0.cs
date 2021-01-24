    private void button1_Click(object sender, EventArgs e)
    {
        int a = 127;
        int v = Roll(a);
        // Use curly braces, not parens for String.Format
        MessageBox.Show(String.Format("Roll for {0} is {1}, ", a, v));
    }
    // Roll should be it's own method, outside of your click handler
    private int Roll (int x)
    {
        return (x <= 2) ? x : x + Roll(x / 2);
    }
