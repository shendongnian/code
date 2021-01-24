    public class DownloadAttachmentsHandler
    {
        public static object Cast(object obj, Type t)
        { 
            try
            {
                var param = Expression.Parameter(obj.GetType());
                return Expression.Lambda(Expression.Convert(param, t), param)
                     .Compile().DynamicInvoke(obj);
            }
            catch (TargetInvocationException ex)
            {
                 throw ex.InnerException;
            }         
        }
    
        public DownloadAttachmentsHandler(BasePageElementMap basePageElementMap)
        {
            Type type = basePageElementMap.GetType();
            dynamic foo = Cast(basePageElementMap, type);
        }
    }
