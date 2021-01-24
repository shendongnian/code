    class Myclass
    {	
       private string _myText;
       public string mystring
       {
          get 
          {
        	 return _myText;
          }
          set 
          {
             _myText = value;
          }
       }
    }
    public void Mymethod()
    {
       Myclass obj = new Myclass();
       obj.mystring = TextBox1.Text.Trim();
       //do what else you want
    }
