    public interface IAdaptable<in TIEntity, in TIDTO, TDTO>
        where TDTO : TIDTO
    {
        bool IsInitialized { get;  set; }
        void Initialize(TIEntity entity);
        TDTO ToDTO(TIDTO iEntityDTO);
        void ApplyFrom(TIDTO entityDTO);
    }
