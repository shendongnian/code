    [PSerializable]
    public class TimingAspectProvider : MethodLevelAspect, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            MethodBase targetMethod = (MethodBase) targetElement;
            IAspectRepositoryService aspectRepositoryService = PostSharpEnvironment.CurrentProject.GetService<IAspectRepositoryService>();
            TimingAspect aspect = new TimingAspect();
            MethodUsageCodeReference[] usages = ReflectionSearch.GetDeclarationsUsedByMethod(targetMethod);
            foreach (MethodUsageCodeReference codeReference in usages.Where(u => u.UsedDeclaration.MemberType == MemberTypes.Method))
            {
                if (!aspectRepositoryService.HasAspect(codeReference.UsedDeclaration, typeof(TimingAspect)))
                {
                    yield return new AspectInstance(codeReference.UsedDeclaration, aspect);
                }
            }
        }
    }
