    var resultAdo = from x in lista
                    group x.Valor by new { Id1 = x.HoldingGrupoDto.Id, Id2 = x.UnidadeDto.Id, Id3 = x.OperadoraDto.Id, x.DataConhecimento, x.AnoProc, x.MesProc } into g
                    select new {
                        g.Id1,
                        g.Id2,
                        g.Id3,
                        g.DataConhecimento, 
                        g.AnoProc, 
                        g.MesProc,
                        Valor = g.Sum()
                    };
