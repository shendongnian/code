            foreach (Claim cl in ((ClaimsIdentity)(User.Identity)).Claims)
            {
                switch (cl.Type)
                {
                    case ClaimTypes.Email:
                        currentUser.Mail = cl.Value;
                        break;
                    case ClaimTypes.Name:
                    case ClaimTypes.Surname:
                        currentUser.Name = cl.Value;
                        break;
                    case ClaimTypes.GivenName:
                        currentUser.FirstName = cl.Value;
                        break;
                 }
             }
