        public override string ToString()
        {
            if (IsGroup)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append('(');
                foreach (QueryEntry entry in Group)
                {
                    sb.Append(entry.ToString());
                }
                sb.Append(')');
                return sb.ToString();
            }
            else if (Type == "expression")
            {
                return Key + ' ' + Operators + ' ' + Value;
            }
            else if (Type == "conjunction")
            {
                return ' ' + Value + ' ';
            }
            return string.Empty;
        }
