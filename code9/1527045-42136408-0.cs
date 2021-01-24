            int i = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while(true)
            {
                Console.ReadKey(true);//True makes it so you don't see the key in Console
                if(sw.ElapsedMilliseconds < 2000)
                {
                    i++;
                    sw.Restart();
                }
                else
                {
                    sw.Stop();
                    break;
                }
            }
            Console.WriteLine("Pressed amount: " + i);
            Console.ReadKey();
