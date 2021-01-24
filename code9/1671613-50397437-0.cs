                MailMessage msg = new MailMessage(from, to)
                {
                    Subject = subject,
                    Body = body
                };
                var htmlContentType = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Html);
                var avHtmlBody = AlternateView.CreateAlternateViewFromString(body, htmlContentType);
                msg.AlternateViews.Add(avHtmlBody);
                string meetingRequestString = GetMeetingRequestString(from, to, subject, body, startTime, endTime);
                System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType("text/calendar");
                ct.Parameters.Add("method", "REQUEST");
                ct.Parameters.Add("name", "meeting.ics");
                AlternateView avCalendar = AlternateView.CreateAlternateViewFromString(meetingRequestString, ct);
                msg.AlternateViews.Add(avCalendar);
                client.Send(msg);
