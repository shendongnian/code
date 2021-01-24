        public void Execute()
        {
            //Parallel.ForEach(Files, (file) =>
            //{
            //    Resize.ResizeImage(file.FullName);
            //}
            //);
            Parallel.ForEach(Files, new ParallelOptions() { MaxDegreeOfParallelism = 2 }, (file) => { Resize.ResizeImage(file.FullName); } );
            
        }
