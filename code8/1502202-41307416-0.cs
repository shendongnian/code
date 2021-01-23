    public interface ILightbulbFactory
    {
        Lightbulb MakeLightbulb();
    }
    
    public class LightbulbFactory : ILightbulbFactory
    {
        public Lightbulb MakeLightbulb()
        {
            Do your external resource load and return the object...
        }
    }
    
    public class LightbulbFactoryForTests : ILightbulbFactory
    {
        public Lightbulb MakeLightbulb()
        {
            Create your lightbulb for testing...
        }
    }
