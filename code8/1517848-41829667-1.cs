    public IQueryable<AttributeElement> GetAll()
     {
            return CompanyRepository.GetQueryable()
                .Include(d => d.CompanyDocuments)
                .ThenInclude(d => d.ListCompanyDocumentsTypes);
     }
