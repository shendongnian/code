    public class MyArrayHandler {
        public async Task GetMinMaxSum() {
            var myArray = Enumerable.Range(0, 1000);
            var maxTask = Task.Run(() => myArray.Max());
            var minTask = Task.Run(() => myArray.Min());
            var sumTask = Task.Run(() => myArray.Sum());
            var results = await Task.WhenAll(maxTask,
                                             minTask,
                                             sumTask);
            var max = results[0];
            var min = results[1];
            var sum = results[2];
        }
    }
