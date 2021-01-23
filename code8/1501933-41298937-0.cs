    protected void bSubmit_Click(object sender, EventArgs e)
        lblFeedback.Text = "Your message has been sent.";
        lblFeedback.Visible = true; // Show the success-message
        mainForm.Visible = false; // Hide the form the user just filled in
        Response.AddHeader("Refresh", "5"); // Refresh the page after 5 seconds
    }
