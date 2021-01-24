    Parallel.ForEach(videos, new ParallelOptions { MaxDegreeOfParallelism = 4 },
            vid =>
            {
                try
                {
                    //Maybe those processes are trying to work on the same file and can't access it?
                    //It's probably better to use the event Exited than WaitForExit
                    psi.Arguments = $"-i {vid} -i watermarker.png -threads 4 -filter_complex \"overlay = 275:350\" C:\\Users\\Developer\\Desktop\\Eh\\Watermarked{Interlocked.Increment(ref i)}.mp4";
                    var p = Process.Start(psi);
                    p.WaitForExit();
                    Console.WriteLine($"{vid} is watermarked");
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error parsing that file");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            });
        Console.ReadLine();
