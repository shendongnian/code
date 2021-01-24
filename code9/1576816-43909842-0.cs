    public class GenericModel<T>
    {
        public async Task<T> FindByUuid<T>(Guid uuid) where T:GenericModel, new()
        {
            return await rest.HttpGet<T>($"https://.../{uuid.ToString()}");
        }
    }
    public class Contract : GenericModel<Contract> { ... }
