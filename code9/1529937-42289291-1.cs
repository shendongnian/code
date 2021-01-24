    public class AdapterBase<TIEntity, TIDTO, TDTO> : IAdaptable<TIEntity, TIDTO, TDTO>
        where TDTO : TIDTO
    {
        #region Consts
        public const string FAILED_TO_INITIALIZE_ADAPTER_ERROR = "Failed to Initialize Adapter make sure you called the Initialize function";
        #endregion
        #region Protected Members
        protected TIEntity _entity;
        #endregion
        #region IAdaptable
        public bool IsInitialized { get; set; }
        public void Initialize(TIEntity entity)
        {
            this._entity = entity;
            IsInitialized = true;
        }
        public void ApplyFrom(TIDTO entityDTO)
        {
            if (false == IsInitialized)
            {
                throw new Exception(FAILED_TO_INITIALIZE_ADAPTER_ERROR);
            }
            Mapper.Map(entityDTO, this);
        }
        public TDTO ToDTO(TIDTO adaptable)
        {
            if (false == IsInitialized)
            {
                throw new Exception(FAILED_TO_INITIALIZE_ADAPTER_ERROR);
            }
            return Mapper.Map<TIDTO, TDTO>(adaptable);
        }
        #endregion
    }
