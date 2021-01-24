            var list = Enumerable.Range(1, 10).ToList();
            //Start with reversing the order.
            var result = list.OrderByDescending(x => x)
                //Run a select overload with index so we can use position
                .Select((number, index) => new { number, index })
                //Only include items that are in the right intervals OR is the last item
                .Where(x => ((x.index + 1) % 3 == 0) || x.index == list.Count() - 1)
                //Select only the number to get rid of the index.
                .Select(x => x.number)
                .ToList();
            Assert.AreEqual(8, result[0]);
            Assert.AreEqual(5, result[1]);
            Assert.AreEqual(2, result[2]);
            Assert.AreEqual(1, result[3]);
