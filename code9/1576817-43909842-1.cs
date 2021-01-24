    public class GenericFactory<T> where T : GenericModel, new()
    {
        public async Task<T> FindByUuid<T>(Guid uuid) 
        {
            return await rest.HttpGet<T>($"https://.../{uuid.ToString()}");
        }
    }
    public class Contracts : GenericFactory<Contract> { ... }
