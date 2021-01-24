    var Resultado = lista.GroupBy(key => new { Id1 = key.HoldingGrupoDto.Id, Id2 = key.UnidadeDto.Id, Id3 = key.OperadoraDto.Id, key.DataConhecimento, key.AnoProc, key.MesProc },
                                  item => item.Valor)
                         .Select(g => new {
                              g.Id1,
                              g.Id2,
                              g.Id3,
                              g.DataConhecimento, 
                              g.AnoProc, 
                              g.MesProc,
                              Valor = g.Sum()
                         }).FirstOrDefault();
