    public int IncreaseStudents(int num)
    {
        int n;
        if (int.TryParse(textBox3.Text, out n))
        {
             return n + num;
        }
        else
        {
             MessageBox.Show("Not a number: " + textBox3.Text);
             return num;
        }
    }
