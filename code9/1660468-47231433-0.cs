    public class TestDescription : Attribute
	{
		public string Desc {get; set;}
	}
	
	public interface ITextExtractor
	{
		string GetText(Attribute attribute);
		Attribute GetAttribute(Enum field);
	}
	
	public class TextExtractor<TAttribute> : ITextExtractor
		where TAttribute: Attribute
	{
		public Func<TAttribute, string> TextGetter {get; private set;}
		public TextExtractor(Func<TAttribute, string> getter){ TextGetter = getter;}
		public Attribute GetAttribute(Enum field)
		{
			return ...;
		}
		public string GetText(Attribute attribute) { return TextGetter((TAttribute)attribute);}
	}
