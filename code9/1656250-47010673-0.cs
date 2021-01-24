    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace WordExampleApp
    {
        class Program
        {
            const int ERROR_SHARING_VIOLATION = -2147024864;
            static readonly string WORD_CLASS_NAME = "OpusApp";
            static readonly string WORD_DOCUMENT_CLASS_NAME = "_WwB";
    
            delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
    
            static void Main(string[] args)
            {
                // Path to exist word document
                string filePath = @"C:\temp\asdasd.docx";
    
                string documentName = Path.GetFileNameWithoutExtension(filePath);
                var isDocOpened = IsDocumentOpened(documentName);
                Console.WriteLine("Is document opened: {0}", isDocOpened);
    
                bool canRead = CanReadFile(filePath);
                Console.WriteLine("Can read file: {0}", canRead);
            }
            private static bool CanReadFile(string path)
            {
                try {
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None)) { }
                    return true;
                }
                catch (IOException ex) {
                    if (ex.HResult == ERROR_SHARING_VIOLATION)
                        return false;
                    else throw;
                }
            }
    
            private static bool IsDocumentOpened(string documentName)
            {
                IntPtr hwnd = FindWindow(WORD_CLASS_NAME, documentName + " - Word");
                List<IntPtr> childs = GetChildWindows(hwnd);
                var classText = new StringBuilder("", 1024);
                var windowText = new StringBuilder("", 1024);
    
                foreach (var childHwnd in childs)
                {
                    if (0 == GetClassName(childHwnd, classText, 1024)) {
                        // something wrong
                    }
                    if (0 == GetWindowText(childHwnd, windowText, 1024)) {
                        // something wrong
                    }
                    var className = classText.ToString();
                    var windowName = windowText.ToString();
                    if (className == WORD_DOCUMENT_CLASS_NAME && windowName == documentName)
                        return true;
    
                    classText.Clear();
                    windowText.Clear();
                }
                return false;
            }
            public static List<IntPtr> GetChildWindows(IntPtr parent)
            {
                List<IntPtr> result = new List<IntPtr>();
                GCHandle gcHandle = GCHandle.Alloc(result);
                try {
                    EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                    EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(gcHandle));
                }
                finally {
                    if (gcHandle.IsAllocated)
                        gcHandle.Free();
                }
                return result;
            }
            private static bool EnumWindow(IntPtr handle, IntPtr pointer)
            {
                GCHandle gch = GCHandle.FromIntPtr(pointer);
                List<IntPtr> list = gch.Target as List<IntPtr>;
                if (list == null)
                    throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
                list.Add(handle);
                return true;
            }
    
            [DllImport("user32", ExactSpelling = false, CharSet = CharSet.Auto)]
            internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowProc lpEnumFunc, IntPtr lParam);
    
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
    
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpWindowText, int nMaxCount);
        }
    }
