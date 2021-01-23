    public static class WebHelpers
    {
    	public static DTO GetHelper<T, DTO>(Func<T> getMethod)
    	{
    		T entity;
    		try
    		{
    			entity = getMethod();
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
