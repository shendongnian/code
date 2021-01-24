        public class SistemaMap : DommelEntityMap<Entities.Sistema>{
        public SistemaMap()
        {
            ToTable("Sistema");        
            this.Map(a => a.Id).ToColumn("sist_id");
        }
    }
