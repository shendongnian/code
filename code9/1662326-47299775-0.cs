        private static void pause()
        {
            if (Console.OpenStandardInput(1) != Stream.Null)
            {
                Console.Out.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
