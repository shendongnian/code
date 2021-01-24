               var importes = (from c in _context.reintegroSolicitado
                                join d in _context.reintegroRecibido on c.expediente.ID equals d.expediente.ID
                                select new { reintegroSolicitado = c, reintegroRecibido = c})
                                .GroupBy(x => new { c = x.reintegroSolicitado , d = x.reintegroRecibido})
                                .Select(cd => new { ImporteSolictadoFinal = cd.Sum(b => b.reintegroSolicitado.ImporteSolicitado + b.reintegroSolicitado.InteresesDemora), ImporteReintegroFinal = cd.Sum(e => e.reintegroRecibido.ImporteReintegro) });
                    
            }
     
        }
        public class Context
        {
            public List<ReintegroSolicitado> reintegroSolicitado { get; set; }
            public List<ReintegroSolicitado> reintegroRecibido { get; set; }
            public Expediente expediente { get; set; }
        }
        public class ReintegroSolicitado
        {
            public Expediente expediente { get; set; }
            public int ImporteSolicitado { get; set; }
            public int InteresesDemora { get; set; }
            public int ImporteReintegro { get; set; }
        }
        public class Expediente
        {
            public int ID { get; set; }
            public int Codigo { get; set; }
        }
