            ModelContainer _dataContext = new ModelContainer();
            Guid gId= Guid.Parse(ArtistID);
            var artists = _dataContext.Artists.Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.Id,
                x.Country,
                x.City,
                x.artSpecialty,
                x.approval_status,
                x.ProfilePic,
                x.Nationality,
                x.Website,
                x.Instagram,
                x.FaceBook,
                x.Twitter
            }).Where(x => x.Id.Equals(gId)).FirstOrDefault();  
