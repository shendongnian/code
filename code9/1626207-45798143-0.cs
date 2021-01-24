    var query = from contry in countries
                join company in companies on country.Id equals company.CountryId
                join contract in contracts on company.Id equals contract.CompanyId
                let contract = new SoonObsoleteContractsViewModel
                {
                    CountryName = contry.Name,
                    CompanyName = company.Name,
                    CompanyId = company.CompanyId
                    ContractBeginDate = contract.Begin,
                    ContractEndDate = contract.End,
                    ContractId = contract.Id
                }
                group contract by new { contract.CountryName, contract.CompanyId } into g
                select g.OrderByDescending(c => c.ContractEndDate).First();
