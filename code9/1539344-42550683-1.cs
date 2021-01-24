    class Permission
    {
        public override bool Equals(object obj)
        {
            var p = obj as Permission;
            if(p == null) return false;
            return this.PermissionID == p.PermissionID;
        }
        public override int GetHashCode()
        {
            return this.PermissionID .GetHashCode();
        }
    }
