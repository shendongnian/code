    <span class="username">
        @{
            Project1.Models.User user = null;  
            if(Session.TryGetAuthenticatedValue(out user))
            {
                //Display username from Session object.
            }
        }
    </span>
