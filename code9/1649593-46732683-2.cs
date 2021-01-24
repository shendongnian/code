    var Resultado = lista.GroupBy(x => new { x.HoldingGrupoDto.Id, Id2 = x.UnidadeDto.Id, Id3 = x.OperadoraDto.Id, x.DataConhecimento, x.AnoProc, x.MesProc })
                         .Select(group => new {
                             Key = group.Key,
                             Valor = group.Sum(item => item.Valor)
                         }).FirstOrDefault();
