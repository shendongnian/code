    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Word = NetOffice.WordApi;
    namespace WordSpellCheckerTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var app = new Word.Application())
                {
                    SpellCheckerDemo(app);
                }
            }
            private static async void SpellCheckerDemo(Word.Application app)
            {
                app.Visible = true;
                var doc = app.Documents.Add();
                doc.Words.First.InsertBefore("Here's some text that requiires speell cheking");
                var process = GetProcess(app);
                var task = new Task(() => CheckSpellingTask(doc));
                task.Start();
                //Wait for the window to open
                Thread.Sleep(4000);
                //I found the classname by comparing the list of windows for the process before and after opening the spell checker
                //Then I checked the title to confirm
                var spellCheckerWindow = WindowStuff.GetWindowsWithPID(process.Id).FirstOrDefault(w => w.ClassName == "bosa_sdm_msword");
                //Do something with the window
                spellCheckerWindow.Close();
                //Wait for the task to finish before closing
                task.Wait();
                doc.Close(false);
                app.Quit();
            }
            private static async Task CheckSpellingTask(Word.Document doc)
            {
                try
                {
                    doc.CheckSpelling();
                }
                catch { }
            }
            //From my answer here: http://stackoverflow.com/questions/8673726/get-specific-window-handle-using-office-interop/41462638#41462638
            private static Process GetProcess(Word.Application app)
            {
                var tempDocument = app.Documents.Add();
                var project = tempDocument.VBProject;
                var component = project.VBComponents.Add(NetOffice.VBIDEApi.Enums.vbext_ComponentType.vbext_ct_StdModule);
                var codeModule = component.CodeModule;
                codeModule.AddFromString("#If Win64 Then\r\n   Declare PtrSafe Function GetCurrentProcessId Lib \"kernel32\" () As Long\r\n#Else\r\n   Declare Function GetCurrentProcessId Lib \"kernel32\" () As Long\r\n#End If");
                var result = app.Run("GetCurrentProcessId");
                var process = Process.GetProcessById((int)result);
                tempDocument.Close(false);
                return process;
            }
            //Hacked together from the pInvoke pages for these WinAPI calls
            public class WindowStuff
            {
                [DllImport("user32.dll", SetLastError = true)]
                private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
                [DllImport("user32.dll", CharSet = CharSet.Auto)]
                private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, [Out] StringBuilder lParam);
                [DllImport("user32.dll", CharSet = CharSet.Auto)]
                private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
                [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
                private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
                [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
                [return: MarshalAs(UnmanagedType.Bool)]
                private static extern bool EnumWindows(WindowEnumerator lpEnumFunc, ArrayList lParam);
                private delegate bool WindowEnumerator(IntPtr handleWindow, ArrayList handles);
                const uint WM_CLOSE = 0x0010;
                const uint WM_GETTEXTLENGTH = 0x000E;
                const uint WM_GETTEXT = 0x000D;
                public struct Info
                {
                    public uint Hwnd;
                    public uint PID;
                    public string ClassName;
                    public string Title;
                    public Info(IntPtr hwnd )
                    {
                        uint processID;
                        GetWindowThreadProcessId(hwnd, out processID);
                        Hwnd = (uint)hwnd;
                        PID = processID;
                        ClassName = GetClassName(hwnd);
                        Title = GetWindowTitle(hwnd);
                    }
                    public void Close()
                    {
                        SendMessage(new IntPtr(Hwnd), WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                    }
                }    
                public static List<Info> GetWindowsWithPID(int pID)
                {
                    return GetWindowsInner().Cast<IntPtr>().Select(hwnd => new Info(hwnd)).Where(i => i.PID == (uint)pID).ToList();
                }
                private static ArrayList GetWindowsInner()
                {
                    var windowHandles = new ArrayList();
                    WindowEnumerator callBackPtr = GetWindowHandle;
                    EnumWindows(callBackPtr, windowHandles);
                    return windowHandles;
                }
                static string GetWindowTitle(IntPtr hwnd)
                {
                    int length = (int)SendMessage(hwnd, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
                    StringBuilder sb = new StringBuilder(length + 1);
                    SendMessage(hwnd, WM_GETTEXT, (IntPtr)sb.Capacity, sb);
                    return sb.ToString();
                }
                private static bool GetWindowHandle(IntPtr windowHandle, ArrayList windowHandles)
                {
                    windowHandles.Add(windowHandle);
                    return true;
                }
                private static string GetClassName(IntPtr hWnd)
                {
                    var className = new StringBuilder(256);
                    return GetClassName(hWnd, className, className.Capacity) != 0 ? className.ToString() : string.Empty;
                }
            }
        }
    }
