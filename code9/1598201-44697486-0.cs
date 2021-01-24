    public UserControl()
    {
        //Initialise control
    }
    public static UserControl UserControlInstance
    {
        get
        {
            return m_UserControlInstance ?? new UserControl();
        }
    }
    private static UserControl m_UserControlInstance;
