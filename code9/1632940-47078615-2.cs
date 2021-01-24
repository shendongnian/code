                IMyServiceContract myServiceObject = new MyService(); // // container.Resolve<IMyServiceContract>();
                HostFactory.Run(x =>
                {
                    x.Service<IMyServiceContract>(s =>
                    {
                        s.ConstructUsing(name => myServiceObject);
                        s.WhenStarted(myso => myso.Start());
                        s.WhenStopped(myso => myso.Stop());
                        s.WhenSessionChanged((myso, hc, chg) => myso.SessionChanged(chg));
                    });
                    x.EnableSessionChanged();
