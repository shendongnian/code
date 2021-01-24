				Dictionary<string, int> test = new Dictionary<string, int>();
						test.Add("dave", 12);
						test.Add("john", 14);
						int v;
						test.TryGetValue("dave", out v);
				    {
								Console.WriteLine(v);
						}
