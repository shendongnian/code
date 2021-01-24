    public class CustomNamingStrategy : NamingStrategy
    {
        public CustomNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames)
        {
            ProcessDictionaryKeys = processDictionaryKeys;
            OverrideSpecifiedNames = overrideSpecifiedNames;
        }
        public CustomNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames, bool processExtensionDataNames)
            : this(processDictionaryKeys, overrideSpecifiedNames)
        {
            ProcessExtensionDataNames = processExtensionDataNames;
        }
        public CustomNamingStrategy()
        {
        }
        enum WordState
        {
            Start,
            Lower,
            Upper,
            NewWord
        }
        static string SpaceWords(string s)
        {
            // Adapted from StringUtils.ToSnakeCase()
            // https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Utilities/StringUtils.cs#L191
            // 
            // Copyright (c) 2007 James Newton-King
            //
            // Permission is hereby granted, free of charge, to any person
            // obtaining a copy of this software and associated documentation
            // files (the "Software"), to deal in the Software without
            // restriction, including without limitation the rights to use,
            // copy, modify, merge, publish, distribute, sublicense, and/or sell
            // copies of the Software, and to permit persons to whom the
            // Software is furnished to do so, subject to the following
            // conditions:
            //
            // The above copyright notice and this permission notice shall be
            // included in all copies or substantial portions of the Software.
            //
            // ...
            char wordBreakChar = ' ';
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            StringBuilder sb = new StringBuilder();
            WordState state = WordState.Start;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    if (state != WordState.Start)
                    {
                        state = WordState.NewWord;
                    }
                }
                else if (char.IsUpper(s[i]))
                {
                    switch (state)
                    {
                        case WordState.Upper:
                            bool hasNext = (i + 1 < s.Length);
                            if (i > 0 && hasNext)
                            {
                                char nextChar = s[i + 1];
                                if (!char.IsUpper(nextChar) && nextChar != ' ')
                                {
                                    sb.Append(wordBreakChar);
                                }
                            }
                            break;
                        case WordState.Lower:
                        case WordState.NewWord:
                            sb.Append(wordBreakChar);
                            break;
                    }
                    sb.Append(s[i]);
                    state = WordState.Upper;
                }
                else if (s[i] == wordBreakChar)
                {
                    sb.Append(wordBreakChar);
                    state = WordState.Start;
                }
                else
                {
                    if (state == WordState.NewWord)
                    {
                        sb.Append(wordBreakChar);
                    }
                    sb.Append(s[i]);
                    state = WordState.Lower;
                }
            }
            sb.Replace("Number", "#");
            return sb.ToString();
        }
    }
