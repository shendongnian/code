      public T MatchAiIntent<T>(string message) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enum type!");
            }
        T result = default(T);
        try
        {
            var response = apiAi.TextRequest(message);
            var intentName = response?.Result?.Metadata?.IntentName;
            if (intentName == null)
            {
                return result;
            }
            Enum.TryParse<T>(intentName, true, out result);
            return result;
        }
        catch (Exception exception)
        {
			//logit
            throw;
        }
    } 
   
