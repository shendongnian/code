        class Program
    {
        static void Main(string[] args)
        {
            int[] uploads = new int[] { 600, 2000, 1000 };
            UploadFilesAsync(uploads).ConfigureAwait(true);
            UploadFilesAsync2(uploads).ConfigureAwait(true);
            Console.ReadLine();
        }
        public static async Task UploadFilesAsync(IEnumerable<int> uploads)
        {
            Console.WriteLine("Start version 1");
                  
            uploads.ToList().ForEach(async upload =>
            {
                Console.WriteLine("Start version 1 waiting " + upload);
                await Task.Delay(upload);
                Console.WriteLine("End version 1 waiting " + upload);
            });
            Console.WriteLine("End version 1");
        }
        public static async Task UploadFilesAsync2(IEnumerable<int> uploads)
        {
            Console.WriteLine("Start version 2");
            foreach (var upload in uploads)
            {
                Console.WriteLine("Start version 2 waiting " + upload);
                await Task.Delay(upload);
                Console.WriteLine("End version 2 waiting " + upload);
            }
            Console.WriteLine("End version 2");
        }
    }
