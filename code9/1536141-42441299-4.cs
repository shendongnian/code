    bool IRepository.AddResponse(GuestResponse response)
    {
        if (responses.Any(x => x.Email == response.Email))
        {
            if (responses.Any(x => x.WillAttend == response.WillAttend))
            {
                return false;
            }
            var attend =  responses.FirstOrDefault(x => x.Email == response.Email && x.WillAttend == response.WillAttend);
            if (attend != null)
            {
                attend.WillAttend = response.WillAttend;
            }
          
            return true;
        }
        responses.Add(response);
        return true;
    }
