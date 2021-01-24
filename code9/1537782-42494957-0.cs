    public static T DeserializeObject<T>(string value)
    {
        T result = default(T);
        try {
            result = JsonConvert.DeserializeObject<T>(value);
        }
        return result;
    }
