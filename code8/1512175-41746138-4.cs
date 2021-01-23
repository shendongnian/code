    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    using System.Xml;
    using System.Linq;
    
    namespace OrderProcessing {
        public class Job {
            public string Path { get; set; }
    
            public XmlDocument Document { get; set; }
    
            public List<Object> BusinessObjects { get; set; }
    
            public int ReturnCode { get; set; }
    
            public int ID { get; set; }
        }
    
        public class Test {
            ITargetBlock<Job> pathBlock = null;
    
            CancellationTokenSource cancellationTokenSource;
    
            Random rnd = new Random();
    
            private bool ReadDocument(Job job) {
                Console.WriteLine($"ReadDocument {DateTime.Now.TimeOfDay} JobId: {job.ID}");
                Task.Delay(rnd.Next(1000, 3000)).Wait();
    
                // Throw OperationCanceledException if cancellation is requested.
                cancellationTokenSource.Token.ThrowIfCancellationRequested();
    
                // Read the document
                job.Document = new XmlDocument();
    
                // Some checking
                return true;
            }
    
            private bool ValidateXml(Job job) {
                Console.WriteLine($"ValidateXml {DateTime.Now.TimeOfDay} JobId: {job.ID}");
                Task.Delay(rnd.Next(1000, 3000)).Wait();
    
                // Throw OperationCanceledException if cancellation is requested.
                cancellationTokenSource.Token.ThrowIfCancellationRequested();
    
                // Check XML against XSD and perform remaining checks
                job.BusinessObjects = new List<object>();
    
                // Just for tests
                job.BusinessObjects.Add(new object());
                job.BusinessObjects.Add(new object());
    
                // Parse Xml and create business objects
                return true;
            }
    
            private bool ProcessJob(Job job) {
                Console.WriteLine($"ProcessJob {DateTime.Now.TimeOfDay} JobId: {job.ID}");
    
                // Throw OperationCanceledException if cancellation is requested.
                cancellationTokenSource.Token.ThrowIfCancellationRequested();
    
                Parallel.ForEach(job.BusinessObjects, bO => {
                    ImportObject(bO);
                });
    
    
                // Import the job
                return true;
            }
    
            private object ImportObject(object o) {
                Task.Delay(rnd.Next(1000, 3000)).Wait();
    
                return new object();
            }
    
            private void CreateResponse(Job job) {
                if (job.ReturnCode == 100) {
                    Console.WriteLine($"CreateResponse {DateTime.Now.TimeOfDay} JobId: {job.ID}");
    
                }
                else {
                    Console.WriteLine("ID {0} failed to import.", job.ID);
                }
    
                // Create response XML with returncodes
            }
    
            ITargetBlock<Job> CreateJobProcessingPipeline() {
                var loadXml = new TransformBlock<Job, Job>(job => {
                    try {
                        if (ReadDocument(job)) {
                            // For later error handling
                            job.ReturnCode = 100; // success
                        }
                        else {
                            job.ReturnCode = 200;
                        }
    
                        return job;
                    }
                    catch (OperationCanceledException) {
                        job.ReturnCode = 300;
                        return job;
                    }
                }, TransformBlockOptions());
    
                var validateXml = new TransformBlock<Job, Job>(job => {
                    try {
                        if (ValidateXml(job)) {
                            // For later error handling
                            job.ReturnCode = 100;
                        }
                        else {
                            job.ReturnCode = 200;
                        }
    
                        return job;
                    }
                    catch (OperationCanceledException) {
                        job.ReturnCode = 300;
                        return job;
                    }
                }, TransformBlockOptions());
    
    
                var importJob = new TransformBlock<Job, Job>(job => {
                    try {
                        if (ProcessJob(job)) {
                            // For later error handling
                            job.ReturnCode = 100; // success
                        }
                        else {
                            job.ReturnCode = 200;
                        }
    
                        return job;
                    }
                    catch (OperationCanceledException) {
                        job.ReturnCode = 300;
                        return job;
                    }
                }, TransformBlockOptions());
    
                var loadingFailed = new ActionBlock<Job>(job => CreateResponse(job), ActionBlockOptions());
                var validationFailed = new ActionBlock<Job>(job => CreateResponse(job), ActionBlockOptions());
                var reportImport = new ActionBlock<Job>(job => CreateResponse(job), ActionBlockOptions());
    
                //
                // Connect the pipeline
                //
                loadXml.LinkTo(validateXml, job => job.ReturnCode == 100);
                loadXml.LinkTo(loadingFailed);
    
                validateXml.LinkTo(importJob, Job => Job.ReturnCode == 100);
                validateXml.LinkTo(validationFailed);
    
                //importJob.LinkTo(reportImport);
    
                var output = importJob.AsObservable();
                var subscription = output.Subscribe(x => {
                if (x.ReturnCode == 100) {
                    //job success
                    Console.WriteLine($"SendToDataBase {DateTime.Now.TimeOfDay} JobId: {x.ID}");
                }
                else {
                    //handle fault
                    Console.WriteLine($"Job Failed {DateTime.Now.TimeOfDay} JobId: {x.ID}");
                }                
            });
    
                // Return the head of the network.
                return loadXml;
            }
    
            public void Start() {
                cancellationTokenSource = new CancellationTokenSource();
    
                pathBlock = CreateJobProcessingPipeline();
            }
    
            public async void AddJob(string path, int id) {
                Job j = new Job();
                j.Path = path;
                j.ID = id;
    
                await pathBlock.SendAsync(j);
            }
    
            static ExecutionDataflowBlockOptions TransformBlockOptions() {
                return new ExecutionDataflowBlockOptions {
                    MaxDegreeOfParallelism = 8,
                    BoundedCapacity = 32
                };
            }
    
            private static ExecutionDataflowBlockOptions ActionBlockOptions() {
                return new ExecutionDataflowBlockOptions {
                    MaxDegreeOfParallelism = 1,
                    BoundedCapacity = 1
                };
            }
    
            public void Cancel() {
                if (cancellationTokenSource != null)
                    cancellationTokenSource.Cancel();
            }
        }
    
        class Program {
            private static String InputXml = @"C:\XML\Part.xml";
            private static Test _Pipeline;
    
            static void Main(string[] args) {
                _Pipeline = new Test();
                _Pipeline.Start();
    
    
                var data = Enumerable.Range(1, 100);
    
                foreach (var d in data)
                    _Pipeline.AddJob(InputXml, d);
    
                //Wait before closing the application so we can see the results.
                Console.ReadLine();
            }
        }
    }
