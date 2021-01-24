        public class UserOverride : IAutoMappingOverride<User>
        {
            public void Override(AutoMapping<User> mapping)
            {
                mapping.DynamicUpdate();
            }
        }
