    String myline = "Public something";
    int pos = myline.IndexOf(" ");
    if(pos < 0)
    {
      //Error
    }
    String stringYouWant = myline.Substring(0, pos) + " static " + myline.Substring(pos +1);
    Console.WriteLine(stringYouWant);
