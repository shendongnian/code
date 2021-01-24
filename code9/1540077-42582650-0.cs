    public Word GetByID(long id)
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    const string wordQuery = "SELECT * FROM Word WHERE Id = @Id AND Word.SoftDelete = 0 ";
                    Word _word = cn.Query<Word>(wordQuery, new { Id = id }).FirstOrDefault();
                    if(_word != null && _word.Id != 0)
                    {
                        const string definationQuery = "SELECT * FROM Defination where WordId = @WordId AND SoftDelete = 0";
                        List<Defination> _defination = cn.Query<Defination>(definationQuery, new { WordId = _word.Id }).ToList();
                        _word.Definations = _defination;
                        if(_defination != null && _defination.Any())
                        {
                            const string exampleQuery = "SELECT * FROM Example where DefinationId = @DefinationId AND SoftDelete = 0";
                            for (int i=0; i<_defination.Count(); i++ )
                            {
                                _defination[i].Examples = cn.Query<Example>(exampleQuery, new { DefinationId = _defination[i].Id }).ToList();                            
                            }                        
                        }
                    }
    
                    return _word;
                }
            }
