        public override System.Threading.Tasks.Task OnConnected()
        {
            string clientId = GetClientId();
            if (Users.IndexOf(clientId) == -1)
            {
                Users.Add(clientId);
            }
            //if (!string.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session["UserInfoID"])))
            //{
            //    var detail = _userRepo.GetUserDetailByUserID(UserId);
            //    if (detail != null)
            //    {
            //        if (!string.IsNullOrEmpty(clientId))
            //        {
            //            detail.CreatedBy = UserId;
            //            bool Result = _userRepo.AddUserDetail(detail);
            //        }
            //    }
            //}
            // Send the current users
            SendUserList(Users);
            return base.OnConnected();
        }
