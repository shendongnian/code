    int counterBed1 = 0;
    if (ImageButton1.ImageUrl != "~/Images/bed-occupied.png")
     {
          ImageButton1.ImageUrl = "~/Images/bed-occupied.png";
          if (ViewState["Counter"] == null)
          {
              counterBed1 = 1;
              TextBoxClass.Text = counterBed1.ToString();
              ViewState["Counter"] = counterBed1; // Add This
           }
           else
           {
               counterBed1 = (int)ViewState["Counter"] + 1;
               ViewState["Counter"] = counterBed1; //Add This
           }
      }
      else
      {
          ImageButton1.ImageUrl = "~/Images/bed-unoccupied.png";
          ViewState["Counter"] = null;
      }
