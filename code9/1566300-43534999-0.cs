    private StoryBoard _SB = null;  //A member variable to hold the StoryBoard object
    public class Form1WhatEver
    {
      public Form1WhatEver()
      {
          //Instantiate a reference to the StoryBoard and hold it in the private member variable
          _SB = new StoryBoard();
      }
      public string[] TextBoxes = new string[10];
      public int Counter = 0;
      private void RtClickButton_Click(object sender, EventArgs e)
      {
          RtClickButton_ClickImpl(sender, e, ref _SB); //Pass the instance of StoryBoard byRef.
          //Check that our _SB Counter variable was incremented (+1)
          System.Diagnostics.Debug.WriteLine(_SB.Counter.ToString()); 
      }
      private void RtClickButton_ClickImpl(object sender, EventArgs e, ref StoryBoard SB)
      {
          string TBT = TxtBox.Text;
          switch(Counter)
          {
            case 0:
                TextBoxes[Counter] = TBT;
                break;
           }
           SB.Counter++; // Adds 1 to the counter.
           LtClickButton.Enabled = true;
           TxtBox.Clear(); // Clears the text box.
    }
