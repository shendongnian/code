        /// <summary>
        /// This function is the callback used to execute a command when the a menu item is clicked.
        /// See the Initialize method to see how the menu item is associated to this function using
        /// the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        private void MenuItemCallback(object sender, EventArgs e)
        {           
            LoadPrism();
            AutomaticSynopticGenerationCore.Views.MainWindow mainWindow = new AutomaticSynopticGenerationCore.Views.MainWindow();
            mainWindow.Show();
        }
        /// <summary>
        /// Loads Prism from own attached Assembly before window instance gets created
        /// </summary>
        static void LoadPrism()
        {            
            typeof(Prism.Bootstrapper).ToString();
        }
