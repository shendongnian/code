    var query = UserRepository
                .Get(Id)
                .AsEnumerable()
                .Select(a => new TRDIdenityViewModel
                {
                    FirstName = a.UserProfile.FirstName,
                    LastName = a.UserProfile.LastName,
                    NickName = a.UserProfile.NickName,
                    ProfileImage = new TRDGenericImageViewModel
                    {
                        Id = a.UserProfile.ProfileImage.Id,
                        AspectRatio = a.UserProfile.ProfileImage.Ratio,
                        Url = a.UserProfile.ProfileImage.Url,
                    },
                    Statistics = new TRDUserStatisticsViewModel
                    {
                        PostCount = a.Posts.Count(),
                        CommentCount = a.Comments.Count(),
                        ImageCount = a.Images.Count(),
                        VideoCount = a.Videos.Count(),
                        VoteCount = a.PostVotes.Count(),
                    }
                });
