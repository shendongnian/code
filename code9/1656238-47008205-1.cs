    private void button1_Click(object sender, EventArgs e)
    {
        int[] numRanges = new int[] {0, 16, 31, 51, 76};
        char[] gradeLetter = new char[] {'F', 'D', 'C', 'B', 'A'};
        double usersGrade = 0;
        int numOfWords = Convert.ToInt32(textBox1.Text);
        for (int index = numRanges.Length - 1; index >= 0; index--)
        {
            if (numOfWords >= numRanges[index])
            {
                usersGrade = gradeLetter[index];
                break;
            }
        }
        label2.Text = $"You received an {usersGrade}";
    }
