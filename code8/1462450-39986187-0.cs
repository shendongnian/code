    using System;
    using System.Linq;
    using System.Collections.Generic;
    namespace palletSorter
    {
	class MainClass
	{
		public static void Main(string[] args)
		{
			
			var integerArray = new int[] { 2575, 92, 1200, 640, 290, 730, 50, 23, 500};
			CreateBestPallets(integerArray);
		}
		private static void CreateBestPallets(int[] items)
		{
			var sortedItems = items.OrderByDescending(c => c).ToList();
			while (sortedItems.Count > 0)
			{
				var totalWeight = 0;
				var pallet = new List<int>();
				var removedItems = new List<int>();
				foreach (var item in sortedItems)
				{
					if (pallet.Count == 20)
						break;
					if ((totalWeight + item) < 2800)
					{
						totalWeight += item;
						pallet.Add(item);
						removedItems.Add(item);
					}
				}
				foreach (var item in removedItems)
				{
					sortedItems.Remove(item);
				}
				var printString = "";
				foreach (var item in pallet)
				{
					printString += item + ",";
				}
				Console.WriteLine("Pallet Combination: " + printString + "\tTotal Weight: " + totalWeight);
			}
		}
	}
    }
