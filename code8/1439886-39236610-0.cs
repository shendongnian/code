    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.Serialization;
    
    namespace Mvm.SATWeb.Domain
    {
        [Serializable, DataContract]
        public  class puntoDeAtencion
        {
    
            public puntoDeAtencion()
            {
            }
    
            [DataMember(Order = 0)]
            public string codigoPuntoAtencion { get; set; }
            [DataMember(Order = 1)]
            public decimal montoIngreso { get; set; }
            [DataMember(Order = 2)]
            public decimal montoEgreso { get; set; }
            [DataMember(Order = 3)]
            public decimal ingresoNeto { get; set; }         
    
       }
    }
