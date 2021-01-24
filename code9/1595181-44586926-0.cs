        List<product> prdList = new List<product>();
		private void SetValue()
		{
			product prd1 = new product
			{
				Level = 0,
				PartNumber = "Item A",
				Description = "Product"
			};
			product prd2 = new product
			{
				Level = 0,
				PartNumber = "Item b",
				Description = "batry"
			};
			product prd3 = new product
			{
				Level = 1,
				PartNumber = "Item1",
				Description = "Product"
			};
			product prd4 = new product
			{
				Level = 1,
				PartNumber = "Item2",
				Description = "Product"
			};
			product prd5 = new product
			{
				Level = 1,
				PartNumber = "Item3",
				Description = "Product"
			};
			prdList.Add(prd1);
			prdList.Add(prd2);
			prdList.Add(prd3);
			prdList.Add(prd4);
			prdList.Add(prd5);
		}
		private void CreateTextFile()
		{
			var newPrdList = prdList.GroupBy(x => x.Level).ToList();
			foreach (var levels in newPrdList)
			{
				TextWriter writer = new StreamWriter("D:\\Level" + levels.FirstOrDefault().Level + ".txt");
				writer.Write("Level\tPartnumber\tDescription");
				foreach (var level in levels)
				{
					writer.WriteLine("");
					writer.Write(level.Level.ToString() + "\t");
					writer.Write(level.Description + "\t");
					writer.Write(level.PartNumber + "\t");
					writer.WriteLine("");
				}
				writer.Close();
			}
		}
