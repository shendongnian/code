    private readonly TextBox[] allBoxes = new TextBox[] {
        boxNum1, boxNum2, boxNum3, boxNum4, boxNum5, boxNum6, boxNum7
    };
    ...
    private void genBtn_Click(object sender, EventArgs e) {
        foreach (box in allBoxes) {
             box.Text = rand.Next(Min, Max).ToString();
        }
    }
