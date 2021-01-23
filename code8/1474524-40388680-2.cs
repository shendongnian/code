    public void IncreaseStudents(int num, out int result)
    {
        int n;
        if (int.TryParse(textBox3.Text, out n))
        {
             result = n + num;
        }
        else
        {
             MessageBox.Show("Not a number: " + textBox3.Text);
             result = num;
        }
    }
