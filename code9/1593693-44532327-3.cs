    var user = userService.GetUserByName(User.Identity.Name);
    var favorites = from m in context.FavoriteMessages
                    where m.UserId == user.UserId && m.OnlineRoomId == user.OnlineRoomId 
                    select new {
                       UserName = user.Name,
                       m.Instance,
                       m.CreatedOn
                    };
    return Json(favorites.ToList(), JsonRequestBehavior.AllowGet);
