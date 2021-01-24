    public class DbObject : IEquatable<DbObject> {
        
        public override Int32 GetHashCode() {
            
            // See https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
            
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + this.DatabaseName.GetHashCode();
                hash = hash * 23 + this.SchemaName.GetHashCode();
                hash = hash * 23 + this.ObjectName.GetHashCode();
                hash = hash * 23 + this.ObjectType.GetHashCode();
                return hash;
            }
        }
        public override Boolean Equals(Object other) {
            
            return this.Equals( other as DbObject );    
        }
        public Boolean Equals(DbObject other) {
            
            if( other == null ) return false;
            return
                this.DatabaseName.Equals( other.DatabaseName ) &&
                this.SchemaName.Equals( other.SchemaName) &&
                this.ObjectName.Equals( other.ObjectName ) &&
                this.ObjectType.Equals( other.ObjectType);
        }
    }
