    class UniqueWindowView: Gtk.Window
    {
        void Build()
        {
            var vbMainBox = new Gtk.VBox();
        
            this.vbLoginPage = this.BuildLoginPage();
            this.vbNotebook = this.BuildNotebook();
        
            vbMainBox.PackStart( this.vbLoginPage, true, true, 100 );
            vbMainBox.PackStart( this.vbNotebook, true, true, 5 );
            vbMainBox.Show();
            
            this.Add( vbMainBox );
            this.SetSizeRequest( 600, 400 );
            this.Show();
        }
        // ...
        public Gtk.VBox vbLoginPage {
            get; private set;
        }
        
        public Gtk.VBox vbNotebook {
            get; private set;
        }
            
        public Gtk.Notebook nbNotebook {
            get; private set;
        }
        
        public Gtk.Button btLogin {
            get; private set;
        }
    }
