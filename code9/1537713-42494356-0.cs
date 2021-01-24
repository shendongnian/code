    [Serializable]
    [AttributeUsage(AttributeTargets.Class)]
    [MulticastAttributeUsage(Inheritance = MulticastInheritance.Multicast)]
    internal class EnforceMaxLifetimePolicyAttribute : OnMethodBoundaryAspect
    {
        public override bool CompileTimeValidate(MethodBase method)
        {
            var type = method.DeclaringType;
            
            var lifetimePolicy = GetCustomAttribute(type, typeof(LifetimePolicyAttribute)) as LifetimePolicyAttribute;
            
            if (lifetimePolicy.Hours + lifetimePolicy.Minutes / 60 > 24)
            {
                throw new InvalidAnnotationException($"Lifetimes can not exceed 24 hours. The lifetime on {type.FullName} is invalid.");
            }
            return true;
        }
    }
