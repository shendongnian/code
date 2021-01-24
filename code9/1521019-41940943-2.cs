    [Authorize]
    public class GroupController : DefaultController {
        private readonly IGroupService groupService;
        public GroupController(IGroupService groupService) {
            this.groupService = groupService;
        }
        [HttpPost]
        [AllowAdminOperationsOnly]
        public ActionResult NewGroup(Group _group) {
            try {
                int id_group = 0;
                if (ModelState.IsValid) {
                    id_group = groupService.NewGroup(_group);
                } else {
                    ThrowErrorMessages();
                }
                return Json(new
                {
                    status = "success",
                    title = @Resources.Global.success,
                    text = @Resources.Groups.success_creating_group,
                    messageType = "success",
                    id_group = id_group
                }, JsonRequestBehavior.AllowGet);
            } catch (Exception err) {
                return ErrorHelper(@Resources.Global.error, @Resources.Groups.error_creating_group, err.Message);
            }
        }
    }
