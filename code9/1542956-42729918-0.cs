    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SymetryBusModuloImpresora;
    
    namespace PrinterService {
        public class PrinterService {
                public static int imprimriPDF(string ruta, string archivo) {
                return SymetryBusModuloImpresora.cImpresora.ImprimirPDF(ruta, archivo);
            }
        }
    }
