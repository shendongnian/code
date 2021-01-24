    public class Plataforma: DbContext
    {
        public virtual IDbSet<Máquina> Máquinas { get; set; }
        public virtual IDbSet<TipoMáquina> TipoMáquinas { get; set; }
    }
