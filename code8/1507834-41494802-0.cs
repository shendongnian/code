    public abstract class BaseController : Controller
    {
        virtual public ActionResult SaveNote()
        {
            throw new NotImplementedException();
        }
    }
    public class RoomAController : BaseController
    {
        [Authorize(Roles = "RoomAEditors")]
        public override ActionResult SaveNote()
        {
            return base.SaveNote();
        }
    }
    public class RoomBController : BaseController
    {
        [Authorize(Roles = "RoomBEditors")]
        public override ActionResult SaveNote()
        {
            return base.SaveNote();
        }
    }
