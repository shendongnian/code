        [ComRegisterFunctionAttribute]
        public static void RegisterFunction(Type type)
        {
            try
            {
                // add codebase value
                Assembly thisAssembly = Assembly.GetAssembly(typeof(OutlookPlugin));
                RegistryKey key = Registry.ClassesRoot.CreateSubKey("CLSID\\{" + type.GUID.ToString().ToUpper() + "}\\InprocServer32\\1.0.0.0");
                key.SetValue("CodeBase", thisAssembly.CodeBase);
                key.Close();
                key = Registry.ClassesRoot.CreateSubKey("CLSID\\{" + type.GUID.ToString().ToUpper() + "}\\InprocServer32");
                key.SetValue("CodeBase", thisAssembly.CodeBase);
                key.Close();
                // add bypass key
                // http://support.microsoft.com/kb/948461
                key = Registry.ClassesRoot.CreateSubKey("Interface\\{000C0601-0000-0000-C000-000000000046}");
                string defaultValue = key.GetValue("") as string;
                if (null == defaultValue)
                    key.SetValue("", "Office .NET Framework Lockback Bypass Key");
                key.Close();
                // add outlook addin key
                Registry.ClassesRoot.CreateSubKey(@"CLSID\{" + type.GUID.ToString().ToUpper() + @"}\Programmable");
                Registry.CurrentUser.CreateSubKey(_addinOfficeRegistryKey + _prodId);
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(_addinOfficeRegistryKey + _prodId, true);
                rk.SetValue("LoadBehavior", Convert.ToInt32(3));
                rk.SetValue("FriendlyName", _addinFriendlyName);
                rk.SetValue("Description", _addinDescription);
                rk.Close();
                //Add registry key under HKLM
                RegistryKey regHKLM = Registry.LocalMachine;
                regHKLM = regHKLM.CreateSubKey(@"SOFTWARE\Microsoft\Office\Outlook\Addins\" + _prodId);
                regHKLM.SetValue("Friendly Name", _addinFriendlyName);
                regHKLM.SetValue("Description", _addinDescription);
                regHKLM.SetValue("LoadBehavior", 3, RegistryValueKind.DWord);
            }
            catch (System.Exception ex)
            {
                string details = string.Format("{1}{1}Details:{1}{1}{0}", ex.Message, Environment.NewLine);
                MessageBox.Show("An error occured." + details, "Register " + _prodId, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        [ComUnregisterFunctionAttribute]
        public static void UnregisterFunction(Type type)
        {
            try
            {
                Registry.ClassesRoot.DeleteSubKey(@"CLSID\{" + type.GUID.ToString().ToUpper() + @"}\Programmable", false);
                Registry.CurrentUser.DeleteSubKey(_addinOfficeRegistryKey + _prodId, false);
                Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Office\Outlook\Addins\" + _prodId);
            }
            catch (System.Exception throwedException)
            {
                string details = string.Format("{1}{1}Details:{1}{1}{0}", throwedException.Message, Environment.NewLine);
                MessageBox.Show("An error occured." + details, "Unregister " + _prodId, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
