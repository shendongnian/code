    class LivesCounter : DirtyClass
    {
       private int _lives;
       public int Lives  
       {
          get { return _lives; }
          set { ChangeProperty(ref _lives, value); }
       }
    }
