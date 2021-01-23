    using System;
    using System.Net;
    using System.Security.Principal;
    using Microsoft.Reporting.WebForms;
    [Serializable]
    public sealed class MyReportServerCredentials : IReportServerCredentials
    {
        public WindowsIdentity ImpersonationUser
        {
            get { return null; }
        }
        public ICredentials NetworkCredentials
        {
            get
            {
                return new NetworkCredential("username", "password", "domain");
            }
        }
        public bool GetFormsCredentials(out Cookie authCookie, out string userName,
            out string password, out string authority)
        {
            authCookie = null;
            userName = null;
            password = null;
            authority = null;
            return false;
        }
    }
