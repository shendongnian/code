            // override object.Equals
    public override bool Equals(object obj)
        {
            // shortcut
            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }
            // check for null and make sure we do not break oop / inheritance
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            // TODO: write your implementation of Equals() here
            // do not call base.equals !		
            throw new NotImplementedException();
            return false;
        }
        public static bool operator ==(Class lobj, Class robj)
        {
            // users expect == working the same way as Equals
            return object.Equals(lobj, robj);
        }
        public static bool operator !=(Class lobj, Class robj)
        {
            return !object.Equals(lobj, robj);
        }
        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            // return field.GetHashCode() ^ field2.GetHashCode() ^ base.GetHashCode();
            // or simply return the unique id if any
            throw new NotImplementedException();
        }
