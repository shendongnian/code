        catch (ArgumentException e)
        {
            Response.StatusCode = 400;
            return new ContentResult {Content = e.Message };
        }
