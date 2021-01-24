     public A()
        {
            VisibilityProvider = new VisibilityStateProvider(this);
            var something = VisibilityProvider["test"];
        }
