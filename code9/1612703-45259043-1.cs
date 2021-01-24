    string[] ipt2 = File.ReadAllLines(input, Encoding.Default);
        HashSet<string> matches = new HashSet<string>();
        List<string> dnMatches = new List<string>();
        string[] patHighMatch = new string[] { @"Tyton(?!.*\bSIT\b)(?!.*\bPLUS\b)", @"\bNOVO.SIT\b" };
        for (int i = 0; i < ipt2.Length; i++) // Geht Zeile für Zeile durch
        {
            if (ipt2[i].StartsWith("T;N;")) // Überprüft die Zeile nur wenn die Zeile mit T;N; anfängt
                foreach (var match in patHighMatch) // Geht alle pattern`s im StringArray durch
                {
                    Match Match = Regex.Match(ipt2[i], match, RegexOptions.IgnoreCase);
                    if (Match.Success)
                        matches.Add(Match.Groups[0].ToString());
                }
            if (matches.Count != 1 && ipt2[i].StartsWith("T;N;"))
            {
                string[] patLowMatch = new string[] { @"\bTyton.SIT.PLUS\b", @"\bTIS.K\b", @"\bSteckmuffenverbindung[^-]\bSTANDARD\b[^-]", @"[^-]\bSTANDARD\bVI\b[^-]" };
                foreach (var match in patLowMatch)
                {
                    Match Match = Regex.Match(ipt2[i], match, RegexOptions.IgnoreCase);
                    if (Match.Success)
                        matches.Add(match);
                }
            }
            if (matches.Count > 0 && ipt2[i].StartsWith("A;N;"))
            {
                ipt2[i] = ipt2[i].Replace("Tyton",String.Join(" ",matches));
                // ipt2[i] = ipt2[i].Replace("Tag", "DONEEE!");
                // Console.WriteLine(ipt2[i].ToString());
                matches.Clear();
                replaces++;
            }
        }
