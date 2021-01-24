			string sTrg = "SCI.9-12.2.2.PO 1.a";
			Console.WriteLine("{0}", sTrg);
			Regex rX = new Regex(@"SCI\.9-12\.(\d)\.(\d)\.PO[ ](\d{1,2})(.\w)?");
			Console.WriteLine("{0}", rX.Replace(sTrg, 
				delegate (Match m) {
					return "SCHS-S" + m.Groups[1] + "C" + m.Groups[2] + "-" +
						   (m.Groups[3].Length == 1 ? "0" : "") + m.Groups[3] + m.Groups[4];
				}));
