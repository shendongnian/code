    private static string LigacaoBD="something";
        private static Perfil perfil = new Perfil(LigacaoBD);
        protected void Page_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => teste());
        }
        
        private void teste()
        {
            bool verif = false;
            while (true)
            {
                if (DateTime.UtcNow.Hour + 1 == 22 && DateTime.UtcNow.Minute == 12 && DateTime.UtcNow.Second == 0)
                    verif = false;
                if (!verif)
                {
                    int resposta = perfil.Guardar(DateTime.UtcNow.ToString());
                    verif = true;
                }
                Thread.Sleep(1000);
            }
        }
