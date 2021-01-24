    public class MinMaxSumTests {
        [Test]
        public async Task GetMinMaxSumAsync() {            
            var myArray = Enumerable.Range(0, 10000000).Select(x => (long)x).ToArray();
            var sw = new Stopwatch();
            sw.Start();
            var maxTask = Task.Run(() => myArray.Max());
            var minTask = Task.Run(() => myArray.Min());
            var sumTask = Task.Run(() => myArray.Sum());
            var results = await Task.WhenAll(maxTask,
                                             minTask,
                                             sumTask);
            var max = results[0];
            var min = results[1];
            var sum = results[2];
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
        [Test]
        public void GetMinMaxSum() {            
            var myArray = Enumerable.Range(0, 10000000).Select(x => (long)x).ToArray();
            var sw = new Stopwatch();
            sw.Start();
            long tempMin = 0;
            long tempMax = 0;
            long tempSum = 0;
            for (int i = 0; i < myArray.Length; i++) {
                if (myArray[i] < tempMin)
                    tempMin = myArray[i];
                if (myArray[i] > tempMax)
                    tempMax = myArray[i];
                tempSum += myArray[i];
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
