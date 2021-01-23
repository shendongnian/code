    public class AccessibleLabel : Label
        {
        protected override AccessibleObject CreateAccessibilityInstance()
            {
            return new LabelAccessibleObject(this);
            }
        public string AccessibleValue { get; set; }
        private class LabelAccessibleObject : ControlAccessibleObject
            {
            private AccessibleLabel myowner;
            public LabelAccessibleObject(AccessibleLabel owner)
                : base(owner)
                {
                this.myowner = owner;
                }
            public override AccessibleRole Role
                {
                get
                    {
                    AccessibleRole accessibleRole = base.Owner.AccessibleRole;
                    if (accessibleRole != AccessibleRole.Default)
                        {
                        return accessibleRole;
                        }
                    return AccessibleRole.StaticText;
                    }
                }
            public override string Value
                {
                get
                    {
                    if (string.IsNullOrEmpty(myowner.AccessibleValue))
                        {
                        return base.Value;
                        }
                    else
                        {
                        return myowner.AccessibleValue;
                        }
                    }
                set
                    {
                    base.Value = value;
                    }
                }
            }
        }
