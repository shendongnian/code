            mock.Setup(m => m.Log<object>(It.IsAny<LogLevel>(),It.IsAny<EventId>(),It.IsAny<object>(),It.IsAny<Exception>(),It.IsAny<Func<object, Exception,string>>()))
                .Callback<LogLevel, EventId, object, Exception, Func<object, Exception, string>>((logLevel, eventId, obj, exception, func) => 
                {
                    string msg = func.Invoke(obj, exception);
                    Console.WriteLine(msg);
                });
