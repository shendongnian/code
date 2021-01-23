     public void Audittrail()
        {
            if(isCurrentUserAuthorized())
{
            try
            {
                AUDITTRAIL audittrail = new AUDITTRAIL();
                audittrail.PROGNAME = "PrimaryMarket";
                audittrail.PROGOPTION = Convert.ToString(Session["PROGOPTION"]);
                audittrail.IOTIME = DateTime.Now;
                audittrail.LOGUSER = Convert.ToDecimal(Session["UserId"]);
                audittrail.IPSMSDATE = db.DTTRACKs.Max(z => z.CURRDATE);
                db.AUDITTRAILs.Add(audittrail);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                ExceptionLogging.SendErrorToText(e);
                Response.Redirect("/Account/Error/");
            }
