    public abstract class BaseService
    {
        public abstract void Read(object parm);
    }
    public abstract class GenericBaseService<T> : BaseService
    {
        public override void Read(object parm)
        {
            Read((T)parm);
        }
        public abstract void Read(T parm);
    }
    public class ServiceOne : GenericBaseService<DTOParam>
    {
        public override void Read(DTOParam param)
        {
            //Do something with this DTOParam
        }
    }
    //Now you can do:
    BaseService srv = new ServiceOne();
    srv.Read(dataOnject);
