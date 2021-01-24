    public class MySpecialObjectEntityFrameworkDomainDataLayer: IMySpecialObjectDomainData{
        public MySpecialObjectEntityFrameworkDomainDataLayer(MyCoolDbContext context) {
            /* HERE IS WHERE TO SET THE BREAK POINT, HOW MANY TIMES IS THIS RUNNING??? */
            this.entityDbContext = context ?? throw new ArgumentNullException("MyCoolDbContext is null", (Exception)null);
        }
    }
   
