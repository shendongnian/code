                Content content = new Content("text/plain", "Is %name% and %surname% your name and surname?");
                contents.Add(content);
                mail.Contents = contents;
                //Tracking Settings
                TrackingSettings tracking = new TrackingSettings();
                OpenTracking opentracking = new OpenTracking();
                opentracking.Enable = true;
                tracking.OpenTracking = opentracking;
                mail.TrackingSettings = tracking;
                dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.Body.ReadAsStringAsync().Result);
                Console.WriteLine(response.Headers.ToString());
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }
    }
