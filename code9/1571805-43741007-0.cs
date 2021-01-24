     /// <summary>
            /// Gets all size from database
            /// </summary>
            /// <returns>Returns a list of Sizes</returns>
            public List<Size> GetSizes()
            {
                using (var context = new ExamContext())
                {
                    var sizes = context.SizeEntities.ToList();
    
                    //Convert SizeEntities list to Size (Business Objects) list
                    var targetList = sizes
                      .Select(x => new Size() { Id = x.Id, SizeName =  x.SizeName})
                      .ToList();
    
                    return targetList;
                    //return Mapper.Map<List<SizeEntity>, List<Size>>(sizes);
                } 
            }
