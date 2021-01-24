    var query1 = dbContext.Oceny_przedmioty    
               .Join(dbContext.Studenci,
                  post => post.ID_Studenta,        
                  meta => meta.ID_Studenta,  
                  (post, meta) => new { meta.ST_Nr_indeksu, post.OPrz_Ocena })
                .Where(postAndMeta => postAndMeta.ST_Nr_indeksu == 11000);    
           dataGridView1.DataSource = query1.ToList();
