    class DbObjectComparer : IEqualityComparer {
        
        public Boolean Equals(DbObject x, DbObject y) {
            
            if( Object.ReferenceEquals( x, y ) ) return true;
            if( (x == null) != (y == null) ) return false;
            if( x == null && y == null ) return true;
             return
                x.DatabaseName.Equals( y.DatabaseName ) &&
                x.SchemaName.Equals( y.SchemaName) &&
                x.ObjectName.Equals( y.ObjectName ) &&
                x.ObjectType.Equals( y.ObjectType);
        }
        public override Int32 GetHashCode(DbObject obj) {
            
            unchecked
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + obj.DatabaseName.GetHashCode();
                hash = hash * 23 + obj.SchemaName.GetHashCode();
                hash = hash * 23 + obj.ObjectName.GetHashCode();
                hash = hash * 23 + obj.ObjectType.GetHashCode();
                return hash;
            }
        }
    }
