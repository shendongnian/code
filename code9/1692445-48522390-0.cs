    internal class ModuleActionDescriptorChangeProvider : IActionDescriptorChangeProvider
    {
        internal static ModuleActionDescriptorChangeProvider Instance { get; } = new ModuleActionDescriptorChangeProvider();
    
        internal CancellationTokenSource TokenSource { get; private set; }
    
        public IChangeToken GetChangeToken()
        {
            TokenSource = new CancellationTokenSource();
            return new CancellationChangeToken(TokenSource.Token);
        }
    }
