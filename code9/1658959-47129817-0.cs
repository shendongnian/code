    private string myText;
    public string MyText
    {
       get
       {
           return myText;
       }
       set
       {
           if (Set(nameof (MyText), ref myText, value))
           {
                // the value of the text box changed.. do something here?
           }
       }
    }
