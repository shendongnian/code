            try
            {
                // your code...
            }
            catch (Exception e)
            {
                string strErrorPath = Request.Url.PathAndQuery;
                SendErrorToPersonalErrorMessage(e, strErrorPath);
            }
