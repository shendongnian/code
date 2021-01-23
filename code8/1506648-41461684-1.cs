    public int Add(UserObjLibrary user)
            {
                UserDAL ud = new UserDAL();
                PasswordBLL pb = new PasswordBLL();
                user.passwordSalt = PasswordBLL.GenerateSalt();
                user.passwordHash = PasswordBLL.EncodePassword(user.password, user.passwordSalt);
                return ud.Add(user);
            }
