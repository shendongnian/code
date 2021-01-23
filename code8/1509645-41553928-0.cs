      // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var data = (accessoire)obj;
            return this.Ref.Equals(data.Ref);
        }
        // override object.GetHashCode
        public override int GetHashCode()
        {
            
            return this.Ref.GetHashCode()
        }
