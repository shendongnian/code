        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContextRequestData.RequestGuid = Guid.NewGuid().ToString();
            HttpContextRequestData.RequestInitiated = DateTime.Now;
            logger.Info("Application_BeginRequest");
        }
        void Application_EndRequest(object sender, EventArgs e)
        {
            var requestAge = DateTime.Now.Subtract(HttpContextRequestData.RequestInitiated);
            if (requestAge.TotalSeconds <= 20)
                logger.Info("Application_End, took {0} seconds", requestAge.TotalSeconds);
            else if (requestAge.TotalSeconds <= 60)
                logger.Warn("Application_End, took {0} seconds", requestAge.TotalSeconds);
            else
                logger.Fatal("Application_End, took {0} seconds", requestAge.TotalSeconds);
        }
