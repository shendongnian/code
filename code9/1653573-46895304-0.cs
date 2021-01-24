    public bool Process(QSRules.SessionClass mySession)
    {
        var response = MessageBox.Show("Do you want to Tender €10", 
            "Tender Amount", MessageBoxButtons.YesNo, 
            MessageBoxIcon.Question) == DialogResult.Yes;
        if (response)
            SendKeys.Send("{F12}{DOWN}10.00{{ENTER}");
        return response;
    }
