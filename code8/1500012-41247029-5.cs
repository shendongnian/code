    public class Consumer
    {
        public async void Doit()
        {
            IService service = new Service();
            double d = await service.GetDataAsync(1);
        }
    }
