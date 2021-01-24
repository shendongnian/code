    [TestFixture]
    public class SecurityCriticalAccessTest
    {
        private partial class Sandbox : MarshalByRefObject
        {
        }
        private static AppDomain CreateSandboxDomain(params IPermission[] permissions)
        {
            var evidence = new Evidence(AppDomain.CurrentDomain.Evidence);
            var permissionSet = GetPermissionSet(permissions);
            var setup = new AppDomainSetup
            {
                ApplicationBase = AppDomain.CurrentDomain.BaseDirectory,
            };
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var strongNames = new List<StrongName>();
            foreach (Assembly asm in assemblies)
            {
                AssemblyName asmName = asm.GetName();
                strongNames.Add(new StrongName(new StrongNamePublicKeyBlob(asmName.GetPublicKey()), asmName.Name, asmName.Version));
            }
            return AppDomain.CreateDomain("SandboxDomain", evidence, setup, permissionSet, strongNames.ToArray());
        }
        private static PermissionSet GetPermissionSet(IPermission[] permissions)
        {
            var evidence = new Evidence();
            evidence.AddHostEvidence(new Zone(SecurityZone.Internet));
            var result = SecurityManager.GetStandardSandbox(evidence);
            foreach (var permission in permissions)
                result.AddPermission(permission);
            return result;
        }
    }
