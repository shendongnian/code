    void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text.Contains( Question1)) //This did the trick here
            {
                richTextBox1.Text += "\nYou have Asked Question 1";
                questionCode = "Question1";
                chkBoxQ1.Checked = true;
                agentScore = agentScore + 1;
                stopCussing = Response1;
                //Form2 responseForm = new Form2();
                //responseForm.Show();
                FurtherResponse further = new FurtherResponse(questionCode, programcode);
                further.Show();
                Question1Answer = "Question Asked";
                txtBoxAnswer1.Enabled = true;
            }
            else if (e.Result.Text.Contains(Question2))
            {
                richTextBox1.Text += "\nYou have now asked Question 2"; 
                chkQuestion2.Checked = true;
                stopCussing = Response2;
                //Form2 responseForm = new Form2();
                //responseForm.Show();
                agentScore = agentScore + 1;
                Question2Answer = "Question Asked";
                txtAnswer2.Enabled = true;
                questionCode = "Question2";
                FurtherResponse further = new FurtherResponse(questionCode, programcode);
                further.Show();
            }
