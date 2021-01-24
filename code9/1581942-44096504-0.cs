    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp5
    {
        static class Program
        {
    
            private static Random rd = new Random();
            private static NotifyIcon notifyIcon;
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                NotifyIcon ni = new NotifyIcon(new System.ComponentModel.Container());
                ContextMenu cm = new ContextMenu();
    
                cm.MenuItems.Add(new MenuItem("First", Click));
                cm.MenuItems.Add(new MenuItem("Second", Click));
                cm.MenuItems.Add(new MenuItem("Third", Click));
                cm.MenuItems.Add(new MenuItem("Exit", (obj,e)=> { Application.Exit(); }));
                ni.Icon = new Icon(@"c:\Users\Admin\Desktop\img.ico");
                ni.Text = "Form1 (NotifyIcon example)";
                ni.ContextMenu = cm;
                ni.Visible = true;
                notifyIcon = ni;
                Application.Run();
                
            }
    
            public static bool  SomeCondition()
            {
                return (rd.Next(0, 9999) % 2) == 1;
            }
    
            public static void Click(object sender, EventArgs e)
            {
                if (SomeCondition())
                {
                    ContextMenu cm = new ContextMenu();
                    cm.MenuItems.Add(new MenuItem("Fourth", Click));
                    cm.MenuItems.Add(new MenuItem("Fifth", Click));
                    cm.MenuItems.Add(new MenuItem("Sixth", Click));
                    cm.MenuItems.Add(new MenuItem("Exit", (obj, args) => { Application.Exit(); }));
                    notifyIcon.ContextMenu = cm;
                }
                else
                {
                    ContextMenu cm = new ContextMenu();
                    cm.MenuItems.Add(new MenuItem("Third", Click));
                    cm.MenuItems.Add(new MenuItem("Sixth", Click));
                    cm.MenuItems.Add(new MenuItem("Fourth", Click));
                    cm.MenuItems.Add(new MenuItem("Exit", (obj, args) => { Application.Exit(); }));
                    notifyIcon.ContextMenu = cm;
                }
            }
        }
    }
