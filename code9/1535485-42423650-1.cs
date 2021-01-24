    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace ApiMessageTest2
    {
        public partial class Form1 : Form
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern IntPtr FindWindow(string sClass, string sWindow);
    
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern uint RegisterWindowMessage(string lpString);
    
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            static extern int SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    
            [DllImport("user32.dll")]
            static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern uint GlobalGetAtomName(ushort nAtom, StringBuilder lpBuffer, int nSize);
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                TestQC();
            }
    
            IntPtr nWinHandle;
    
            Dictionary<string, uint> CommandMsgs = new Dictionary<string, uint>();
            Dictionary<uint, string> NotificationMsgs = new Dictionary<uint, string>();
            Dictionary<uint, string> AllMsgs = new Dictionary<uint, string>();
    
            public void RegisterMessages()
            {
                List<string> Commands = new List<string> {
                    "QCOLLECTOR_CLIENT_DATA_REQUEST",
                    "QCOLLECTOR_CLIENT_PORTFOLIO_LIST_REQUEST",
                    "QCOLLECTOR_CLIENT_PORTFOLIO_ITEMS_REQUEST",
                    "QCOLLECTOR_CLIENT_REALTIME_SYMBOL_LIST_REQUEST",
                    "QCOLLECTOR_CLIENT_REMOVE_REALTIME_SYMBOL_REQUEST",
                    "QCOLLECTOR_DELETE_PORTFOLIO_ITEM",
                    "QCOLLECTOR_CLIENT_CLEAR_REALTIME_SYMBOLS",
                    "QCOLLECTOR_REGISTER_FOR_FILE_UPDATES",
                    "QCOLLECTOR_UNREGISTER_FOR_FILE_UPDATES",
                    "QCOLLECTOR_REGISTER_FOR_LAST_RECORD_UPDATE",
                    "QCOLLECTOR_UNREGISTER_FOR_LAST_RECORD_UPDATE"};
    
                foreach (var MsgName in Commands)
                {
                    uint msg = RegisterWindowMessage(MsgName);
                    if (msg != 0)
                    {
                        CommandMsgs.Add(MsgName, msg);
                        AllMsgs.Add(msg, MsgName);
                    }
                }
    
                List<string> Notifications = new List<string> {
                    "QCOLLECTOR_PORTFOLIO_LIST_REQUEST_COMPLETE",
                    "QCOLLECTOR_PORTFOLIO_ITEMS_REQUEST_COMPLETE",
                    "QCOLLECTOR_REALTIME_SYMBOL_LIST_REQUEST_COMPLETE",
                    "QCOLLECTOR_DATA_REQUEST_COMPLETE",
                    "QCOLLECTOR_FILE_UPDATE",
                    "QCOLLECTOR_ALL_FILES_UPDATED",
                    "QCOLLECTOR_LAST_RECORD_UPDATE"};
                foreach (var MsgName in Notifications)
                {
                    uint msg = RegisterWindowMessage(MsgName);
                    if (msg)
                    {
                        NotificationMsgs.Add(msg, MsgName);
                        AllMsgs.Add(msg, MsgName);
                    }
                }
            }
    
            public void ShowMessages()
            {
                var sortedMsgs = AllMsgs.OrderBy(x => x.Key);
    
                foreach (var pair in sortedMsgs)
                {
                    Console.WriteLine($"{pair.Value.ToString()}: {pair.Key}");
                }
            }
    
            public void TestQC()
            {    
                RegisterMessages();
                ShowMessages();
                System.Diagnostics.Process proc = Process.GetCurrentProcess();
    
                try
                {
                    nWinHandle = FindWindow("QCDataInterfaceWndClass", null);
                }
                catch (Exception err)
                {
                    throw;
                }
    
                if (nWinHandle == IntPtr.Zero)
                {
                    throw new Exception("Duff");
                }
        
                int ans = SendMessage(nWinHandle, CommandMsgs["QCOLLECTOR_CLIENT_PORTFOLIO_LIST_REQUEST"], IntPtr.Zero, this.Handle);
                Console.WriteLine($"SENT to: {nWinHandle} From: {proc.MainWindowHandle} {this.Handle}");
                Console.WriteLine($"Ans: {ans}");
            }
    
            protected override void WndProc(ref Message m)
            {
                string MsgName;
                if (AllMsgs.TryGetValue((uint)m.Msg, MsgName))
                {
                    Console.WriteLine($"HWnd: {m.HWnd}");
                    Console.WriteLine($"Msg: {m.Msg} ({MsgName})");
                    Console.WriteLine($"WParam: {m.WParam}");
                    Console.WriteLine($"LParam: {m.LParam}");
                    if (NotificationMsgs.Contains((uint)m.Msg))
                    {
                        StringBuilder sb = new StringBuilder(514);
                        GlobalGetAtomName((ushort)Msg.LParam, sb, sb.Capacity);
                        Console.WriteLine("String: " + sb.ToString());    
                    }
                }
                base.WndProc(ref m);
            }
        }
    }
