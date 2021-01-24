    	private void InitEntity(Entity entity) {
    		if (entity == null) {
    			return;
    		}
    		entity.Owner = this;
    		// Anything you want to happen goes here!
    	}
    	private DbSet<Entity> Entities { get; set; }
    	public IEnumerable<Entity> EnumerateEntities() {
    		foreach (Entity entity in this.Entities) {
    			this.InitEntity(entity);
    			yield return entity;
    		}
    	}
    	public IEnumerable<Entity> EnumerateEntities(Func<DbSet<Entity>, IEnumerable<Entity>> filter) {
    		IEnumerable<Entity> ret = filter(this.Entities);
    		foreach (Entity entity in ret) {
    			this.InitEntity(entity);
    			yield return entity;
    		}
    	}
    	public T QueryEntities<T>(Func<DbSet<Entity>, T> filter) {
    		if (filter is Func<DbSet<Entity>, Entity>) {
    			T ret = filter(this.Entities);
    			this.InitEntity(ret as Entity);
    			return ret;
    		}
    
    		if (filter is Func<DbSet<Entity>, IEnumerable<Entity>>) {
    			IEnumerable<Entity> ret = filter(this.Entities) as IEnumerable<Entity>;
    			// You should be using EnumerateEntities, this will prefetch all results!!! Can't be avoided, we can't mix yield and no yield in the same function.
    			return (T)ret.Select(x => {
    				this.InitEntity(x);
    				return x;
    			});
    		}
    
    		return filter(this.Entities);
    	}
    	public void QueryEntities(Action<DbSet<Entity>> filter) => filter(this.Entities);
