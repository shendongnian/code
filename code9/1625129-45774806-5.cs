    var sumTask = Task.Run(() => array.Sum());
    var avgTask = Task.Run(() => array.Average());
    var prodTask = Task.Run(() => array.Aggregate(1.0, (acc, val) => acc * Math.Sqrt(val)));
    Task.WaitAll(sumTask, avgTask, prodTask);
    sum = sumTask.Result;
    average = avgTask.Result;
    product = prodTask.Result;
