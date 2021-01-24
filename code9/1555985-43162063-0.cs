     using System;
     using System.Runtime.InteropServices;
        
     namespace WebBrowserMessageBox
     {
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
           public int x;
           public int y;
        }
    
      
    
        [ComImport, Guid("C4D244B0-D43E-11CF-893B-00AA00BDCE1A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
          public interface IDocHostShowUI
          {
            [return: MarshalAs(UnmanagedType.U4)]
            [PreserveSig]
            int ShowMessage(IntPtr hwnd,
              [MarshalAs(UnmanagedType.LPWStr)] string lpstrText,
              [MarshalAs(UnmanagedType.LPWStr)] string lpstrCaption,
              int dwType,
              [MarshalAs(UnmanagedType.LPWStr)] string lpstrHelpFile,
              int dwHelpContext,
              out int lpResult);
        [return: MarshalAs(UnmanagedType.U4)]
        [PreserveSig]
        int ShowHelp(
          IntPtr hwnd,
          [MarshalAs(UnmanagedType.LPWStr)] string pszHelpFile,
          int uCommand,
          int dwData,
          POINT ptMouse,
          [MarshalAs(UnmanagedType.IDispatch)] object pDispatchObjectHit);
      }
    
      public class ShowMessageEventArgs : EventArgs
     {
        public ShowMessageEventArgs(string text, string caption, int type, string helpFile, int helpContext)
        {
        }
    
        public bool Handled { get; set; }
        public int Result { get; set; }
        public int Type { get; private set; }
        public int HelpContext { get; private set; }
        public string Text { get; private set; }
        public string Caption { get; private set; }
        public string HelpFile { get; private set; }
      }
    
      public class MyWebBrowser : global::System.Windows.Forms.WebBrowser
      {
        protected class MyWebBrowserSite : global::System.Windows.Forms.WebBrowser.WebBrowserSite, IDocHostShowUI
        {
          private readonly MyWebBrowser host;
    
          public MyWebBrowserSite(MyWebBrowser host)
            : base(host)
          {
            this.host = host;
          }
    
          public int ShowMessage(IntPtr hwnd, string lpstrText, string lpstrCaption, int dwType, string lpstrHelpFile, int dwHelpContext, out int lpResult)
          {
            var e = new ShowMessageEventArgs(lpstrText, lpstrCaption, dwType, lpstrHelpFile, dwHelpContext);
            this.host.OnShowMessage(e);
    
            if (e.Handled)
            {
              lpResult = e.Result;
              return 0;
            }
            else
            {
              lpResult = 0;
              return 1;
            }
          }
    
          public int ShowHelp(IntPtr hwnd, string pszHelpFile, int uCommand, int dwData, POINT ptMouse, object pDispatchObjectHit)
          {
            return 1;
          }
        }
    
        protected override System.Windows.Forms.WebBrowserSiteBase CreateWebBrowserSiteBase()
        {
          return new MyWebBrowserSite(this);
        }
    
        protected virtual void OnShowMessage(ShowMessageEventArgs e)
        {
          var handler = this.Events["ShowMessage"] as EventHandler<ShowMessageEventArgs>;
    
          if (handler != null)
          {
            handler(this, e);
          }
        }
    
        public event EventHandler<ShowMessageEventArgs> ShowMessage
        {
          add { this.Events.AddHandler("ShowMessage", value); }
          remove { this.Events.RemoveHandler("ShowMessage", value); }
        }
      }
    
      public static class Program
      {
        [STAThread]
        private static void Main(params string[] args)
        {
          var webBrowser = new MyWebBrowser
          {
            Dock = System.Windows.Forms.DockStyle.Fill,
            DocumentText = @"<html><head><body><script language='JScript'>alert(""test"")</script></body></head></html>"
          };
          webBrowser.ShowMessage += (sender, e) =>
          {
            e.Result = 0;
            e.Handled = true;
          };
    
          var form = new global::System.Windows.Forms.Form
          {
            Controls = { webBrowser }
          };
    
          global::System.Windows.Forms.Application.Run(form);
        }
      }
    }
