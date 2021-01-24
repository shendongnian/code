    public static TEntityService CreateService(object[] constructorParameters) {
        if (constructorParameters.Length == 1 &&
            constructorParameters[0] is IRepositoryAsync<Tag>) {
            return (TEntityService)System.Activator.CreateInstance(typeof(TagService), constructorParameters);
        } else if (constructorParameters.Length == 2 &&
            constructorParameters[0] is IRepositoryAsync<Ads> &&
            constructorParameters[1] is IUnitOfWork) {
            return (TEntityService)System.Activator.CreateInstance(typeof(AdsService), constructorParameters);
        } else {
            return null; // or you can throw an exception
        }
    }
