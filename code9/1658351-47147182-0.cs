            var task = System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                ((System.Security.Principal.WindowsIdentity)this.HttpContext.User.Identity).Impersonate();
                // ...
                // Call to SDK                
                // ...
            });
            task.Wait();
