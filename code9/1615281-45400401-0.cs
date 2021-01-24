      public class GenericController<T> : ODataController where T : class, IndexedModel
        {
    
            private readonly AirVinylDbContext db;
            private readonly DbSet<T> set;
    
            public GenericController()
            {
                this.db = new AirVinylDbContext();
                this.set = this.db.Set<T>();
            }
            private bool Exists(Guid key)
            {
                return this.set.Any(p => p.Id.Equals(key));
            }
    
    
    
            protected override void Dispose(bool disposing)
            {
                db.Dispose();
                base.Dispose(disposing);
            }
    
            [EnableQuery] // EnableQuery allows filter, sort, page, top, etc.
            public IQueryable<T> Get()
            {
                return this.set.AsQueryable();
            }
    
    
            [EnableQuery]
            public SingleResult<T> Get([FromODataUri] Guid key)
            {
                IQueryable<T> result = Get().Where(p => p.Id.Equals(key));
                return SingleResult.Create(result);
            }
    
    
            public async Task<IHttpActionResult> Post(T obj)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
    
                this.set.Add(obj);
                await db.SaveChangesAsync();
                return Created(obj);
            }
    
    
            public async Task<IHttpActionResult> Patch([FromODataUri] Guid key, Delta<T> delta)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
    
                var entity = await this.set.FindAsync(key);
                if (entity == null)
                {
                    return NotFound();
                }
    
                delta.Patch(entity);
    
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exists(key))
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
    
    
            public async Task<IHttpActionResult> Put([FromODataUri] Guid key, T obj)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
    
                if (key.Equals(obj.Id) == false)
                {
                    return BadRequest();
                }
    
                db.Entry(obj).State = EntityState.Modified;
    
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exists(key))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
    
                return Updated(obj);
            }
    
            public async Task<IHttpActionResult> Delete([FromODataUri] Guid key)
            {
                var entity = await this.set.FindAsync(key);
                if (entity == null)
                {
                    return NotFound();
                }
    
                this.set.Remove(entity);
                await db.SaveChangesAsync();
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
