    public static class ControllerExtension {
      public static string UserName(this Controller controller) {
        return controller.User.Identity.Name;
      }
    }
