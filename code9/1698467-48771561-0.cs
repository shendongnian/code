        public class EntityChange : Entity<long>, IMayHaveTenant
        {
            /// <summary>
            /// Gets/sets change set id, used to group entity changes.
            /// </summary>
            public virtual long EntityChangeSetId { get; set; }
            // ...
        }
