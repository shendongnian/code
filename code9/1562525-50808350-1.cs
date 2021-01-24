    public ValuesController
    {
        public IACtionResult Get([FromUri]string[] arr)
        {
            Return Ok(arr.Length);
        }
    }
