        RedirectToAction("Index", "Home"); //with this:
          return Content(
            new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(
                new System.Collections.Generic.Dictionary<string, string>
                {
                    {"action", action_type},
                    {"tid", eventId}
                }
            )
        );
    
       // will send response like this {"action":"updated", "tid":"5"} - which is valid response
