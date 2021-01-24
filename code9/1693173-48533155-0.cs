    public List<string> Books { 
       get{ return value; }
       set { if (Books == null || value == null) {
                Books = new List<string>(); 
           } else { Books = value; }
       }
    }
