            var ws = new WebSocket4Net.WebSocket(url);
            ws.Open();
            
            ws.DataReceived += (sender, args) => Console.WriteLine(args.Data);
            ws.MessageReceived += (sender, args) => Console.WriteLine(args.Message);
            ws.Opened += (sender, args) =>
            {
                Console.WriteLine("opened: " + args);
                ws.Send(json);
            };
            ws.Error += (sender, args) => Console.WriteLine("error: " + args);
            Console.ReadLine();
