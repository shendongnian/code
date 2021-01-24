    var resultAdo = from x in lista
                    group x.Valor
                    by new { x.HoldingGrupoDto.Id, x.UnidadeDto.Id, x.OperadoraDto.Id, x.DataConhecimento, x.AnoProc, x.MesProc } into g
                    select new {
                        Key = g.Key,
                        Valor = g.Sum()
                    };
