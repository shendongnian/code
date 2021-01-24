    abstract class ControlWithChildren : IUserInterface
    {
      ...
      protected IEnumerable<IUserInterface> children;
      public virtual void Redraw() { 
        foreach(var child in children) child.Redraw();
    }
    class Panel : ControlWithChildren
    {
      ...
      public override void Redraw()
      {
        ... redraw panel elements ...
        base.Redraw();
      }
    }
    class PanelWithTitle : Panel
    {
      ...
      public override void Redraw()
      {
        ... redraw title element ...
        base.Redraw();
      }
    }
