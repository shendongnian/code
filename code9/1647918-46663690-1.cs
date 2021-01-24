       catch (Exception exception)
      {
           string controllerAction = getFormattedRoute();
           iCommCommon.CommWeb.WriteLog("<ERR>", CommUser.piUSER_KEY, controllerAction, exception.Message + "\n" + (exception.InnerException != null ? exception.InnerException.Message : ""));
      }
