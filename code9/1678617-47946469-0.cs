        private void groupBox1_Enter(object sender, EventArgs e)
        {
        if (btnno.Checked == true)
            {
                DisposeStartup();
            }
            else if (btnyes.Checked == true)
            {
                ActivateStartup();
            }
        }
        private void ActivateStartup()
        {
            reg.SetValue("MyApp", Application.ExecutablePath.ToString());
            reg.Close();
        }
            private void DisposeStartup()
             {
            if (reg != null)
            {
                reg.DeleteValue("MyApp", true);
                reg.Close();
            }
        }
