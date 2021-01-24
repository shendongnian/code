    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    namespace CarroBemGuardado.Helpers
    {
        public class CalcularValorPagar
        {
            static decimal CalcularPagamento (string dur, decimal ph, decimal hadd)
            {
                decimal valorpagar = 0;
                decimal horas = Convert.ToDecimal(dur.Substring(0, 2));
                decimal minutos = Convert.ToDecimal(dur.Substring(3, 2));
    
                if ((horas == 0) && (minutos <= 30))
                {
                    valorpagar = ph / 2;
                }
                else if ((horas > 0) && (minutos > 10))
                {
                    valorpagar = ph + (hadd * horas);
                }
                else if ((horas > 0) && (minutos < 10))
                {
                    valorpagar = ph + (hadd * (horas - 1));
                }
                else
                {
                    valorpagar = ph;
                }
    
                return valorpagar;
            }
        }
    }
