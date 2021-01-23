    class Foo
    {
      private string __bar;
      public Foo(string bar)
      {
          this.set_Bar(bar);
      }
      public string get_Bar() { return this.__bar; }
      private void set_Bar(string b) { this.__bar = b; }
    }
