    var resultAdo = from x in lista
                    group x.Valor by new { x.HoldingGrupoDto.Id, x.UnidadeDto.Id, x.OperadoraDto.Id, x.DataConhecimento, x.AnoProc, x.MesProc } into g
                    select new {
                        Id1 = g.HoldingGrupoDto.Id, 
                        Id2 = g.UnidadeDto.Id,
                        Id3 = g.OperadoraDto.Id, 
                        g.DataConhecimento, 
                        g.AnoProc, 
                        g.MesProc,
                        Valor = g.Sum()
                    };
