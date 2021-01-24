    [DuplicateAspect]
    public class TargetClass
    {
        public int MyMethod()
        {
            return 42;
        }
    }
    [PSerializable]
    public class DuplicateAspect : TypeLevelAspect, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            Type targetType = (Type)targetElement;
            foreach (MethodInfo method in targetType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                yield return new AspectInstance(targetType, new DuplicateSingle(method));
            }
        }
    }
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
            yield return new ImportMethodAdviceInstance(field, this.sourceMethod.Name, false, ImportMemberOrder.BeforeIntroductions);
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
