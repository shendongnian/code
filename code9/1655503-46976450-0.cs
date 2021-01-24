                string input = "{\"page\":0,\"bookmaker_urls\":[],\"block_service_id\":\"team_summary_block_teammatchessummary\",\"team_id\":1244,\"competition_id\":0,\"filter\":\"all\",\"new_design\":false}";
                input.Replace("{", "");
                input.Replace("}", "");
                string[] groups = input.Split(new char[] { ',' });
                string pattern = "\"(?'name'[^:]+)\":(?'value'.*)";
                foreach (string group in groups)
                {
                    string data = group.Replace("\\","");
                    Match regData = Regex.Match(data, pattern);
                    Console.WriteLine("name : '{0}', value : '{1}'", regData.Groups["name"].Value, regData.Groups["value"].Value.Replace("\"",""));
