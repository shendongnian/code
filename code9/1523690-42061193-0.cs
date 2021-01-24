    private void InstallProtocol_Click(object sender, RoutedEventArgs e)
    {
        using (var hkcr = Registry.ClassesRoot)
        {
            if (hkcr.GetSubKeyNames().Contains(SchemeName.Text))
            {
                MessageBox.Show(string.Format("Looks like {0} is already installed.", SchemeName.Text));
                return;
            }
            using (var schemeKey = hkcr.CreateSubKey(SchemeName.Text))
            {
                //[HKEY_CLASSES_ROOT\com.aruntalkstech.wpftarget]
                //@="Url:WPF Target Protocol"
                //"URL Protocol"=""
                //"UseOriginalUrlEncoding"=dword:00000001
                schemeKey.SetValue(string.Empty, "Url: WPF Target Protocol");
                schemeKey.SetValue("URL Protocol", string.Empty);
                schemeKey.SetValue("UseOriginalUrlEncoding", 1, RegistryValueKind.DWord);
                //[HKEY_CLASSES_ROOT\com.aruntalkstech.wpf\shell]
                using (var shellKey = schemeKey.CreateSubKey("shell"))
                {
                    //[HKEY_CLASSES_ROOT\com.aruntalkstech.wpf\shell\open]
                    using (var openKey = shellKey.CreateSubKey("open"))
                    {
                        //[HKEY_CLASSES_ROOT\com.aruntalkstech.wpf\shell\open\command]
                        using (var commandKey = openKey.CreateSubKey("command"))
                        {
                            //@="C:\\github\\SampleCode\\UniversalAppLaunchingWPFApp\\WPFProtocolHandler\\bin\\Debug\\WPFProtocolHandler.exe \"%1\""
                            commandKey.SetValue(string.Empty, Assembly.GetExecutingAssembly().Location + " %1");
                            commandKey.Close();
                        }
                        openKey.Close();
                    }
                    shellKey.Close();
                }
                schemeKey.Close();
            }
            hkcr.Close();
        }
        MessageBox.Show(string.Format("Custom scheme {0}: installed.", SchemeName.Text));
    }
