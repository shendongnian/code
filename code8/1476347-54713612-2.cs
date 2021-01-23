      var security = new FileSecurity(fileSystemInfoFullName, 
                AccessControlSections.Owner | 
                AccessControlSections.Group |
                AccessControlSections.Access);
**2. Get the authorization rules:**
var authorizationRules = security.GetAccessRules(true, true, typeof(NTAccount));
**3. Get the authorization rules for the owner:**
var owner = security.GetOwner(typeof(NTAccount));
foreach (AuthorizationRule rule in authorizationRules)
{
	FileSystemAccessRule fileRule = rule as FileSystemAccessRule;
	if (fileRule != null)
	{
		if (owner != null && fileRule.IdentityReference == owner)
		{
			 if (fileRule.FileSystemRights.HasFlag(FileSystemRights.ExecuteFile) ||
                fileRule.FileSystemRights.HasFlag(FileSystemRights.ReadAndExecute) ||
                fileRule.FileSystemRights.HasFlag(FileSystemRights.FullControl))
            {
                ownerRights.IsExecutable = true;
            }
		}
		else if (group != null && fileRule.IdentityReference == group)
		{
			// TO BE CONTINUED...
		}
	}
}
**4. Add a rule for owner:**
security.ModifyAccessRule(AccessControlModification.Add,
	new FileSystemAccessRule(owner, FileSystemRights.Modify, AccessControlType.Allow),
	out bool modified);
**5. Bonus**
How to get the `group` and `others`, or ... my definition of something equivalent ?
var group = security.GetGroup(typeof(NTAccount));
var others = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null)
                 .Translate(typeof(NTAccount));
*Note: This code comes from my open source project [Lx.Shell][1]*
  [1]: https://github.com/leoxialtd/Leoxia.Shell
