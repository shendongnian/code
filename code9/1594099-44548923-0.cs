    private static Bcm2835 instance;
    private static object syncRoot = new Object();
    public static Bcm2835 Instance
    {
        get
        {
            if(instance == null)
            {
                lock(syncRoot)
                {
                    if(instance == null)
                        instance = new Bcm2835();
                }
            }
            return instance;
        }
    }
