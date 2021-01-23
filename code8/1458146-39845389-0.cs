        public static string ReadLineWithFixedNewlineDelimeter(StreamReader reader, string delim)
        {
            if (reader.EndOfStream)
                return null;
            if (string.IsNullOrEmpty(delim))
            {
                return reader.ReadToEnd();
            }
            var sb = new StringBuilder();
            var delimCandidatePosition = 0;
            while (!reader.EndOfStream && delimCandidatePosition < delim.Length)
            {
                var c = (char)reader.Read();
                if (c == delim[delimCandidatePosition])
                {
                    delimCandidatePosition ++;
                }
                else
                {
                    delimCandidatePosition = 0;
                }
                sb.Append(c);
            }
            return sb.ToString(0, sb.Length - (delimCandidatePosition == delim.Length ? delim.Length : 0));
        }
