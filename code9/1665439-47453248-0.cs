        protected void Session_Start(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
			    string currentUser = HttpContext.Current.User.Identity.Name;
                Int32 expiryMin = Convert.ToInt32(ConfigurationManager.AppSettings["CacheExpirationInMinutes"]);
				
				// call our procedure
				auditLog(currentUser);
				
				bool IsActive = accessMaintenance.IsActive(currentUser);
				if (IsActive)
                {
					// handling if user is valid/not locked...
				}
				else
				{	
					// Other handling if user is locked...
					
				}
				
			}
		}
