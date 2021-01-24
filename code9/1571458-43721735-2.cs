    public class ImageProcessor {
        private TransformBlock<string, ImageJob> imageProcessor;
        private ActionBlock<ImageJob> handleResults;
        public ImageProcessor() {
            var options = new ExecutionDataflowBlockOptions() {
                BoundedCapacity = 1000,
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };
            imageProcessor = new TransformBlock<string, ImageJob>(fileName => ProcessImage(fileName), options);
            handleResults = new ActionBlock<ImageJob>(job => HandleResults(job), options);
            imageProcessor.LinkTo(handleResults, new DataflowLinkOptions() { PropagateCompletion = true });           
        }
        public async Task RunData() {
            var fileNames = GetFileNames();
            foreach (var fileName in fileNames) {
                await imageProcessor.SendAsync(fileName);
            }
            //all data passed into pipeline
            imageProcessor.Complete();
            await imageProcessor.Completion;
        }
        
        private async Task<ImageJob> ProcessImage(string fileName) {
            //Each of these steps could also be separated into discrete blocks
            var imageBytes = await ReadFileFromDisk(fileName).ConfigureAwait(false); // IO-bound
            var processedImage = RunFancyAlgorithm(imageBytes); // CPU-bound
            var blobUri = await this.azureBlobClient.UploadBlob(processedImage).ConfigureAwait(false); // IO-bound
            return new ImageJob(blobUri);
        }
        private void HandleResults(ImageJob job) {
            //do something with results
        }
    }
