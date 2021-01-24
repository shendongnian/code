    void OnProjectRetrieved(string[] projects)
    {
        // do stuff with your project array
    }
    public void StartRoutineGetProjects(string username, string password, string url)
    {
        StartCoroutine(GetProjects(username, password, url, OnProjectRetrieved));
    }
