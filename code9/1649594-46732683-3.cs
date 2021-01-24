    var Resultado = lista.GroupBy(key => new { key.HoldingGrupoDto.Id, key.UnidadeDto.Id, key.OperadoraDto.Id, key.DataConhecimento, key.AnoProc, key.MesProc },
                                  item => item.Valor)
                         .Select(g => new {
                             Key = g.Key,
                             Valor = g.Sum()
                         }).FirstOrDefault();
