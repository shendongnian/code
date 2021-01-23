    private void btnCalculate_Click(object sender, EventArgs e)
    {
        Func<TextBox, double?> parseTextBox = tb =>
        {
            double value;
            if (!double.TryParse(tb.Text, out value))
            {
                MessageBox.Show("Invalid Number!",
                    "Yancarlos Grade Calculator",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                tb.Focus();
                return null;
            }
            return value;
        };
        double?[] tests =
        (
            from tb in new[] { txtTest3, txtTest2, txtTest1, }
            let result = parseTextBox(tb)
            orderby result descending
            select result
        ).ToArray();
        if (tests.Any(t => t == null))
        {
            return;
        }
        double average =
            tests
                .Take(3 - (checkBox1.Checked ? 1 : 0))
                .Average()
                .Value;
        var grades = new[]
        {
            new { Score = 59.9, Grade = "F" },
            new { Score = 63.9, Grade = "D-" },
            new { Score = 66.9, Grade = "D" },
            new { Score = 69.9, Grade = "D+" },
            new { Score = 73.9, Grade = "C-" },
            new { Score = 76.9, Grade = "C" },
            new { Score = 79.9, Grade = "C+" },
            new { Score = 83.9, Grade = "B-" },
            new { Score = 86.9, Grade = "B" },
            new { Score = 89.9, Grade = "B+" },
            new { Score = 93.9, Grade = "A-" },
            new { Score = 96.9, Grade = "A" },
            new { Score = 100.0, Grade = "A+" },
        };
        string grade =
            grades
                .Where(g => g.Score >= average)
                .Select(g => g.Grade)
                .First();
        txtAverage.Text = average.ToString("f1");
        txtLetterGrade.Text = grade;
    }
