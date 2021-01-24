      public bool Edit(News entity)
                {
                    try
                    {
                        News Edited = _ctx.News.Where(i => i.Id == entity.Id).First();
                        _ctx.Entry(Edited).CurrentValues.SetValues(entity);
                        _ctx.SaveChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // TODO log this error
                        return false;
                    }
                }
