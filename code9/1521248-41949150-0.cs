    decimal grade;
    if (Decimal.TryParse(txtBoxGrade.Text, out grade)) {
        // Its a valid number - the rest of your code goes here
        // and uses the grade variable as the number you want.
    } else {
        // Its not a valid number
        lblAnswer.Text = "Input a number only.";
    }
