            var roleTypeValueFromDatabase = 10;
            var roleType = UserRoleType.FromValueOrDefault(roleTypeValueFromDatabase, UserRoleType.Unknown);
            if (roleType.CanCreateUser)
            {
                // create user..
            }
            // Find roles with specific rights
            var rolesThatCanResetPassword = UserRoleType.GetAll().Where(urt => urt.CanResetUserPassword);
