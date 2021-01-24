    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    
    public static class Example
    {
        private class Dto
        {
            public Dto(string filePath, byte[] data)
            {
                FilePath = filePath;
                Data = data;
            }
    
            public string FilePath { get; }
            public byte[] Data { get; }
        }
    
        public static async Task ProcessFiles(string path, IProgress<ProgressReport> progress)
        {
            int totalFilesFound = 0;
            int totalFilesRead = 0;
            int totalFilesHashed = 0;
            int totalFilesUploaded = 0;
    
            DateTime lastReported = DateTime.UtcNow;
    
            void ReportProgress()
            {
                if (DateTime.UtcNow - lastReported < TimeSpan.FromSeconds(1)) //Try to fire only once a second, but this code is not perfect so you may get a few rapid fire.
                {
                    return;
                }
                lastReported = DateTime.UtcNow;
                var report = new ProgressReport(totalFilesFound, totalFilesRead, totalFilesHashed, totalFilesUploaded);
                progress.Report(report);
            }
            
    
            var getFilesBlock = new TransformBlock<string, Dto>(filePath =>
            {
                var dto = new Dto(filePath, File.ReadAllBytes(filePath));
                totalFilesRead++; //safe because single threaded.
                return dto;
            });
    
            var hashFilesBlock = new TransformBlock<Dto, Dto>(inDto =>
                {
                    using (var md5 = System.Security.Cryptography.MD5.Create())
                    {
                        var outDto = new Dto(inDto.FilePath, md5.ComputeHash(inDto.Data));
                        Interlocked.Increment(ref totalFilesHashed); //Need the interlocked due to multithreaded.
                        ReportProgress();
                        return outDto;
                    }
                },
                new ExecutionDataflowBlockOptions{MaxDegreeOfParallelism = Environment.ProcessorCount, BoundedCapacity = 50});
    
            var writeToDatabaseBlock = new ActionBlock<Dto>(arg =>
                {
                    //Write to database here.
                    totalFilesUploaded++;
                    ReportProgress();
                },
                new ExecutionDataflowBlockOptions {BoundedCapacity = 50});
            
            getFilesBlock.LinkTo(hashFilesBlock, new DataflowLinkOptions {PropagateCompletion = true});
            hashFilesBlock.LinkTo(writeToDatabaseBlock, new DataflowLinkOptions {PropagateCompletion = true});
            
            foreach (var filePath in Directory.EnumerateFiles(path))
            {
                await getFilesBlock.SendAsync(filePath).ConfigureAwait(false);
                totalFilesFound++;
                ReportProgress();
            }
            
            getFilesBlock.Complete();
    
            await writeToDatabaseBlock.Completion.ConfigureAwait(false);
            ReportProgress();
        }
    }
    
    public class ProgressReport
    {
        public ProgressReport(int totalFilesFound, int totalFilesRead, int totalFilesHashed, int totalFilesUploaded)
        {
            TotalFilesFound = totalFilesFound;
            TotalFilesRead = totalFilesRead;
            TotalFilesHashed = totalFilesHashed;
            TotalFilesUploaded = totalFilesUploaded;
        }
    
        public int TotalFilesFound { get; }
        public int TotalFilesRead{ get; }
        public int TotalFilesHashed{ get; }
        public int TotalFilesUploaded{ get; }
    }
