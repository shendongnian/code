            Guid userid = user.Id;
            string email = user.Email;
            string username = user.UserName;
            string avatarurl = user.Details.AvatarUrl;
            string firstname = user.Details.FirstName;
            var sql = @"INSERT INTO
                    [Users]
                        ([Id], [Email], [UserName], [EmailConfirmed], [PhoneNumberConfirmed], [AccessFailedCount], [TwoFactorEnabled], [LockoutEnabled])
                    VALUES
                        (@Id, @Email, @Username, 'false', 'false', 0, 'false', 'false')";
            SqlParameter[] groupIdParam =
            {
                new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                {
                    Value = userid
                },
                new SqlParameter("@Email", SqlDbType.NVarChar)
                {
                    Value = email
                },
                new SqlParameter("@Username", SqlDbType.NVarChar)
                {
                    Value = username
                }
            };
            _context.Database.ExecuteSqlCommand(sql, groupIdParam);
