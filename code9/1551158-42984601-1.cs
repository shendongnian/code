    using System.Threading.Tasks.Dataflow;
    
    namespace MyDataflow {
        class MyDataflow {
    
            public void HndlingCompletion() {
                var batchBlock = new BatchBlock<int>(10);
                var broadcastBlock = new BroadcastBlock<int[]>(_ => _);
                var xForm1 = new TransformBlock<int[], int[]>(_ => _);
                var xForm2 = new TransformBlock<int[], int[]>(_ => _);
    
                batchBlock.LinkTo(broadcastBlock, new DataflowLinkOptions() { PropagateCompletion = true });
                broadcastBlock.LinkTo(xForm1);
                broadcastBlock.LinkTo(xForm1);
    
                broadcastBlock.Completion.ContinueWith(broadcastBlockCompletionTask => {
                    if (!broadcastBlockCompletionTask.IsFaulted) {
                        xForm1.Complete();
                        xForm2.Complete();
                    }else {
                        ((IDataflowBlock)xForm1).Fault(broadcastBlockCompletionTask.Exception);
                        ((IDataflowBlock)xForm2).Fault(broadcastBlockCompletionTask.Exception);
                    }
                    
                });
    
                xForm1.Completion.ContinueWith(async _ => {
                    try {
                        await xForm2.Completion;
                        //continue passing completion / fault on to rest of pipeline
                    } catch  {
    
                    }
                });
                
            }
        }
    }
