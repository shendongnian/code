public class AnnualOrdersViewComponent : ViewComponent {
  public async Task<IViewComponentResult> InvokeAsync(string labelName) {
    … 
  }
}
And then called your tag helper as:
<vc:annual-orders></vc:annual-orders>
Your code would compile without warning, and your page would run without exception—but the view component wouldn't be rendered, and would instead be injected into the source of the page. In fact, this would even happen if you made the view component parameter value optional, as the tag helper syntax doesn't honor optional parameters:
public class AnnualOrdersViewComponent : ViewComponent {
  public async Task<IViewComponentResult> InvokeAsync(string labelName = null) {
    … 
  }
}
Obviously, in either of the above examples, this could be fixed by e.g.,:
<vc:annual-orders label-name="Contrived Example"></vc:annual-orders>
Again, this doesn't address the specifics of your problem, but I imagine developers running up against this issue will likely come across this thread, so I wanted to include this as another troubleshooting step in case the tag helper has already been correctly registered.
 
