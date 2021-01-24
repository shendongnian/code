                data.ToObservable()
                    .Buffer(2)
                    .Zip(Observable.Interval(interval), (x, _) => x)
                    .Timestamp()
                    .Subscribe(x =>
                        {
                            var message = $"buffer {x.Timestamp} - count = {x.Value.Count()}, values - {x.Value.First()}, {x.Value.Last()}";
                            Console.WriteLine(message);
                        });
