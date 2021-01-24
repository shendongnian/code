    public YourClass
    {  
      Dictionary<string, int> MyDictionary {get; set;}
    
       public void wordSearchButton_Click(object sender, EventArgs e)
         {
            if(MyDictionary != null )
            {
               word_search(MyDictionary );
            }
         }
    }
