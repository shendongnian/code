            List<string> Lines = new List<string>(readData.Replace("\r\n", "\n").Split('\n'));
            while (Lines.Count > 0 && !Lines[0].StartsWith("---"))
                Lines.RemoveAt(0);
            // Here, we either have an empty list or a list starting with the line --- 8.8.8.8 ping statistics ---
            float avgPingTime = 0;
            if (Lines.Count > 2)
            {
                // Our important line is now Lines[2], the one starting with "rtt"
                Match M = Regex.Match(Lines[2], @"^rtt [^0-9]*([\d][^\/]+)\/([^\/]+)\/([^\/]+)\/([^ ]+) ms$");
                if (M != null && M.Success) // A match has indeed been found
                {
                    string avgPingString = M.Groups[2].Value;
                    // Now parse that value
                    float.TryParse(avgPingString, System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out avgPingTime);
                }
            }
            if (avgPingTime > 0)
            {
                // We parsed the value correctly here
            }
