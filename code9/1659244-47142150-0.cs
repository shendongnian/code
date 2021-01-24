    using EDP.GestaoVarejista.MOD;
    
    namespace EDP.GestaoVarejista.DAL.CadastrosGerais;
    
    
        public class Garantias : Base
        {
            public int Inserir(Garantia garantia)
            {
                try
                {
                    using (EDPGestaoVarejistaEntities dbEntities = new EDPGestaoVarejistaEntities())
                        {
                           tb_garantias NovaGarantia = new tb_garantias
                           {
                               descrGarantia = garantia.descGarantia   
                           };
                        }
                }
            }
    }
