    using Microsoft.Win32;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    public static class PrintUtility
    {
      private static readonly SemaphoreSlim browserReadySemaphore = new SemaphoreSlim(0);
      // A4 dimensions.
      private const int DPI = 600;
      private const int WIDTH = (int)(8.3 * DPI);
      private const int HEIGHT = (int)(11.7 * DPI);
      
      public static void Print(this Image image, string printer, bool showDialog = false)
      {
        if (printer == null)
        {
          throw new ArgumentNullException("Printer cannot be null.", nameof(printer));
        }
        using (PrintDialog printDialog = new PrintDialog())
        {
          using (PrintDocument printDoc = new PrintDocument())
          {
            printDialog.Document = printDoc;
            printDialog.Document.DocumentName = "My Document";
            printDialog.Document.OriginAtMargins = false;
            printDialog.PrinterSettings.PrinterName = printer;
            
            printDoc.PrintPage += (sender, e) => 
            {
              // Draw to fill page
              e.Graphics.DrawImage(image, 0, 0, e.PageSettings.PrintableArea.Width, e.PageSettings.PrintableArea.Height);
              // Draw to default margins
              // e.Graphics.DrawImage(image, e.MarginBounds);
            };
            
            bool doPrint = !showDialog;
            if (showDialog)
            {
              var result = printDialog.ShowDialog();
              doPrint = (result == DialogResult.OK);
            }
            if (doPrint)
            {
              printDoc.Print();
            }
          }
        }
      }
      public static async Task<bool> RenderAndPrintHTMLAsync(string html, string printer)
      {
        bool result = false;
        
        // Enable HTML5 etc. (assuming we're running IE9+)
        SetFeatureBrowserFeature("FEATURE_BROWSER_EMULATION", 9000);
        // Force software rendering
        SetFeatureBrowserFeature("FEATURE_IVIEWOBJECTDRAW_DMLT9_WITH_GDI", 1);
        SetFeatureBrowserFeature("FEATURE_GPU_RENDERING", 0);
        using (var webBrowser = new WebBrowser())
        {
          webBrowser.ScrollBarsEnabled = false;
          webBrowser.Width = WIDTH;
          webBrowser.Height = HEIGHT;
          webBrowser.DocumentCompleted += ((s, e) => browserReadySemaphore.Release());
          webBrowser.LoadHTML(html);
          // Wait until the page loads.
          await browserReadySemaphore.WaitAsync();
          // Save the picture
          using (var bitmap = webBrowser.ToBitmap())
          {
            bitmap.Save("WebBrowser_Bitmap.bmp");
            Print(bitmap, printer);
            result = true;
          }
        }
        return result;
      }
      /// <summary>
      /// Make a Bitmap from the Control.
      /// Remember to dispose after.
      /// </summary>
      /// <param name="control"></param>
      /// <returns></returns>
      public static Bitmap ToBitmap(this Control control)
      {
        Bitmap bitmap = new Bitmap(control.Width, control.Height);
        Rectangle rect = new Rectangle(0, 0, control.Width, control.Height);
        control.DrawToBitmap(bitmap, new Rectangle(0, 0, control.Width, control.Height));
        return bitmap;
      }
      /// <summary>
      /// Required because of a bug where the WebBrowser only loads text once or not at all.
      /// </summary>
      /// <param name="webBrowser"></param>
      /// <param name="htmlToLoad"></param>
      /// <remarks>
      /// http://stackoverflow.com/questions/5362591/how-to-display-the-string-html-contents-into-webbrowser-control/23736063#23736063
      /// </remarks>
      public static void LoadHTML(this WebBrowser webBrowser, string htmlToLoad)
      {
        webBrowser.Document.OpenNew(true);
        webBrowser.Document.Write(htmlToLoad);
        webBrowser.Refresh();
      }
      /// <summary>
      /// WebBrowser Feature Control
      /// </summary>
      /// <param name="feature"></param>
      /// <param name="value"></param>
      /// <remarks>
      /// http://stackoverflow.com/questions/21697048/how-to-fix-a-opacity-bug-with-drawtobitmap-on-webbrowser-control/21828265#21828265
      /// http://msdn.microsoft.com/en-us/library/ie/ee330733(v=vs.85).aspx
      /// </remarks>
      private static void SetFeatureBrowserFeature(string feature, uint value)
      {
        if (LicenseManager.UsageMode != LicenseUsageMode.Runtime)
        {
          return;
        }
        var appName = Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        Registry.SetValue(
          @"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\" + feature,
          appName, 
          value, 
          RegistryValueKind.DWord);
      }
    }
