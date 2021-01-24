    private void convertToLetterGrade(int numberGrade)
    {
        // replace with student code(Which I have done)
        if (numberGrade >= 90 && numberGrade <= 100)
        {
            MessageBox.Show("A");
        }
        else if (numberGrade >= 80 && numberGrade < 90)
        {
            MessageBox.Show("B");
        }
        else if (numberGrade >= 70 && numberGrade < 80)
        {
            MessageBox.Show("C");
        }
        else if (numberGrade >= 60 && numberGrade < 70)
        {
            MessageBox.Show("D");
        }
        else if  (numberGrade < 60)
        {
            MessageBox.Show("F");
        }
    }
