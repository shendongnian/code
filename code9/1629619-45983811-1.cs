    public class AccountController : ApiController {
        ApplicationUserManager userManager;
        IParentService parentService;
        public AccountController(ApplicationUserManager userManager, IParentService parentService) {
            this.userManager = userManager;
            this.parentService = parentService;
        }
        [AllowAnonymous]
        [Route("RegisterParent")]
        public async Task<IHttpActionResult> RegisterParent(ParentRegisterBindingModel model) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var user = new ApplicationUser() { UserName = model.email, Email = model.email };
            var result = await UserManager.CreateAsync(user, model.password);
            if (result.Succeed) {
                try {
                    userManager.AddToRole(user.Id, "ParentRole");
                    parentService.AssignParent(user);
                } catch (Exception e) {
                    userManager.Delete(user.Id);
                    Console.Write(e);
                    // e returns here with message 
                    return BadRequest(); //OR InternalServerError();
                }
            }
            return Ok();
        }
    }
