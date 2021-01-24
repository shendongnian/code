        public class ClassConvention : IClassConvention
        {
            public void Apply(IClassInstance instance)
            {
                instance.DynamicUpdate();
            }
        }
