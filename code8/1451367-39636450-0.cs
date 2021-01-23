    class Program
    {
        static void Main(string[] args)
        {
            BaseImageView.ApplyEffect();
            // Or
            EffectClass.ApplyEffect();
        }
    }
    public abstract class EffectClass
    {
        public static void ApplyEffect()
        {
            // Effect of awesomeness
        }
    }
    public class BaseImageView : EffectClass
    {
        
    }
