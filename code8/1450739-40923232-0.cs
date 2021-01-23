            var sub = new SubsidiarySearchBasic();
            var res = netSuiteService.search(sub);
            if (res.status.isSuccess)
            {
                if (res.totalPages == res.pageIndex)
                {
                    var result = res.recordList.ToList().Any() ? res.recordList.ToList().Cast<Subsidiary>().ToList() : null;
                }
                else
                {
                    var resultados = res.recordList.ToList().Cast<Invoice>().ToList();
                    for (var i = 2; i <= res.totalPages; i++)
                    {
                        var resPages = netSuiteService.searchMoreWithId(res.searchId, i);
                        if (resPages.status.isSuccess)
                        {
                            resultados.AddRange(res.recordList.ToList().Cast<Invoice>().ToList());
                        }
                    }
                }
            }
            else
            {
                throw new Exception(string.Join(",", res.status.statusDetail.ToList()));
            }
