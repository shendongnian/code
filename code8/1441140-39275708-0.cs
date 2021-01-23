    var OriginalCategoriesIds = db.News.Where(w => w.NewsId == 1).SelectMany(v => v.Categories).ToList();
                                News NewsToUpdate = new News() { NewsId = 1 };
                                db.News.Attach(NewsToUpdate);
    
                                foreach (var category in OriginalCategoriesIds)
                                {
                                    if (!model.SelectedCategoriesIds.Contains(category.CategoryId))
                                    {
                                        db.Categories.Remove(category);// <---change like this
                                    }
    
                                }
    
                                db.SaveChanges();
