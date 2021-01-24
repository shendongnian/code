    private DbSet<Entity> Entities { get; set; }
    public IEnumerable<Entity> QueryEntities() {
    	foreach (Entity entity in this.Entities) {
    		if (entity != null) {
    			entity.Owner = this;
    		}
    		yield return entity;
    	}
    }
    public IEnumerable<Entity> QueryEntities(Func<DbSet<Entity>, IEnumerable<Entity>> filter = null) {
    	IEnumerable<Entity> ret = null;
    	if (filter == null) {
    		ret = this.Entities;
    	} else {
    		ret = filter(this.Entities);
    	}
    	foreach (Entity entity in ret) {
    		fi (entity != null) {
    			entity.Owner = this;
    		}
    		yield return entity;
    	}
    }
    public Entity QueryEntities(Func<DbSet<Entity>, Entity> filter) {
    	Entity ret = filter(this.Entities);
    	if (ret != null) {
    		ret.Owner = this;
    	}
    	return ret;
    }
    public T QueryEntities<T>(Func<DbSet<Entity>, T> filter) => filter(this.Entities);
    public void QueryEntities(Action<DbSet<Entity>> filter) => filter(this.Entities);
