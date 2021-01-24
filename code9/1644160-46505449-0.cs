    public interface IResolvable
    {
        void Resolve(Resolver resolver);
    }
    public interface I1 : IResolvable { //... }
    public interface I2 : IResolvable { //... }
    
    public class Resolver
    {
        public void Resolve(I1 i) { //... }
        public void Resolve(I2 i) { //... }
    }
    
    public abstract class BaseClass : IResolvable 
    { 
        public abstract void Resolve(Resolver resolver);
        //... 
    }
    
