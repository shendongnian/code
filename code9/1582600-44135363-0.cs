    public interface INegocio
    {
        DTOBaseEntity GetByKey(object id);
        DTOBaseEntity Save(DTOBaseEntity dto);
        void Delete(DTOBaseEntity dto);        
        void SetStateBDE(DTOBaseEntity dto, int estado, int tipoEvento, string descripcion = null);
        void SetStateBDE(DTOBaseEntity dto, int estado);
    }
