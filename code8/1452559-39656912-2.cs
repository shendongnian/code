    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Management;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                var query = new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace WHERE ProcessName = 'Notepad.exe'");
                var mew = new ManagementEventWatcher(query) {Query = query};
                mew.EventArrived += (sender, args) => { notepadStarted(); };
                mew.Start();
            }
            void notepadStarted()
            {
                BeginInvoke(new Action(pasteIntoNotepad));
            }
            [DllImport("User32", CharSet = CharSet.Auto)]
            public static extern int ShowWindow(IntPtr hWnd, int cmdShow);
                               
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool IsIconic(IntPtr hwnd);
            [DllImport("user32.dll")]
            public static extern int SetForegroundWindow(IntPtr hWnd);
            void pasteIntoNotepad()
            {
                var notepad = Process.GetProcessesByName("Notepad").FirstOrDefault(p => p.MainWindowTitle == "Untitled - Notepad");
                if (notepad != null)
                {
                    notepad.WaitForInputIdle();
                    if (IsIconic(notepad.MainWindowHandle))
                        ShowWindow(notepad.MainWindowHandle, 9);
                    SetForegroundWindow(notepad.MainWindowHandle);
                    Clipboard.SetText("Here's some text to paste\r\ninto the Notepad window");
                    SendKeys.Send("^V");
                }
            }
        }
    }
