    protected void Application_Start() {
        Application["LiveSessionsCount"] = 0;
    }
    protected void Session_Start() {
        Application["LiveSessionsCount"] = ((int)Application["LiveSessionsCount"]) + 1;
    }
    protected void Session_End() {
        Application["LiveSessionsCount"] = ((int) Application["LiveSessionsCount"]) - 1;
    }
