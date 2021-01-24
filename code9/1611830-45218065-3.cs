    [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public void SaveNat(NationalityInfo Nat)
        {
            string Conn = ""// Your Connection
            using (SqlConnection con = new SqlConnection(Conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                   //Save }
            }
        }
