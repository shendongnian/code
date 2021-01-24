     public static void Start()
                {
                    int startTime = DateTime.Now.Millisecond;
                    while(isCounting)
                    {
                        elapsedTime = DateTime.Now.Millisecond - startTime;
                    }
                }
