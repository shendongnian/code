    private void button1_Click(object sender, EventArgs e)
    {
        int a = 127;
        int v = Roll(a);
        // Use curly braces, not parens for String.Format
        MessageBox.Show(String.Format("Roll for {0} is {1}, ", a, v));
        // If you're using C# 6+, you could also use string interpolation
        MessageBox.Show($"Roll for {a} is {v}");
    }
    // Roll should be it's own method, outside of your click handler
    private int Roll (int x)
    {
        return (x <= 2) ? x : x + Roll(x / 2);
    }
    // Again, if you're using C# 6+, you could simplify your Roll method
    // using expression bodied members
    private int Roll (int x) => (x <= 2) ? x : x + Roll(x / 2);
