    private static string FinalPiece(double dblVal)
    {
        double squared = dblVal * dblVal;
        return mathfinal.ToString();
    }
    public void btnProblem4_Click(object sender, EventArgs e)
    {
      lblOutput.Text = FinalPiece(10);
    }
