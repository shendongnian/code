        private static Dictionary<string, List<Action<dynamic>>> callbackList;
        public static void Fire(string eventName, dynamic payload)
        {
            try
            {
                List<Action<dynamic>> actions = callbackList[eventName];
                actions.ForEach(action => {
                    action(payload);
                });
            } catch(Exception e) { }
        }
        public static void Add(string eventName, Action<dynamic> callback)
        {
            if (callbackList.ContainsKey(eventName))
            {
                callbackList[eventName].Add(callback);
            }
            else
            {
                callbackList.Add(eventName, new List<Action<dynamic>> { callback });
            }
        }
