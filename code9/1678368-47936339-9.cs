    private char convertToLetterGrade(int numberGrade)
    {
        // replace with student code(Which I have done)
        char grade;
        if (numberGrade > 100)
        {
            grade = `F`;
        }
        if (numberGrade >= 90)
        {
            grade = `A`;
        }
        else if (numberGrade >= 80)
        {
            grade = `B`;
        }
        else if (numberGrade >= 70)
        {
            grade = `C`;
        }
        else if (numberGrade >= 60)
        {
            grade = `D`;
        }
        else
        {
            grade = `F`;
        }
        return grade;
    }
