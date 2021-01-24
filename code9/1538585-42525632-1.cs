    int questionID = 0;   // Global variable
    private void button1_Click(object sender, EventArgs e)
    {
       if(questionID <=10)
       {
          viewQuestion(questionID);
          questionID++;
       }
       else
       {
          // Display message that question over
       }
    }
