    class Key : IEquatable<Key>
    {
        public string fn;
        public int groupId;
        public override bool Equals(object obj)
        {
            Key k = obj as Key;
            if (k == null)
            {
                return false;
            }
            else
            {
                return this.Equals(k);
            }
        }
        public bool Equals(Key other)
        {
            return this.fn == other.fn && this.groupId == other.groupId;
        }
        public override int GetHashCode()
        {
            return fn.GetHashCode() * 13 + groupId.GetHashCode();
        }
    }
