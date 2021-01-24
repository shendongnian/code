    class abc
    {
        public string firstName {get;set;}
        public string lastName {get;set;}
    
        // custom equality comparer
        public override bool Equals(object other) 
        {
            if ( other is abc )
            {
               abc comparer = other as abc;
               if ( comparer != null )
               {
                   return string.Equals(comparer.firstName, this.firstName)
                          &&
                          string.Equals(comparer.lastName, this.lastName);
               }
            }
            return base.Equals(other);
        }
    }
