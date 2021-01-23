	using System;
	using System.Threading.Tasks;
	using System.Threading.Tasks.Dataflow;
	namespace TPLDataFlowExample1
	{
	    class Program
	    {
	        static void Main(string[] args)
	        {
	            var inputListOfObjects = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
	            // Process1 block
	            var process1 = new TransformBlock<int, int>(i => i * 2);
	            // Broadcast block which passes objects to Process2 and Process3
	            var broadCast = new BroadcastBlock<int>(null);
	            // Process2 block
	            var process2 = new TransformBlock<int, string>(i => $"Process 2: {i}");
	            // Process3 block
	            var process3 = new TransformBlock<int, string>(i => $"Process 3: {i}");
	            // Just simple action block which will print the result
	            var print = new ActionBlock<string>(s => Console.WriteLine(s));
	            // Link the output of Process1 block with the input of Broadcast block. Propagate completion to the next block.
	            process1.LinkTo(broadCast, new DataflowLinkOptions { PropagateCompletion = true });
	            // Link the output of Broadcast block with the input of Process2 block. Propagate completion to the next block.
	            broadCast.LinkTo(process2, new DataflowLinkOptions { PropagateCompletion = true });
	            // Link the output of Broadcast block with the input of Process3 block. Propagate completion to the next block.
	            broadCast.LinkTo(process3, new DataflowLinkOptions { PropagateCompletion = true });
	            // Link the output of Process2 block with the input of Print block. 
	            process2.LinkTo(print);
	            // Link the output of Process2 block with the input of print block. 
	            process3.LinkTo(print);
	            // We didn't propagate completion to Print block because it must complete when both Process2 and Process3 blocks are in Completed state.
	            Task.WhenAll(process2.Completion, process3.Completion).ContinueWith(_ => print.Complete());
	            // Post data to the Process1 block
	            foreach (var obj in inputListOfObjects)
	            {
	                process1.Post(obj);
	            }
	            // Mark the Process1 block as complete
	            process1.Complete();
	            // Wait for the last block to process all messages
	            print.Completion.Wait();
	        }
	    }
	}
	// Output:
	//
	// Process 2: 2
	// Process 3: 2
	// Process 3: 4
	// Process 3: 6
	// Process 3: 8
	// Process 3: 10
	// Process 3: 12
	// Process 3: 14
	// Process 3: 16
	// Process 3: 18
	// Process 3: 20
	// Process 2: 4
	// Process 2: 6
	// Process 2: 8
	// Process 2: 10
	// Process 2: 12
	// Process 2: 14
	// Process 2: 16
	// Process 2: 18
	// Process 2: 20
	// Press any key to continue . . .
