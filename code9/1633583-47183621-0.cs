    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Management;
    
    class Program
    {
        static void Main(string[] args)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = "YourApplication.exe" // path to your application
            });
    
            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                Process process = Process.GetProcessesByName("YourApplication").FirstOrDefault();  // your application's process name
                if (process == null)
                {
                    Console.WriteLine($"Process is not running...");
                    continue;
                }
                ProcessManager pm = ProcessManager.FromLocalMachine();
                var processProperties = pm.GetProcessProperties(process.Id);
                int parentProcessId = Convert.ToInt32(processProperties[EProcessProperty.ParentProcessId]);
    
                try
                {
                    var parentProcessProperties = pm.GetProcessProperties(parentProcessId);
                    string parentProcessName = parentProcessProperties[EProcessProperty.Name].ToString();
                    Console.WriteLine($"Parent process '{parentProcessName ?? "Unknown"}' [PID={parentProcessId}]");
                    Console.WriteLine("---------------------------------");
                }
                catch { Console.WriteLine("Parent process information not found."); }
            }
        }
    }
    
    public class ProcessConnection
    {
        internal ManagementScope ManagementScope { get; }
    
        internal ProcessConnection(string machineName, string user = null, string password = null, string domain = null)
        {
            ManagementScope = new ManagementScope
            {
                Path = new ManagementPath(@"\\" + machineName + @"\root\CIMV2"),
                Options = new ConnectionOptions
                {
                    Impersonation = ImpersonationLevel.Impersonate,
                    Authentication = AuthenticationLevel.Default,
                    EnablePrivileges = true,
                    Username = user == null ? null : (string.IsNullOrWhiteSpace(domain) ? user : $"{domain}\\{user}"),
                    Password = user == null ? null : password,
                },
            };
            ManagementScope.Connect();
        }
    }
    
    public class ProcessManager
    {
        public static ProcessManager FromLocalMachine() => new ProcessManager()
        {
            Machine = Environment.MachineName,
        };
    
        public static ProcessManager FromRemoteMachine(string machine, string user = null, string password = null, string domain = null) => new ProcessManager()
        {
            Machine = machine,
            User = user,
            Password = password,
            Domain = domain,
        };
    
        private ProcessManager() { }
    
        public string Machine { get; private set; }
        public string User { get; private set; }
        public string Password { get; private set; }
        public string Domain { get; private set; }
    
        private ProcessConnection Connection { get; set; }
        private ManagementScope ManagementScope => Connection == null ? (Connection = new ProcessConnection(Machine, User, Password, Domain)).ManagementScope : Connection.ManagementScope;
    
        public EProcessStartStatus StartProcess(string processPath)
        {
            ManagementClass mc = new ManagementClass($"\\\\{Machine}\\root\\CIMV2", "Win32_Process", null);
            ManagementBaseObject process = mc.GetMethodParameters("Create");
            process["CommandLine"] = processPath;
            ManagementBaseObject createCode = mc.InvokeMethod("Create", process, null);
            string createCodeStr = createCode["ReturnValue"].ToString();
            return (EProcessStartStatus)Convert.ToInt32(createCodeStr);
        }
    
        public bool KillProcess(string processName)
        {
            try
            {
                SelectQuery query = new SelectQuery($"SELECT * FROM Win32_Process WHERE Name = '{processName}'");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(ManagementScope, query);
                foreach (ManagementObject mo in searcher.Get()) mo.InvokeMethod("Terminate", null);
                return true;
            }
            catch { return false; }
        }
    
        public bool KillProcess(int processId)
        {
            try
            {
                SelectQuery query = new SelectQuery($"SELECT * FROM Win32_Process WHERE ProcessId = '{processId}'");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(ManagementScope, query);
                foreach (ManagementObject mo in searcher.Get()) mo.InvokeMethod("Terminate", null);
                return true;
            }
            catch { return false; }
        }
    
        public void SetProcessPriority(string processName, EProcessPriority priority)
        {
            SelectQuery query = new SelectQuery($"SELECT * FROM Win32_Process WHERE Name = '{processName}'");
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(ManagementScope, query);
            foreach (ManagementObject managementObject in managementObjectSearcher.Get())
            {
                ManagementBaseObject methodParams = managementObject.GetMethodParameters("SetPriority");
                methodParams["Priority"] = priority;
                managementObject.InvokeMethod("SetPriority", methodParams, null);
            }
        }
    
        public string GetProcessOwner(string processName)
        {
            SelectQuery query = new SelectQuery($"SELECT * FROM Win32_Process WHERE Name = '{processName}'");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(ManagementScope, query);
            foreach (ManagementObject mo in searcher.Get())
            {
                ManagementBaseObject methodParams = mo.GetMethodParameters("GetOwner");
                ManagementBaseObject owner = mo.InvokeMethod("GetOwner", null, null);
                return owner["User"].ToString();
            }
            return null;
        }
    
        public string GetProcessOwnerSID(string processName)
        {
            SelectQuery query = new SelectQuery($"SELECT * FROM Win32_Process WHERE Name = '{processName}'");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(ManagementScope, query);
            foreach (ManagementObject mo in searcher.Get())
            {
                ManagementBaseObject methodParams = mo.GetMethodParameters("GetOwnerSid");
                ManagementBaseObject OwnerSid = mo.InvokeMethod("GetOwnerSid", null, null);
                return OwnerSid["Sid"].ToString();
            }
            return null;
        }
    
        public IList<int> GetRunningProcesses()
        {
            IList<int> processes = new List<int>();
            SelectQuery query = new SelectQuery("SELECT * FROM Win32_Process");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(ManagementScope, query);
            foreach (ManagementObject mo in searcher.Get()) processes.Add(int.Parse(mo["ProcessId"].ToString()));
            return processes;
        }
    
        public IDictionary<EProcessProperty, object> GetProcessProperties(int processId)
        {
            SelectQuery query = new SelectQuery($"SELECT * FROM Win32_Process WHERE ProcessId = '{processId}'");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(ManagementScope, query);
    
            Dictionary<EProcessProperty, object> properties = new Dictionary<EProcessProperty, object>();
            foreach (ManagementObject mo in searcher.Get())
            {
                foreach (PropertyData pd in mo.Properties)
                {
                    if (Enum.TryParse(pd.Name, out EProcessProperty e)) properties[e] = pd.Value;
                    else Console.WriteLine(pd.Name + " is not mapped in the properties enumeration.");
                }
            }
            return properties;
        }
    
        public IDictionary<EProcessProperty, object> GetProcessProperties(string processName)
        {
            SelectQuery query = new SelectQuery($"SELECT * FROM Win32_Process WHERE Name = '{processName}'");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(ManagementScope, query);
    
            Dictionary<EProcessProperty, object> properties = new Dictionary<EProcessProperty, object>();
            foreach (ManagementObject mo in searcher.Get())
            {
                foreach (PropertyData pd in mo.Properties)
                {
                    if (Enum.TryParse(pd.Name, out EProcessProperty e)) properties[e] = pd.Value;
                    else Console.WriteLine(pd.Name + " is not mapped in the properties enumeration.");
                }
            }
            return properties;
        }
    
        public IList<int> GetProcessessFromExecutablePath(string executablePath)
        {
            SelectQuery query = new SelectQuery($"SELECT * FROM Win32_Process WHERE ExecutablePath = '{executablePath.Replace("\\", "\\\\")}'");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(ManagementScope, query);
            return searcher.Get().Cast<ManagementObject>().Select(mo => Convert.ToInt32(mo["ProcessId"])).ToList();
        }
    
    }
    
    public enum EProcessPriority : uint
    {
        IDLE = 0x40,
        BELOW_NORMAL = 0x4000,
        NORMAL = 0x20,
        ABOVE_NORMAL = 0x8000,
        HIGH_PRIORITY = 0x80,
        REALTIME = 0x100
    }
    
    public enum EProcessStartStatus
    {
        Success = 0,
        AccessDenied = 2,
        NoPermissions = 3,
        Unknown = 8,
        FileNotFound = 9,
        Invalid = 21,
    }
    
    public enum EProcessProperty
    {
        Caption,
        CommandLine,
        CreationClassName,
        CreationDate,
        CSCreationClassName,
        CSName,
        Description,
        ExecutablePath,
        ExecutionState,
        Handle,
        HandleCount,
        InstallDate,
        KernelModeTime,
        MaximumWorkingSetSize,
        MinimumWorkingSetSize,
        Name,
        OSCreationClassName,
        OSName,
        OtherOperationCount,
        OtherTransferCount,
        PageFaults,
        PageFileUsage,
        ParentProcessId,
        PeakPageFileUsage,
        PeakVirtualSize,
        PeakWorkingSetSize,
        Priority,
        PrivatePageCount,
        ProcessId,
        QuotaNonPagedPoolUsage,
        QuotaPagedPoolUsage,
        QuotaPeakNonPagedPoolUsage,
        QuotaPeakPagedPoolUsage,
        ReadOperationCount,
        ReadTransferCount,
        SessionId,
        Status,
        TerminationDate,
        ThreadCount,
        UserModeTime,
        VirtualSize,
        WindowsVersion,
        WorkingSetSize,
        WriteOperationCount,
        WriteTransferCount,
    }
