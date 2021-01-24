    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;
    
    namespace YourAddin.Namespace {
    	// These GUIDS and command IDs must match the VSCT.
    	[ProvideMenuResource("Menus.ctmenu", 1)]
    	[Guid("«Package GUID»")]
    	[PackageRegistration(UseManagedResourcesOnly = true)]
    	class YourAddinPackage : Package {
    	}
    
    	[Guid("«Command Group GUID»")]
    	enum YourAddinCommand {
    		MyCommand = 0
    	}
    }
