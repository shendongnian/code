        class CategoryDto
        {
            public int Code {get;set;}
            public string Description {get;set;}
        }
        //...
        public IQueryable<CategoryDto> GetIQueryable()
        {
            return (from c in entities.categories
                    select new CategoryDto
                    {
                        Code = c.code,
                        Description = c.descripton
                    }).AsQueryable();
        }
