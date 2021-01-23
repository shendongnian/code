        void ProcessErrorA() { }
        void Main() 
        {
            Dictionary<Type, Action> exceptionHandlers = new Dictionary<Type, Action>();
            exceptionHandlers.Add(typeof(NullReferenceException), ProcessErrorA);
            try{}
            catch (Exception e) 
            {
                if (exceptionHandlers.ContainsKey(e.GetType()))
                {
                    exceptionHandlers[e.GetType()]();
                }
                else 
                {
                    // We don't have any handler for this exception. 
                }
            }
        }
