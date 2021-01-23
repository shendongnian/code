    Add-Type @‘
        using System;
        using System.Collections.Concurrent;
        using System.Diagnostics;
        using System.Management.Automation;
        using System.Threading;
        [Cmdlet(VerbsLifecycle.Invoke, "Process")]
        public class InvokeProcessCmdlet : Cmdlet {
            [Parameter(Position = 1)]
            public string FileName { get; set; }
            [Parameter(Position = 2)]
            public string Arguments { get; set; }
            protected override void EndProcessing() {
                using(BlockingCollection<Action> messageQueue = new BlockingCollection<Action>()) {
                    using(Process process = new Process {
                        StartInfo=new ProcessStartInfo(FileName, Arguments) {
                            UseShellExecute=false,
                            RedirectStandardOutput=true,
                            RedirectStandardError=true
                        },
                        EnableRaisingEvents=true
                    }) {
                        int numberOfCompleteRequests = 0;
                        Action complete = () => {
                            if(Interlocked.Increment(ref numberOfCompleteRequests)==3) {
                                messageQueue.CompleteAdding();
                            }
                        };
                        process.OutputDataReceived+=(sender, args) => {
                            if(args.Data==null) {
                                complete();
                            } else {
                                messageQueue.Add(() => WriteObject(args.Data));
                            }
                        };
                        process.ErrorDataReceived+=(sender, args) => {
                            if(args.Data==null) {
                                complete();
                            } else {
                                messageQueue.Add(() => WriteVerbose(args.Data));
                            }
                        };
                        process.Exited+=(sender, args) => complete();
                        process.Start();
                        process.BeginOutputReadLine();
                        process.BeginErrorReadLine();
                        foreach(Action action in messageQueue.GetConsumingEnumerable()) {
                            action();
                        }
                    }
                }
            }
        }
    ’@ -PassThru | Select-Object -First 1 -ExpandProperty Assembly | Import-Module
