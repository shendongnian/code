    void Application_Start(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Hostname))
                Hostname = GetHostname();
        }
