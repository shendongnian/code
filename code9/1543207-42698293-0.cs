    var result = from i in dc.vw_Users
        where i.id == id
        select new
        {
            i.UserId,
            i.id,
            i.SiId,
            i.FullName,
            i.UserName,
            i.RoId,
            i.Ro,
            i.Email,
            WelcomeSent =
                i.WelcomeSent != null && i.WelcomeSent.ToString().Length > 0
                    ? DateTime.Parse(i.WelcomeSent.ToString())
                    : new DateTime(),
            i.Signed,
            i.IsPri,
            i.IsApproved,
            IsLocked = i.IsLockedOut,
            i.LoginStatus,
            i.LastLoginDate,
            i.SignRights,
            i.LastPasswordChangedDate,
            i.FailedPasswordAttemptCount,
            i.CompleteDate,
            i.AccessDate,
            i.CertificationDate,
            i.CertificateId,
            i.progress
        };
