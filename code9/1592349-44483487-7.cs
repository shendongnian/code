        public class BailLexer : LISBASICLexer
        {
            public BailLexer(ICharStream input) : base(input) { }
            public override IToken Emit()
            {
                IToken token = base.Emit();
                switch (token.Type)
                {
                case ID :
                    {
                    TokenExtent extent = new TokenExtent("ID", token.StartIndex, token.StopIndex);
                    BasicEnvironment.TokenExtents.Add(extent);
                    break;
                    }
                    case COMMENT :
                    {
                    TokenExtent extent = new TokenExtent("COMMENT", token.StartIndex, token.StopIndex);
                    BasicEnvironment.TokenExtents.Add(extent);
                    break;
                    }
                    case WS:
                    {
                    TokenExtent extent = new TokenExtent("WS", token.StartIndex, token.StopIndex);
                    BasicEnvironment.TokenExtents.Add(extent);
                    break;
                    }
