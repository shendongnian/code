    public class ActionMeshProcessor {
        private TransformBlock<int, int?> Transformer { get; set; }
        private ActionBlock<int?> CompletionAnnouncer { get; set; }
    
        public ActionMeshProcessor(CancellationToken cancellationToken) {
            var options = new ExecutionDataflowBlockOptions {
                CancellationToken = cancellationToken,
                MaxDegreeOfParallelism = 5,
                BoundedCapacity = 5
            };
    
    
            this.Transformer = new TransformBlock<int, int?>(async input => {
                try {
                    await Task.Delay(TimeSpan.FromSeconds(1)); //donig something complex here!
    
                    if (input > 15) {
                        throw new Exception($"I can't handle this number: {input}");
                    }
    
                    return input + 1;
                } catch (Exception ex) {
                    return null;
                }
                
            }, options);
    
            this.CompletionAnnouncer = new ActionBlock<int?>(async input =>
            {
                if (input == null) throw new ArgumentNullException("input");
    
                Console.WriteLine($"Completed: {input}");
    
                await Task.FromResult(0);
            }, options);
    
            //Filtering
            this.Transformer.LinkTo(this.CompletionAnnouncer, x => x != null);
            this.Transformer.LinkTo(DataflowBlock.NullTarget<int?>());
        }
    
        public async Task ProcessBlockAsync(int[] arr) {
            foreach (var item in arr) {
                await this.Transformer.SendAsync(item); // await if there are no free slots
            }
        }
    }
