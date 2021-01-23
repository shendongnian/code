      internal class AllExceptNonPublicPropertiesSelectionRule : IMemberSelectionRule
      {
        public bool IncludesMembers
        {
          get { return false; }
        }
    
        public IEnumerable<SelectedMemberInfo> SelectMembers(
          IEnumerable<SelectedMemberInfo> selectedMembers,
          ISubjectInfo context,
          IEquivalencyAssertionOptions config)
        {
          return selectedMembers.Except(
            config.GetSubjectType(context)
              .GetNonPrivateProperties()
              .Where(p => p.GetMethod.IsAssembly)
              .Select(SelectedMemberInfo.Create));
        }
      }
