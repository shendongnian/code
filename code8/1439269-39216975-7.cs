    public abstract class BaseApiController<T, DTO>
    {
    	public virtual DTO Get(int id)
    	{
    		T entity;
    		try
    		{
    			using (var db = new DbConext())
    			{
    				entity = db.Set<T>().Find(id);
    			}
    		}
    		catch (Exception e)
    		{
    			ThrowError(e); // handles logging, verbosity per environment, etc
    			throw new HttpResponseException(HttpStatusCode.InternalServerError);
    		}
    		if (entity == null) throw new HttpResponseException(HttpStatusCode.NotFound);
    		DTO dto = Mapper.Map<DTO>(entity); // project entity to DTO using AutoMapper (or do it manually)
    		return dto;
    	}		
    }
