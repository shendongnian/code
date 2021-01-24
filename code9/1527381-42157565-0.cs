    public static List<string> logs= new List<string>();
    public static  void DebugMessage (string logType, string message) {
                        logs.Add(message); 
                        if (logType.Equals("warning"))
                            Debug.LogWarning(message);
                        else if (logType.Equals("regular"))
                            Debug.Log(message);
                        else if (logType.Equals("error"))
                            Debug.LogError(message);
                    }
