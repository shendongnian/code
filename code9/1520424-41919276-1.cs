    int t;
    if(Int32.TryParse(textbox1.Text, out t)
    {
      // t has ben set with the integer converted
      // add here the code that uses the t variable
    }
    else
    {
      // textbox1.Text doesn't contain a valid integer
      // Add here a message to your users about the wrong input....
      // (if needed)
    }
