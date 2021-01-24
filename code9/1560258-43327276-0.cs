    using System;
    using System.Collections.Generic;
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    using NUnit.Framework;
    
    namespace HandlingStreamInOrder {
        
        [TestFixture]
        public class ItemHandlerTests {
    
            [Test]
            public async Task Items_Are_Output_In_The_Same_Order_As_They_Are_Input() {
                var itemHandler = new ItemHandler();
                var timerEvents = Observable.Timer(TimeSpan.Zero, TimeSpan.FromMilliseconds(250));
                timerEvents.Subscribe(async x => {
                    var data = (int)x;
                    Console.WriteLine($"Value Produced: {x}");                
                    var dataAccepted = await itemHandler.SendAsync((int)data);
                    if (dataAccepted) {
                        InputItems.Add(data);
                    }                
                });
    
                await Task.Delay(5000);
                itemHandler.Complete();
                await itemHandler.Completion;
    
                CollectionAssert.AreEqual(InputItems, itemHandler.OutputValues);
            }
    
            private IList<int> InputItems {
                get;
            } = new List<int>();
        }
    
        public class ItemHandler {
    
    
            public ItemHandler() {            
                var options = new ExecutionDataflowBlockOptions() {
                    BoundedCapacity = DataflowBlockOptions.Unbounded,
                    MaxDegreeOfParallelism = Environment.ProcessorCount,
                    EnsureOrdered = true
                };
                PostProcessBlock = new TransformBlock<int, int>((Func<int, Task<int>>)PostProcess, options);
    
                var output = PostProcessBlock.AsObservable().Subscribe(x => {
                    Console.WriteLine($"Value Output: {x}");
                    OutputValues.Add(x);
                });
            }
    
            public async Task<bool> SendAsync(int data) {
                return await PostProcessBlock.SendAsync(data);
            }
    
            public void Complete() {
                PostProcessBlock.Complete();
            }
    
            public Task Completion {
                get { return PostProcessBlock.Completion; }
            }
    
            public IList<int> OutputValues {
                get;
            } = new List<int>();
    
            private IPropagatorBlock<int, int> PostProcessBlock {
                get;
            }
    
            private async Task<int> PostProcess(int data) {
                if (data % 3 == 0) {
                    await Task.Delay(TimeSpan.FromSeconds(2));
                }            
                return data;
            }
        }
    }
