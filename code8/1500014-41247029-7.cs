    public void Doit()
        {
            IService service = new Service();
            Task<double> task = service.GetDataAsync(1);
        }
