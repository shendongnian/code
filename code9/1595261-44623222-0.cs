    [WebMethod(EnableSession = true)]
        public static string GetEvents()
        {
            List<Appoinment> appoinmentList = new List<Appoinment>();
            AppointmentController appointmentController = new AppointmentController();
            PublicUserProfileController publicUserProfileController = new PublicUserProfileController();
            PublicUserProfile publicUserProfile = new PublicUserProfile();
            //appoinmentList = appointmentController.fetchAppointmentByConsultent(Int32.Parse(Session["ICid"].ToString()));
            appoinmentList = appointmentController.fetchAppointmentByConsultent(3);
            var frontAppoinmentList = new List<object>();
            foreach (var appoinment in appoinmentList)
            {
                publicUserProfile = publicUserProfileController.fetchPublicUserNameById(appoinment.PublicUserProfileId);
                var name = publicUserProfile.FirstName + " " + publicUserProfile.LastName;
                frontAppoinmentList.Add(new
                {
                    id = appoinment.Id.ToString(),
                    title = name,
                    start = appoinment.UtcStartTime,
                    end = appoinment.UtcEndTime
                });
            }
            // Serialize to JSON string.
            JavaScriptSerializer jss = new JavaScriptSerializer();
            String json = jss.Serialize(frontAppoinmentList);
            return json;
        }
