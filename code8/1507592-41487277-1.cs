    var selectedOrder = from s in order
                where s.clientID == "123"
                group s by new {s.workerId, s.id, s.clientID}
                into g
                select
                new
                {
                    id = g.Key.id,
                    workerId = g.Key.workerId,
                    Datex = g.Max(s => s.timestamp),
                    clientID = g.Key.clientID
                };
