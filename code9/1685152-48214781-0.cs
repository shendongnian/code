    catch (SqlException exception)
    {
        throw new HttpResponseException(
            Request.CreateErrorResponse(HttpStatusCode.ServiceUnavailable, exception));
    }
    catch (ArgumentException exception)
    {
        throw new HttpResponseException(
            Request.CreateErrorResponse(HttpStatusCode.Conflict, exception.Message));
    }
