            IQueryable<IF_Table> result = db.IF_Table;
            if (!string.IsNullOrEmpty(col1))
            {
                 result = result.Where(x => x.col1 == col1);
            }
            if (!string.IsNullOrEmpty(col2))
            {
                result = result.Where(x => x.col2 == col2);
            }
            if (!string.IsNullOrEmpty(col3))
            {
                result = result.Where(x => x.col3 == col3);
            }
