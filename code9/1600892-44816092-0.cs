               Appointment app = new Appointment(service);
               app.Subject = appointment.Subject;
               app.Body = appointment.Body;
               app.Start = Convert.ToDateTime(appointment.Start);
               app.End = Convert.ToDateTime(appointment.End);
               app.Location = appointment.Location;
               if (appointment.Attachments != null &&
                   appointment.Attachments.Count > 0)
               {
                   foreach (var att in appointment.Attachments)
                   {
                       app.Attachments.AddFileAttachment(att.FileName);
                   }
               }
               app.Save(SendInvitationsMode.SendToNone);
               
               foreach (string obj in appointment.Attendees)
               {
                   app.RequiredAttendees.Add(obj);
               }
              app.Update(ConflictResolutionMode.AutoResolve, SendInvitationsOrCancellationsMode.SendToAllAndSaveCopy);
