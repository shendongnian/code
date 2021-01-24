		public override void Recover(Parser recognizer, RecognitionException e)
		{
			IToken token = recognizer.CurrentToken;
			string message = string.Format("parse error at line {0}, position {1} right before {2} ", token.Line, token.Column, GetTokenErrorDisplay(token));
			BasicEnvironment.SyntaxError = message;
