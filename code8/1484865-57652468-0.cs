     public void logoutJson()
         {
            Response.StatusCode = (int)HttpStatusCode.BadRequest; //Send Error Status to Ajax call
            Response.StatusDescription = Url.Action("Index", "Account"); //Url you want to redirect
         }
