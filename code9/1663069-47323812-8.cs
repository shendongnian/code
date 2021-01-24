    var results = appointmentDetails
							.Where(ad => ad.AppDateFrom.Date <= viewmodel.AppointmentDate.Date
									&& ad.AppDateTo.Date >= viewmodel.AppointmentDate.Date
									&& ad.ApprovalStatusID == 2
									&& ad.Appointment.CompanyID == "a3dea87a-804e-4115-98cf-472988cf1678"
									&& ad.Appointment.LocationID == "3165caca-2a48-46f0-bbed-578cff29167t")
							.Select(ad =>
							new
							{
								ID = ad.Appointment.ID,
								AppointmentStatusID = ad.Appointment.AppointmentStatusID,
								Detail = ad
							})
							.AsEnumerable()
							.GroupBy(a => new { a.ID, a.AppointmentStatusID })
							.Select(a => new Appointment
							{
								ID = a.Key.ID,
								AppointmentStatusID = a.Key.AppointmentStatusID,
								AppointmentDetails = a.Select(d => d.Detail).ToList()
							})
							.ToList();
