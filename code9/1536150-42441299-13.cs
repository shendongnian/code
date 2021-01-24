    bool IRepository.AddResponse(GuestResponse response)
    {
        if (responses.Any(x => x.Email == response.Email)) //here
        {
            if (responses.Any(x => x.WillAttend != response.WillAttend)) //here
            {
                return false;
            }
            var attend = responses.First(x => x.Email == response.Email && x.WillAttend != response.WillAttend);
            attend.WillAttend = response.WillAttend;          
            return true;
        }
        responses.Add(response);
        return true;
    }
