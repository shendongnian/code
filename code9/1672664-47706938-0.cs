	public class IsMod
	{
		public static Matcher Equal(ModData otherMod)
		{
			return new ModMatcher(otherMod);
		}
	}
	internal class ModMatcher : Matcher
	{
		private readonly ModData _mod;
		public ModMatcher(ModData mod)
		{
			_mod = mod;
		}
		public override bool Matches(object o)
		{
			ModData m = (ModData)o;
			return _mod.Val.Equals(m.Val);
		}
		public override void DescribeTo(TextWriter writer)
		{
			writer.Write("Value same ");
			writer.Write(_mod.Val);
		}
	}
