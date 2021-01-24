      public DelegateCommand FooCommand { get; private set; }
      FooCommand = new DelegateCommand(OnFoo, CanFoo);
      private void OnFoo()
      {
         ProcessFoo(ListViewName.SelectedItems);
      }
      private bool CanFoo()
      {
         return someBooleanFunc();
      }
