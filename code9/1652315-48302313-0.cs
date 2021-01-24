    using Gtk;
    
    namespace Kk
    {
        class MainWindow: Gtk.Window {
            public MainWindow() : base("LayText")
            {
                SetDefaultSize(800, 600);
                SetPosition(WindowPosition.Center);
                DeleteEvent += delegate { Application.Quit(); };
            
                this.InitializeComponent();
            
                ShowAll();
            }
            
            private void InitializeComponent()
            {
                var m_new = new MenuItem("Nouveau fichier");
                var m_open = new MenuItem("Ouvrir fichier");
                var m_exit = new MenuItem("Quitter");
            
                var file = new Menu();
                file.Append(m_new);
                file.Append(m_open);
                file.Append(m_exit);
            
                 var menu_file = new MenuItem("Fichier");
                 menu_file.Submenu = file;
            
                 var menu_bar = new MenuBar();
                 menu_bar.Append(menu_file);
            
                 var vbox_princ = new VBox(false, 2);
                 vbox_princ.PackStart(menu_bar, false, false, 0);
            
                 this.Add(vbox_princ);
            }
            
            public static void Main()
            {
                Application.Init();
                new MainWindow();
                Application.Run();
            }
        }
    }
