    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.ServiceProcess;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace WindowsServiceUtility
    {
        public partial class frmMain : Form
        {
            bool _correctServiceName = true;
            private string _serviceState;
            public frmMain()
            {
                InitializeComponent();
            }
    
            private void btnChooseServiceFile_Click(object sender, EventArgs e)
            {
                var dlg = new OpenFileDialog
                {
                    Filter = @"Application |*.exe",
                    RestoreDirectory = true,
                    CheckFileExists = false,
                    Title = @"Choose Application.."
                };
    
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    tbxServicePath.Text = dlg.FileName;
                    tbxServiceName.Text = Path.GetFileNameWithoutExtension(dlg.FileName);
                }
                _serviceState = CheckServiceState(tbxServiceName.Text);
                lblServiceState.Text = @"Service is " + _serviceState;
                lblServiceState.ForeColor = _serviceState == "Invalid."
                    ? Color.Gray
                    : _serviceState == "Running"
                        ? Color.Green
                        : Color.DarkRed;
            }
    
            private string CheckServiceState(string serviceName)
            {
                try
                {
                    if (string.IsNullOrEmpty(tbxServiceName.Text.Trim()))
                        return "undefined";
                    if (ServiceController.GetServices().FirstOrDefault(record => record.ServiceName == serviceName) == null)
                        _correctServiceName = false; 
                    else _correctServiceName = true;
                }
                catch (ArgumentException)
                {
                    return "Invalid.";
                }
    
                if (!_correctServiceName) return "Invalid.";
    
                var sc = new ServiceController(serviceName);
                using (sc)
                {
                    ServiceControllerStatus status;
                    try
                    {
                        sc.Refresh();
                        status = sc.Status;
                    }
                    catch (Win32Exception ex)
                    {
                        return "Error: " + ex.Message;
                    }
    
                    switch (status)
                    {
                        case ServiceControllerStatus.Running:
                            return "Running";
                        case ServiceControllerStatus.Stopped:
                            return "Stopped";
                        case ServiceControllerStatus.Paused:
                            return "Paused";
                        case ServiceControllerStatus.StopPending:
                            return "Stopping";
                        case ServiceControllerStatus.StartPending:
                            return "Starting";
                        default:
                            return "Status Changing";
                    }
                }
            }
    
            private void btnCheckServiceState_Click(object sender, EventArgs e)
            {
                _serviceState = CheckServiceState(tbxServiceName.Text);
                lblServiceState.Text = @"Service is " + _serviceState;
                lblServiceState.ForeColor = _serviceState == "Invalid."
                    ? Color.Gray
                    : _serviceState == "Running"
                        ? Color.Green
                        : Color.DarkRed;
            }
    
            private void btnInstall_Click(object sender, EventArgs e)
            {
                try
                {
                    if (string.IsNullOrEmpty(tbxServicePath.Text.Trim()))
                        throw new Exception("Invalid service path");
    
                    if (_correctServiceName)
                        throw new Exception("Service already installed. You can't install before uninstall this service");
    
                    if (_serviceState == "Running" || _serviceState == "Stopped"
                        || _serviceState == "Paused" || _serviceState == "Stopping"
                        || _serviceState == "Starting" || _serviceState == "Status Changing")
                        throw new Exception("Service already installed. You can't install before uninstall this service");
    
                    InstallUninstallService(true);
    
                    Application.DoEvents();
                    Thread.Sleep(5000);
    
                    _serviceState = CheckServiceState(tbxServiceName.Text);
                    lblServiceState.Text = @"Service is " + _serviceState;
                    lblServiceState.ForeColor = _serviceState == "Invalid."
                        ? Color.Gray
                        : _serviceState == "Running"
                            ? Color.Green
                            : Color.DarkRed;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
    
            private void ChangeServiceState(string serviceName, bool start)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo =
                        new System.Diagnostics.ProcessStartInfo
                        {
                            WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                            FileName = "cmd.exe",
                            Verb = "runas",
                            Arguments = "/user:Administrator /K " + (start ? "net start " : "net stop ") + serviceName
                        };
                    process.StartInfo = startInfo;
                    process.Start();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
    
            private void InstallUninstallService(bool install)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo =
                        new System.Diagnostics.ProcessStartInfo
                        {
                            WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                            FileName = "cmd.exe",
                            Verb = "runas",
                            Arguments = "/user:Administrator /K " + Environment.GetEnvironmentVariable("windir") +
                                        "\\Microsoft.NET\\Framework"
                                        + (cbxPlatform.SelectedText == "X86" ? string.Empty : "64") +
                                        "\\v4.0.30319\\installutil "
                                        + (install ? string.Empty : "/u ") + tbxServicePath.Text.Trim()
                        };
                    process.StartInfo = startInfo;
                    process.Start();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
                finally
                {
                    if (cxStartAfter.Checked && install)
                        ChangeServiceState(tbxServiceName.Text.Trim(), true);
                }
            }
    
            private void btnUninstall_Click(object sender, EventArgs e)
            {
                try
                {
                    if (string.IsNullOrEmpty(tbxServicePath.Text.Trim()))
                        throw new Exception("Invalid service path");
    
                    if (_serviceState == "Running" || _serviceState == "Stopped"
                        || _serviceState == "Paused" || _serviceState == "Stopping"
                        || _serviceState == "Starting" || _serviceState == "Status Changing")
                    {
                        InstallUninstallService(false);
    
                        Application.DoEvents();
    
                        Thread.Sleep(5000);
    
                        _serviceState = CheckServiceState(tbxServiceName.Text);
                        lblServiceState.Text = @"Service is " + _serviceState;
                        lblServiceState.ForeColor = _serviceState == "Invalid."
                            ? Color.Gray
                            : _serviceState == "Running"
                                ? Color.Green
                                : Color.DarkRed;
                    }
                        
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
    
            private void frmMain_Load(object sender, EventArgs e)
            {
                cbxPlatform.SelectedIndex = 1;
            }
        }
    }
