    public class YourObject
    {
        private readonly ReadOnlyField<object> _someMember;
        public object MemberValue
        {
            get
            {
                if(_someMember.Value == null)
                {
                    _someMember.Value = LoadMember();
                    _someMember.Freeze();
                }
                return _someMember.Value;
            }
        }
        public YourObject()
        {
            _someMember = new ReadOnlyField<object>();
        }
    }
