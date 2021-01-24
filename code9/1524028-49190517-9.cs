    public static class ControllerExtensions
    {
        public static int GetUserId(this Controller controller) =>
            int.Parse(controller.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Name).Value);
        public static string GetCurrentUserEmail(this Controller controller) =>
            controller.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
    }
