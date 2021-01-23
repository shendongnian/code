    public Mapa()
        {
            InitializeComponent();
            //Por defecto el web browser utiliza la versión 7 de Internet Explorer incompatible para visualizar google maps, 
            //con el indicador 11001 se setea a la versión 11 de Internet Explorer.
            SetearVersionWebBrowser(11001);
        }
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
           
            try
            {
                //Asignación de los valores de los texbox
                string provincia = txt_provincia.Text;
                string ciudad = txt_ciudad.Text;
                string calle = txt_calle.Text;
                string codigoPostal = txt_postal.Text;
                StringBuilder direccion = new StringBuilder();
                direccion.Append("http://maps.google.com/maps?q=");
                //Condicionales para validar que si los campos están vacios no se tome ese criterio
                if (calle != string.Empty) {
                    direccion.Append(calle + "," + "+");
                }
                if (ciudad != string.Empty)
                {
                    direccion.Append(ciudad + "," + "+");
                }
                if (provincia != string.Empty)
                {
                    direccion.Append(provincia + "," + "+");
                }
                if (codigoPostal != string.Empty)
                {
                    direccion.Append(codigoPostal + "," + "+");
                }
                //Xpcom.EnableProfileMonitoring = false;
                //Xpcom.Initialize("Firefox");
                //Carga el documento espeficiado en la variable direccion
                webBrowser1.Navigate(direccion.ToString());
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetearVersionWebBrowser(int ie_version)
        {
            //String de la Ruta donde se registrará el Dword
            const string key32bit =
                @"SOFTWARE\Microsoft\Internet Explorer\MAIN\" +
                @"FeatureControl\FEATURE_BROWSER_EMULATION";
            //Se obtiene el nombre del programa en ejecución
            string app_name = System.AppDomain.CurrentDomain.FriendlyName;
            // You can do both if you like.
            //Registra el Dword con los parámetros el primero la ruta, el segundo con el nombre PruebaGrafica.vshost.exe, el tercero con la versión de internet explorer que se quiere ejecutar
            SetearRegistroDword(key32bit, app_name, ie_version);
        }
        //Método que registra un valor DWORD 
        private void SetearRegistroDword(string nonmbreLlave, string nombreValor, int valor)
        {
            // Registro de la clave.
            RegistryKey key =  Registry.CurrentUser.OpenSubKey(nonmbreLlave, true);
            // Se crea la clave solo si no existe.
            if (key == null)
                key = Registry.CurrentUser.CreateSubKey(nonmbreLlave, RegistryKeyPermissionCheck.ReadWriteSubTree);
            // Establece un nombre, la clave de registro y el tipo de datos del registro especificado.
            key.SetValue(nombreValor, valor, RegistryValueKind.DWord);
            // Cierra la clave 
            key.Close();
        }
