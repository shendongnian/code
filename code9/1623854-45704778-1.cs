	public abstract class Effect
	{
		public const float duration = 1.0f;
	
		public static void boo()
		{
			// this prints 1.0f
			Console.WriteLine(duration);
		}
	}
	
	public class EffectA : Effect
	{
		public new const float duration = 3.0f;
	
		public new static void boo()
		{
			// this prints 3.0f
			Console.WriteLine(duration);
		}
	}
