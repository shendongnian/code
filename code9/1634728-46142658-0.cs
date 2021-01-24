    return _ctx.LodgingDbSet.GroupJoin(_ctx.RatingDbSet,
                                lodging => lodging.Id,
                                rating => rating.Reservation.Unit.LodgingId,
                                (l, groupedRating) => new LodgingVM
                                {
                                    LodgingId = x.Id,
                                    LodgingName = x.Name,
                                    LodgingAddress = x.Address,
                                    LodgingEmail = x.Email,
                                    LodgingPhone = x.Phone,
                                    LodgingAverageRating = groupedRating.Average(x => x.Score),
                                    LodgingImage = x.Image,
                                    LodgingImageThumb = x.ImageThumb
                                }).OrderBy(o => o.LodgingName).ToList();
