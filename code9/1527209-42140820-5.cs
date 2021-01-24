    private void averageGrade_Click(object sender, EventArgs e) {
        sum = 0; // reset sum
   
        for (int y = 0; y < 5; y++) {
            sum = sum + grade[y];
        }
        average = sum / grade.Length;
        string avgOutput = Convert.ToString(average);
        outputText.Visible = true;
        outputText.Text = "Class Average:   " + avgOutput;
    }
