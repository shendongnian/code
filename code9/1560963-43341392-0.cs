            for (int x = 0; x < lottoN.GetLength(0); x++) {
            	Console.Write("\nGame ");
                for (int y = 0; y < lottoN.GetLength(1); y++) {
			        Console.Write($"{lottoN[x, y],2}");
                }
             }
