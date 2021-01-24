    var Resultado = lista.GroupBy(key => new { key.HoldingGrupoDto.Id, key.UnidadeDto.Id, key.OperadoraDto.Id, key.DataConhecimento, key.AnoProc, key.MesProc },
                                  item => item.Valor)
                         .Select(g => new {
                              Id1 = g.HoldingGrupoDto.Id, 
                              Id2 = g.UnidadeDto.Id,
                              Id3 = g.OperadoraDto.Id, 
                              g.DataConhecimento, 
                              g.AnoProc, 
                              g.MesProc,
                             Valor = g.Sum()
                         }).FirstOrDefault();
