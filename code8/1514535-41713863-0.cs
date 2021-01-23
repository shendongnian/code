    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.IO;
    using System.Runtime.InteropServices;
    
    namespace WindowsFormsApplication1 {
      public partial class Form1 : Form {
        public Form1() {
          InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e) {
          Bitmap bmp = Properties.Resources.Image1;
          bmp.MakeTransparent(Color.White);
          IntPtr hIcon = bmp.GetHicon();
          Icon ico = Icon.FromHandle(hIcon);
          Cursor cur = new Cursor(hIcon);
          using (FileStream fs = new FileStream(@"c:\temp\test.cur", FileMode.Create, FileAccess.Write))
            ico.Save(fs);
          cur.Dispose();
          ico.Dispose();
          DestroyIcon(hIcon);
    
          // Test it
          cur = new Cursor(@"c:\temp\test.cur");
          this.Cursor = cur;
        }
        [DllImport("user32.dll")]
        extern static bool DestroyIcon(IntPtr handle);
      }
    }
