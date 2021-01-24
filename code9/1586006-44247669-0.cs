    private void button1_Click(object sender, EventArgs e)
    {
        method1(sender);
    }
    public void method1(object sender)
    {
        var button = sender as Button;
        if (button != null)
        {
            var caller = button.Name;
            MessageBox.Show(caller);//It shows button1
        }
    }
