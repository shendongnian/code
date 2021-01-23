    using System;
    using System.Collections;
    using System.Configuration.Install;
    using System.Diagnostics;
    using System.IO;
    using System.Security.AccessControl;
    using System.Security.Principal;
    using System.ServiceProcess;
    
    namespace MyService
    {
    	partial class ProjectInstaller
    	{
    		/// <summary>
    		/// Required designer variable.
    		/// </summary>
    		private System.ComponentModel.IContainer components = null;
    
    		/// <summary> 
    		/// Clean up any resources being used.
    		/// </summary>
    		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    		protected override void Dispose(bool disposing)
    		{
    			if (disposing && (components != null))
    			{
    				components.Dispose();
    			}
    			base.Dispose(disposing);
    		}
    
    		#region Component Designer generated code
    
    		/// <summary>
    		/// Required method for Designer support - do not modify
    		/// the contents of this method with the code editor.
    		/// </summary>
    		private void InitializeComponent()
    		{
    			this.MyServiceProcessInstaller = new ServiceProcessInstaller();
    			this.MyServiceInstaller = new ServiceInstaller();
    			// 
    			// MyServiceProcessInstaller
    			// 
    			this.MyServiceProcessInstaller.Account = ServiceAccount.LocalService;
    			this.MyServiceProcessInstaller.Password = null;
    			this.MyServiceProcessInstaller.Username = null;
    			// 
    			// MyServiceInstaller
    			// 
    			this.MyServiceInstaller.Description = "First instance of my service.";
    			this.MyServiceInstaller.DisplayName = "My Service - Instance 1";
    			this.MyServiceInstaller.ServiceName = "MyService-1";
    			this.MyServiceInstaller.StartType = ServiceStartMode.Automatic;
    			this.MyServiceInstaller.Committed += new InstallEventHandler(this.ServiceInstaller_Committed);
    			this.MyServiceInstaller.AfterInstall += new InstallEventHandler(this.ServiceInstaller_AfterInstall);
    			this.MyServiceInstaller.AfterUninstall += new InstallEventHandler(this.ServiceInstaller_AfterUnInstall);
    
    			// 
    			// ProjectInstaller
    			// 
    			this.Installers.AddRange(new Installer[] {
    				this.MyServiceProcessInstaller,
    				this.MyServiceInstaller
    			});
    
    		}
    
    		public override void Install(IDictionary stateSaver)
    		{// This gets the named parameters passed in from your custom action
                string EXEFullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string path = Path.GetDirectoryName(EXEFullPath);   // get installation path
    
                try
                {
                    SetAccess(path);
    
                    string path2 = Path.Combine(Directory.GetParent(path).FullName, "instance2");
                    string EXEFullPath2 = Path.Combine(path2, Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location));
    
    				if (!Directory.Exists(path2))
    				{
    					Directory.CreateDirectory(path2);
    				}
    
    				SetAccess(path2);
    
                    // Get the file contents of the directory to copy.
                    FileInfo[] files = (new DirectoryInfo(path)).GetFiles();
    
    				foreach (FileInfo file in files)
    				{
    					string temppath;
    
                        // Create the path to the new copy of the file.
                        temppath = Path.Combine(path2, file.Name);
    
    					// Copy the file.
                        file.CopyTo(temppath, true);
                    }
    
    				string Instance = "1";
    
    				string Alltext = File.ReadAllText(EXEFullPath + ".config");
    				// Rewrite config file - instance 1
    				Alltext = Alltext.Replace("{Instance}", Instance);
    				File.WriteAllText(EXEFullPath + ".config", Alltext);
    
    				Instance = "2";
    
    				Alltext = File.ReadAllText(EXEFullPath2 + ".config");
    				// Rewrite config file - instance 2
    				Alltext = Alltext.Replace("{Instance}", Instance);
    				File.WriteAllText(EXEFullPath2 + ".config", Alltext);
    			}
    			catch
    			{
    			}
    
    			base.Install(stateSaver);
    		}
    
    		void SetAccess(string dir)
    		{
    			// Create security identifier for Local Service user; Local Service is used for the service at installation
    			SecurityIdentifier sid = new SecurityIdentifier(WellKnownSidType.LocalServiceSid, null);
    			DirectoryInfo di = new DirectoryInfo(dir);
    			DirectorySecurity ds = di.GetAccessControl();
    			// add a new file access rule w/ write/modify for all users to the directory security object
    
    			ds.AddAccessRule(new FileSystemAccessRule(sid,
    												  FileSystemRights.Write | FileSystemRights.Modify,
    												  InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,   // all sub-dirs to inherit
    												  PropagationFlags.None,
    												  AccessControlType.Allow));                                            // Turn write and modify on
    																														// Apply the directory security to the directory
    			di.SetAccessControl(ds);
    		}
    
    		void ServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
    		{// This gets the named parameters passed in from your custom action
                using (ServiceController sc = new ServiceController(MyServiceInstaller.ServiceName))
                {
                    sc.Start();     // start the service (instance 1) after installation
                }
    
                int exitCode;
    
                using (var process = new Process())
    			{
    				var startInfo = process.StartInfo;
    				startInfo.FileName = "sc";
    				startInfo.WindowStyle = ProcessWindowStyle.Hidden;
    
                    string EXEFullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    string path = Path.GetDirectoryName(EXEFullPath);   // get installation path
    
                    string path2 = Path.Combine(Directory.GetParent(path).FullName, "instance2");
                    string EXEFullPath2 = Path.Combine(path2, Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location));
    
    				// tell Windows that the service should restart if it fails
    				startInfo.Arguments = string.Format("create {0} start= auto binPath= \"{1}\" obj= \"{2}\" DisplayName= \"{3}\"", "MyService-2", EXEFullPath2, "NT AUTHORITY\\LocalService", "My Service - Instance 2");
    
    				process.Start();
    				process.WaitForExit();
    
    				exitCode = process.ExitCode;
    			}
    
    			if (exitCode != 0)
    				throw new InvalidOperationException();
    			else
    			{
    				using (var process = new Process())
    				{
    					var startInfo = process.StartInfo;
    					startInfo.FileName = "sc";
    					startInfo.WindowStyle = ProcessWindowStyle.Hidden;
    
    					// Set the service description
    					startInfo.Arguments = string.Format("description {0} \"{1}\"", "MyService-2", "Second instance of My Service.");
    
    					process.Start();
    					process.WaitForExit();
    
    					exitCode = process.ExitCode;
    				}
    
    				if (exitCode != 0)
    					throw new InvalidOperationException();
    			}
    
    			if (exitCode == 0)
    			{
    				using (ServiceController sc = new ServiceController("MyService-2"))
    				{
    					sc.Start();     // start the service (instance 2) after installation
    				}
    			}
    		}
    
    		// right after service is installed, we set Recovery to restart after failures.
    		void ServiceInstaller_Committed(object sender, InstallEventArgs e)
    		{
    			int exitCode;
    
    			using (var process = new Process())
    			{
    				var startInfo = process.StartInfo;
    				startInfo.FileName = "sc";
    				startInfo.WindowStyle = ProcessWindowStyle.Hidden;
    
    				// tell Windows that the service should restart if it fails
    				startInfo.Arguments = string.Format("failure \"{0}\" reset= 0 actions= restart/0", MyServiceInstaller.ServiceName);
    
    				process.Start();
    				process.WaitForExit();
    
    				exitCode = process.ExitCode;
    			}
    
    			if (exitCode != 0)
    				throw new InvalidOperationException();
    			else
    			{
    				using (var process = new Process())
    				{
    					var startInfo = process.StartInfo;
    					startInfo.FileName = "sc";
    					startInfo.WindowStyle = ProcessWindowStyle.Hidden;
    
    					// tell Windows that the service should restart if it fails
    					startInfo.Arguments = string.Format("failure \"{0}\" reset= 0 actions= restart/0", "MyService-2");
    
    					process.Start();
    					process.WaitForExit();
    
    					exitCode = process.ExitCode;
    				}
    			}
    
    			if (exitCode != 0)
    				throw new InvalidOperationException();
    			else
    			{
    				using (var process = new Process())
    				{
    					var startInfo = process.StartInfo;
    					startInfo.FileName = "sc";
    					startInfo.WindowStyle = ProcessWindowStyle.Hidden;
    
    					// reset Manager 1 service permissions
    					startInfo.Arguments = string.Format("sdset {0} \"{1}\"", "MyService-1", "D:(A;;CCLCSWRPWPDTLOCRRC;;;SY)(A;;CCDCLCSWRPWPDTLOCRSDRCWDWO;;;BA)(A;;CCLCSWLOCRRC;;;IU)(A;;CCLCSWLOCRRC;;;SU)(A;;CCLCSWLOCRRCRPWP;;;LS)S:(AU;FA;CCDCLCSWRPWPDTLOCRSDRCWDWO;;;WD)");
    
    					process.Start();
    					process.WaitForExit();
    
    					exitCode = process.ExitCode;
    				}
    
    				if (exitCode != 0)
    					throw new InvalidOperationException();
    			}
    
    			if (exitCode != 0)
    				throw new InvalidOperationException();
    			else
    			{
    				using (var process = new Process())
    				{
    					var startInfo = process.StartInfo;
    					startInfo.FileName = "sc";
    					startInfo.WindowStyle = ProcessWindowStyle.Hidden;
    
    					// reset Manager 2 service permissions
    					startInfo.Arguments = string.Format("sdset {0} \"{1}\"", "MyService-2", "D:(A;;CCLCSWRPWPDTLOCRRC;;;SY)(A;;CCDCLCSWRPWPDTLOCRSDRCWDWO;;;BA)(A;;CCLCSWLOCRRC;;;IU)(A;;CCLCSWLOCRRC;;;SU)(A;;CCLCSWLOCRRCRPWP;;;LS)S:(AU;FA;CCDCLCSWRPWPDTLOCRSDRCWDWO;;;WD)");
    
    					process.Start();
    					process.WaitForExit();
    
    					exitCode = process.ExitCode;
    				}
    
    				if (exitCode != 0)
    					throw new InvalidOperationException();
    			}
    		}
    
    		void ServiceInstaller_AfterUnInstall(object sender, InstallEventArgs e)
    		{// This gets the named parameters passed in from your custom action
    			try
    			{
    				using (ServiceController sc = new ServiceController("MyService-2"))
    				{
    					sc.Stop();     // stop the service (instance 2) after uninstallation
    				}
    			}
    			catch
    			{
    			}
    
    			try
    			{
    				int exitCode;
    
    				using (var process = new Process())
    				{
    					var startInfo = process.StartInfo;
    					startInfo.FileName = "sc";
    					startInfo.WindowStyle = ProcessWindowStyle.Hidden;
    
    					// tell Windows that the service should restart if it fails
    					startInfo.Arguments = string.Format("delete MyService-2");
    
    					process.Start();
    					process.WaitForExit();
    
    					exitCode = process.ExitCode;
    				}
    			}
    			catch
    			{
    			}
    
    			try
    			{
                    string EXEFullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    string path = Path.GetDirectoryName(EXEFullPath);   // get installation path
    
                    string path2 = Path.Combine(Directory.GetParent(path).FullName, "instance2");
                    string EXEFullPath2 = Path.Combine(path2, Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location));
    
    				Directory.Delete(path2, true);
    			}
    			catch
    			{
    			}
    		}
    
    		#endregion
    
    		private System.ServiceProcess.ServiceProcessInstaller MyServiceProcessInstaller;
    		private System.ServiceProcess.ServiceInstaller MyServiceInstaller;
    	}
    }
