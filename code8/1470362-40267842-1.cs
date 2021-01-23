    		var x = new UglyThing<string, int>();
			x["a"].Value = 1;
			x["b"].Value = 11;
			x["a"]["b"].Value = 2;
			x["a"]["b"]["c1"].Value = 3;
			x["a"]["b"]["c2"].Value = 4;
			System.Diagnostics.Debug.WriteLine(x["a"].Value);            // 1
			System.Diagnostics.Debug.WriteLine(x["b"].Value);            // 11
			System.Diagnostics.Debug.WriteLine(x["a"]["b"].Value);       // 2
			System.Diagnostics.Debug.WriteLine(x["a"]["b"]["c1"].Value); // 3
			System.Diagnostics.Debug.WriteLine(x["a"]["b"]["c2"].Value); // 4
 
