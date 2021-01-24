    public class AcombaProductsRepository : AcombaRepository<MyProduct, IProduct022> {
        public AcombaProductsRepository(IProduct022 nativeRepository)
            : base(nativeRepository) {
        }
    }
    public abstract class AcombaRepository<TEntity, TNativeRepository>
        where TEntity : class
        where TNativeRepository : IBaseDataKey {
        public AcombaRepository(TNativeRepository nativeRepository) {
            NativeRepository = nativeRepository;
        }
        protected readonly TNativeRepository NativeRepository;
        public TEntity Create(TEntity toCreate) {
            NativeRepository.ReserveCardNumber(); // Insert
            NativeRepository.AddCard(); // Save or commit to Acomba
            return toCreate;
        }
    }
