            Console.WriteLine("5a - Read values at an interval of 1 second, for 20 seconds.");
            var readValueIds = new ReadValueId[]
            {
                new ReadValueId{ NodeId= NodeId.Parse("i=2258"), AttributeId = Attributes.Value }, // column 0
                new ReadValueId{ NodeId= NodeId.Parse("i=2258"), AttributeId = Attributes.Value }, // column 1
            };
            var cts = new CancellationTokenSource(20000);
            while (!cts.IsCancellationRequested)
            {
                var resp = session.Read(null, 0, TimestampsToReturn.Both, readValueIds, out DataValueCollection results, out DiagnosticInfoCollection infos);
                Console.WriteLine($"ts:{results[0].SourceTimestamp}, c0: {results[0].Value}, c1: {results[1].Value}");
                await Task.Delay(1000);
            }
