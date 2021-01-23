    public static class StringExtensions
    {
        private enum UnescapeState
        {
            Unescaped,
            Escaped
        }
    
        public static String Unescape(this String s)
        {
            var sb = new System.Text.StringBuilder();
            UnescapeState state = UnescapeState.Unescaped;
    
            foreach (var ch in s)
            {
                switch (state)
                {
                    case UnescapeState.Escaped:
                        switch (ch)
                        {
                            case 't':
                                sb.Append('\t');
                                break;
                            case 'n':
                                sb.Append('\n');
                                break;
                            case 'r':
                                sb.Append('\r');
                                break;
    						
                            case '\\':
                            case '\"':
                                sb.Append(ch);
                                break;
    
                            default:
                                throw new Exception("Unrecognized escape sequence '\\" + ch + "'");
    
                            //  Finally, what about stuff like '\x0a'? That's a much more 
                            //  complicated state machine. When you see 'x' in Escaped state,
                            //  you transition to UnescapeState.HexDigit0, then either 
                            //  UnescapeState.HexDigit1 or throw an exception, etc. 
                            //  Wicked fun to write. 
                        }
                        state = UnescapeState.Unescaped;
                        break;
    
                    case UnescapeState.Unescaped:
                        if (ch == '\\')
                        {
                            state = UnescapeState.Escaped;
                        }
                        else
                        {
                            sb.Append(ch);
                        }
                        break;
                }
            }
    
            if (state == UnescapeState.Escaped)
            {
                throw new Exception("Unterminated escape sequence");
            }
    
            return sb.ToString();
        }
    }
