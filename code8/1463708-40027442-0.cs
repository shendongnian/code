                string[] inputs = {
                                      "#Title# and #Content#",
                                      "Product #TemplateName# #_Full_Product_Name_# more text. text text #_Short_Description_#"
                                  };
                string pattern = "(?'string'#[^#]+#)";
                foreach (string input in inputs)
                {
                    MatchCollection matches = Regex.Matches(input, pattern);
                    Console.WriteLine(string.Join(",",matches.Cast<Match>().Select(x => x.Groups["string"].Value).ToArray()));
                }
                Console.ReadLine();
