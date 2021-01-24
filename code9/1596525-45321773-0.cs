    using (WebClient client = new WebClient())
            {
                int turn;
                byte[] response;
                string result;
                /* gets response for 81 city */
                for (turn = 500; turn < 581; ++turn)
                {
                    
                    response =
                    client.UploadValues("http://diyanet.gov.tr/PrayerTime/MainPrayerTimesSet", new NameValueCollection()
                    {
                        { "countryName", "2" },
                        { "name", turn.ToString() }
                    });
                    /* without sleep, web service does not response successive requests */
                    System.Threading.Thread.Sleep(5);
                    /* turns incoming byte[] -> string */ 
                    result = System.Text.Encoding.UTF8.GetString(response);
                    Console.WriteLine(result);
                }
            }
