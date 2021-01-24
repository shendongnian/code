    var query = (from user in _dbContext.LinkClubeUser
                 Join club in _dbContext.Clube on user.IdClub equals club.Id into cu
                 let clubUser = cu.DefaultIfEmpty() // outer join if you need it
                    Where clubUser.IdUser == "9faea9f3-28d7-4e34-8572-3102726d3c75")
                    Select  new
                    {
                        Nome = user.Nome,
                        NomeNaCamisola = user.NomeNaCamisola,
                        NumNaCamisola = user.NumNaCamisola,
                        Posicao = user.Posicao,
                        Situacao = user.Situacao,
                        DataInscricao = (DateTime)clubUser.Max(p => p.DataInscricao)
                    }).Take(1);
