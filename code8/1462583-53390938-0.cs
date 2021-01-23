            public static void LogError(Exception exception, string username)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), new string[] {});
                Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
            }
