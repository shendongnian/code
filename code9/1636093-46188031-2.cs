    [AttributeUsageAttribute(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    class CheckboxIsCheckedAttribute : RequiredAttribute {
        
        public override bool IsValid(Object value) {
            
            Boolean isRequiredValid = base.IsValid( value );
            if( !isRequiredValid ) return false;
            return (value as Boolean) == true;
        }
    }
