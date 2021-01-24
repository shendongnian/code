    public class Car 
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Make { get; set; }
        [Required]
        [StringLength(20)]
        public string Model { get; set; }
        public int Year { get; set; }
        [Range(0, 500000)]
        public float Price { get; set; }
    }
    public class CarPatch
    {
        [StringLength(20)]
        public string Make { get; set; }
        [StringLength(20)]
        public string Model { get; set; }
        public int? Year { get; set; }
        [Range(0, 500000)]
        public float? Price { get; set; }
    }   
    public class CarsController : ApiController
    {
        private readonly CarsContext _carsCtx = new CarsContext();
        // PATCH /api/cars/{id}
        public Car PatchCar(int id, CarPatch car)
        {
        var carTuple = _carsCtx.GetSingle(id);
        if (!carTuple.Item1)
        {
            var response = Request.CreateResponse(HttpStatusCode.NotFound);
            throw new HttpResponseException(response);
        }
        Patch<CarPatch, Car>(car, carTuple.Item2);
        // Not required but better to put here to simulate the external storage.
        if (!_carsCtx.TryUpdate(carTuple.Item2))
        {
            var response = Request.CreateResponse(HttpStatusCode.NotFound);
            throw new HttpResponseException(response);
        }
        return carTuple.Item2;
    }
    // private helpers
    private static ConcurrentDictionary<Type, PropertyInfo[]> TypePropertiesCache = 
        new ConcurrentDictionary<Type, PropertyInfo[]>();
    private void Patch<TPatch, TEntity>(TPatch patch, TEntity entity)
        where TPatch : class
        where TEntity : class
    {
        PropertyInfo[] properties = TypePropertiesCache.GetOrAdd(
            patch.GetType(), 
            (type) => type.GetProperties(BindingFlags.Instance | BindingFlags.Public));
        foreach (PropertyInfo prop in properties)
        {
            PropertyInfo orjProp = entity.GetType().GetProperty(prop.Name);
            object value = prop.GetValue(patch);
            if (value != null)
            {
                orjProp.SetValue(entity, value);
            }
        }
    }
    }
