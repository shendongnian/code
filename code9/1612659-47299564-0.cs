    using System;
    using System.ComponentModel;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Threading;
    using System.Runtime.InteropServices;
    
    namespace ProcessTest
    {
        public partial class Form1 : Form
        {
            [DllImport("Shlwapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern uint AssocQueryString(AssocF flags, AssocStr str, string pszAssoc, string pszExtra, [Out] StringBuilder pszOut, ref uint pcchOut);
    
            /*Modified Process.Start*/
            public static Process TrueProcessStart(string filename)
            {
                ProcessStartInfo psi;
                string ext = System.IO.Path.GetExtension(filename);//get extension
    
                var sb = new StringBuilder(500);//buffer for exe file path
                uint size = 500;//buffer size
    
                /*Get associated app*/
                uint res = AssocQueryString(AssocF.None, AssocStr.Executable, ext,null, sb, ref size);
    
                if (res != 0)
                {
                    Debug.WriteLine("AssocQueryString returned error: " + res.ToString("X"));
                    psi = new ProcessStartInfo(filename);//can't get app, use standard method
                }
                else
                {
                    psi = new ProcessStartInfo(sb.ToString(), filename);
                }
    
                return Process.Start(psi);//actually start process
            }
    
            public Form1()
            {
                InitializeComponent();
            }
            
            private void button2_Click(object sender, EventArgs e)
            {            
                string filename = "c:\\images\\clip.wmv";
    
                var myProc = TrueProcessStart(filename);
                if (myProc == null)
                {
                    MessageBox.Show("Process can't be killed");
                    return;
                }
    
                Thread.Sleep(5000);
                try
                {
                    myProc.Kill(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    
        [Flags]
        enum AssocF : uint
        {
            None = 0,
            Init_NoRemapCLSID = 0x1,
            Init_ByExeName = 0x2,
            Open_ByExeName = 0x2,
            Init_DefaultToStar = 0x4,
            Init_DefaultToFolder = 0x8,
            NoUserSettings = 0x10,
            NoTruncate = 0x20,
            Verify = 0x40,
            RemapRunDll = 0x80,
            NoFixUps = 0x100,
            IgnoreBaseClass = 0x200,
            Init_IgnoreUnknown = 0x400,
            Init_FixedProgId = 0x800,
            IsProtocol = 0x1000,
            InitForFile = 0x2000,
        }
    
        enum AssocStr
        {
            Command = 1,
            Executable,
            FriendlyDocName,
            FriendlyAppName,
            NoOpen,
            ShellNewValue,
            DDECommand,
            DDEIfExec,
            DDEApplication,
            DDETopic,
            InfoTip,
            QuickTip,
            TileInfo,
            ContentType,
            DefaultIcon,
            ShellExtension,
            DropTarget,
            DelegateExecute,
            SupportedUriProtocols,
            Max,
        }
    
    
    }
