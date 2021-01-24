    public List<string> Books { 
       get{ return value; }
       set { if (Books == null) {
                Books = new List<string>(); 
           } else { Books = value; }
       }
    }
