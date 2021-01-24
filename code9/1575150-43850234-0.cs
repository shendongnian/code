				bool IsValidate = Membership.ValidateUser(user.UserName, txtOldPassword.Text);
				if (!IsValidate)
				{
					SetChangePasswordMessage("Password entered was wrong or password entered was the same as the previous " + domain.PasswordHistoryLength + " passwords set.");
				}
				else
				{
					new ApplusActiveDirectoryMembership(admin.AdminADUserName, admin.AdminADPassword).ChangePassword(user.UserName, txtOldPassword.Text, txtConfirmNewPassword.Text);
					SetChangePasswordMessage("The password has been successfully changed.");
				}
