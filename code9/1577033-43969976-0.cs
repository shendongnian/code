    public class BailLexer : LISBASICLexer
	{
		public BailLexer(ICharStream input) : base(input) { }
		public override void Recover(LexerNoViableAltException e)
		{
			throw new ParseCanceledException(e);
		}
	}
