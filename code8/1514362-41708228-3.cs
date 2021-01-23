    var maker = new PartyMaker();
            var tasks = new[] {maker.ShakeItAsync(), maker.ShakeItAsync()};
            Task.WaitAll(tasks);
            foreach (var task in tasks)
            {
                Console.WriteLine(task.Result);
            }
            Console.WriteLine(maker.ShakeItAsync().Result);
