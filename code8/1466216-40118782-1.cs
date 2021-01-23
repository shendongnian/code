    public void button1_Click(object sender, EventArgs e)
    {
        var grade = int.Parse(someTextBox.Text);
        Grade.Nested(grade);
    }
