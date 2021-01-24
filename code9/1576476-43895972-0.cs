	public abstract class AbstractController<TModelType> : Controller
	{
		public abstract JsonResult MustOverrideMethod(TModelType item);
		...
	}
	public class SpecificController : AbstractController<MyModelType>
	{
        [HttpPost]
		public override JsonResult MustOverrideMethod(MyModelType item)
		{
			// The ModelBinder should bind the form input to the item parameter in this method
		}
	 }
