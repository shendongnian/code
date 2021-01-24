    public class Global : HttpApplication
    {
        private static string LigacaoBD = myConn;
        private static ApiMethods sportRadar = new ApiMethods();
        private static Jogo jogo = new Jogo(LigacaoBD);
        private static List<SportRadar.ClassesCliente.Jogo> jogos;
        private static List<SportRadar.ClassesCliente.Competicao> competicoes;
    
        private BackgroundJobServer _backgroundJobServer;
    
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
    
            GlobalConfiguration.Configuration.UseSqlServerStorage(LigacaoBD);
    
            using (var connection = JobStorage.Current.GetConnection())
            {
                foreach (var recurringJob in connection.GetRecurringJobs())
                {
                    RecurringJob.RemoveIfExists(recurringJob.Id);
                }
            }
    
            //create an instance of BackgroundJobServer
            _backgroundJobServer = new BackgroundJobServer();
    
            //add your recurring job
            RecurringJob.AddOrUpdate(() => Actualizacoes(), Cron.Minutely);
        }
    }
