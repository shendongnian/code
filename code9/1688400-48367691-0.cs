     public class NewsAnnouncementsController /*NewsController*/: ODataController
     {
            //
            // GET: /News/
            private SchoolEntities entities = new SchoolEntities();
        
            private bool NewsExists(string key)
            {
                return entities.NewsAnnouncements.Any(p => p.Id == key);
            }
        
        
            //
            //
            // The parameterless version of the Get method returns the entire Products collection. The Get method with a key parameter looks up a product by its key (in this case, the Id property).
            //The [EnableQuery] attribute enables clients to modify the query, by using query options such as $filter, $sort, and $page
            [EnableQuery]
            public IQueryable<NewsAnnouncement> Get()
        
            {
                return entities.NewsAnnouncements;
            }
            [EnableQuery]
            public SingleResult<NewsAnnouncement> Get([FromODataUri] string key)
            {
                IQueryable<NewsAnnouncement> result = entities.NewsAnnouncements.Where(p => p.Id == key);
                return SingleResult.Create(result);
            }
        
            //To enable clients to add a new product to the database, add the following method to ProductsController.
            public async Task<IHttpActionResult> Post(NewsAnnouncement newsItem)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                entities.NewsAnnouncements.Add(newsItem);
                await Task.Delay(10);
                entities.SaveChanges();
                return Created(newsItem);
            }
        
            //PATCH performs a partial update. The client specifies just the properties to update.
        
            public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<NewsAnnouncement> product)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var entity = entities.NewsAnnouncements.Find(key);
                if (entity == null)
                {
                    return NotFound();
                }
                product.Patch(entity);
                try
                {
                    await Task.Delay(10);
                    entities.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(key))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Updated(entity);
            }
        
        
            public async Task<IHttpActionResult> Put([FromODataUri] string key, NewsAnnouncement updateNews)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (key != updateNews.Id)
                {
                    return BadRequest();
                }
                entities.Entry(updateNews).State = EntityState.Modified;
                try
                {
                    await Task.Delay(10);
                    entities.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(key))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Updated(updateNews);
            }
        
            // Notice that the controller overrides the Dispose method to dispose of the EntitiesContext.
            protected override void Dispose(bool disposing)
            {
                entities.Dispose();
                base.Dispose(disposing);
            }
        
        }
