    private void button6_Click(object sender, EventArgs e)
    {
        AddToLabel(label7, 12);
    }
    void AddToLabel(Label label, int value)
    {
        var n = int.Parse(label.Text); // convert the actual value of label.Text to int
        var add = n + value; // add the increment
        label.Text = add.ToString(); // assign to label.Text
    }
