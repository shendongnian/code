        public class Group : BaseEntity
        {
            public virtual int GroupId { get; set; }
            public virtual string PasswordHash { get; set; }
            public virtual ISet<BaseEntity> Members { get; set; }
        }
