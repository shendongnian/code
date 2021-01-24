    using System;
    using System.Reflection;
    using System.Runtime.Hosting;
    using System.Security;
    using System.Security.Permissions;
    using System.Security.Policy;
    using System.Windows.Forms;
    using Microsoft.Build.Tasks.Deployment.ManifestUtilities;
    
    
    namespace SecurityDebuggingTest
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main(string[] args)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                if (args.Length > 0 && args[0] == "startui")
                {
                    Application.Run(new Form1());
                }
                else
                {
                    PermissionSet permissions = new PermissionSet(PermissionState.Unrestricted);
                    string AppName = Assembly.GetEntryAssembly().GetName().Name;
                    string AppExe = $"{AppName}.exe";
                    string DebugSecurityZoneURL = $"{AppExe}.manifest";
                    string AppManifestPath = $"{AppName}.application";
                    string appType = "win32";
                    AssemblyIdentity ca = AssemblyIdentity.FromManifest(AppManifestPath);
                    string appIdentitySubString = $"Version={ca.Version}, Culture={ca.Culture}, PublicKeyToken={ca.PublicKeyToken}, ProcessorArchitecture={ca.ProcessorArchitecture}";
                    string assemblyIdentity = $"http://tempuri.org/{AppManifestPath}#{AppManifestPath}, {appIdentitySubString}/{AppExe}, {appIdentitySubString},Type={appType}";
                    System.ApplicationIdentity applicationIdentity = new System.ApplicationIdentity(assemblyIdentity);
    
                    ApplicationTrust appTrust = new ApplicationTrust();
                    appTrust.DefaultGrantSet = new PolicyStatement(permissions, PolicyStatementAttribute.Nothing);
                    appTrust.IsApplicationTrustedToRun = true;
                    appTrust.ApplicationIdentity = applicationIdentity;
    
                    AppDomainSetup adSetup = new AppDomainSetup
                    {
                        ApplicationBase = AppDomain.CurrentDomain.BaseDirectory,
                        ActivationArguments = new ActivationArguments(
                            ActivationContext.CreatePartialActivationContext(
                                applicationIdentity,
                                new string[] { AppManifestPath, DebugSecurityZoneURL })
                        ),
                        ApplicationTrust = appTrust
                    };
    
                    Evidence e = new Evidence();
                    e.AddHostEvidence(appTrust);
    
                    AppDomain a = AppDomain.CreateDomain("Internet Security Zone AppDomain", e, adSetup, permissions);
                    a.ExecuteAssembly(AppExe, e, new string[] { "startui" });
                }
            }
        }
    }
