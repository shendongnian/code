    public static XrmServiceContextExtensions
    {
         public static T GetEntityRecordById<T>(this XrmServiceContext ctx, Guid Id) where T: Entity {
          return ctx.CreateQuery<T>().Where(e => e.Id == Id).FirstOrDefault();
         }
    }
