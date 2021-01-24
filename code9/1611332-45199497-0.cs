			var result = GetCoinSets(priceChecker );    		
			// display result
			for (int i = 0; i < result.Count; i++) {
				string valuesSeparatedByComma = string.Join(", ", result[i]);
			
				Debug.WriteLine($"Combinaison #{i + 1}: {valuesSeparatedByComma}");
			}
