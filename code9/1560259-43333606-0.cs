    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    static async Task<long> PostprocessAsync(long x) { ... }
    IObservable<Message> streamOfMessages = ...;
    var streamOfTasks = new TransformBlock<long, long>(async msg => 
        await PostprocessAsync(msg));
    // easily convert block into observable
    IObservable<long> streamOfResults = streamOfTasks.AsObservable();
