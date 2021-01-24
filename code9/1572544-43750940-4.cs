    private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            EnvioContraseña Env = new EnvioContraseña ();
            Env.On_SelectButton += Env_On_SelectButton;
            panel1.Controls.Add(Env);
        }
        void Env_On_SelectButton(EnvioContraseña sender)
        {
            panel1.Controls.Clear();
            UserControl1 uc1 = new UserControl1();
            panel1.Controls.Add(uc1);
        }
