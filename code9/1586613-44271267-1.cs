    [DuplicateAspect]
    public class TargetClass
    {
        public int MyMethod()
        {
            return 42;
        }
    }
    // We want the aspect to apply to types and provide other aspects.
    [PSerializable]
    public class DuplicateAspect : TypeLevelAspect, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            Type targetType = (Type)targetElement;
            foreach (MethodInfo method in targetType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                // For each public instance method declared in the target type, apply an aspect that duplicates a single method.
                yield return new AspectInstance(targetType, new DuplicateSingle(method));
            }
        }
    }
    // We want the aspect to be instance-scoped and provide advices.
    [PSerializable]
    public class DuplicateSingle : IAspect, IInstanceScopedAspect, IAdviceProvider
    {
        private MethodInfo sourceMethod;
        public Func<int> Method;
        public DuplicateSingle(MethodInfo sourceMethod)
        {
            this.sourceMethod = sourceMethod;
        }
        public IEnumerable<AdviceInstance> ProvideAdvices(object targetElement)
        {
            Type targetType = (Type)targetElement;
            FieldInfo field = typeof(DuplicateSingle).GetField(nameof(Method));
            MethodInfo method = typeof(DuplicateSingle).GetMethod(nameof(IntroducedMethod));
            // Provide import method advices, which stores delegate into a field of the aspect upon instance creation (remember - instance scoped aspect).
            yield return new ImportMethodAdviceInstance(field, this.sourceMethod.Name, false, ImportMemberOrder.BeforeIntroductions);
            // Provide introduce method advice, which introduces a stub calling the aspect method into the target class.
            // PROBLEM: It's not possible to rename the method, hence this will fail.
            yield return new IntroduceMethodAdviceInstance(method, PostSharp.Reflection.Visibility.Public, false, MemberOverrideAction.Fail);
        }       
        public object CreateInstance(AdviceArgs adviceArgs)
        {
            return new DuplicateSingle(this.sourceMethod);
        }
        public void RuntimeInitializeInstance()
        {
        }
        public int IntroducedMethod()
        {
            return this.Method() * 2;
        }
    }
