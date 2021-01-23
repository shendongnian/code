    var result = MetroFramework.MetroMessageBox.Show(
        this,
        "\n\nContinue Logging Out?", "EMPLOYEE MODULE | LOG OUT",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );
    if (result == DialogResult.Yes)
    {
        // Do Yes stuff
    }
    else
    {
        // No stuff
    }
