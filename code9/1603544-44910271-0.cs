     using System.Runtime.InteropServices;
     ... 
     [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
      private static extern int GetClassName(IntPtr hWnd, 
        StringBuilder lpClassName, 
        int nMaxCount);
      private static String WndClassName(IntPtr handle) {
        int length = 1024;
        StringBuilder sb = new StringBuilder(length);
        GetClassName(handle, sb, length);
        return sb.ToString();
      }
      public static bool IsDialogClassName(IntPtr handle) {
        return "#32770".Equals(WndClassName(handle));
      } 
