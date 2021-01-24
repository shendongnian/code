    public class BaseClass 
    {
      public virtual void Add() { ... }
      public virtual void Edit() { this.BaseGet(); }
      public virtual void Get() { this.BaseGet(); }
      private void BaseGet() { ... }
    }
