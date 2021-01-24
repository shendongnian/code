      public DelegateCommand FooCommand { get; private set; }
      FooCommand = new DelegateCommand(OnFoo, CanFoo);
      private void OnFoo()
      {
         Start();
      }
      private bool CanFoo()
      {
         return someBooleanFunc();
      }
