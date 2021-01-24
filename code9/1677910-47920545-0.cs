    var items = new BindingList<PRAESENZZEIT>();
                        while (dr.Read())
                        {
                            PRAESENZZEIT pra = null;
                            DateTime datum = Convert.ToDateTime(dr["ZPZ_Datum"]);
                            //calculate parse from and to. Don't store it to Präsenzzeit as it will be accumulated. Therefore it will always be wrong. possible solution would be to store each "phase" separatly and calculate a Total time from there...
                            DateTime von = Convert.ToDateTime(dr["ZPZ_Von"]);
                            if (von.TimeOfDay < new TimeSpan(8, 5, 0))
                                von = new DateTime(von.Year, von.Month, von.Day, 8, 0, 0);
                            DateTime bis = Convert.ToDateTime(dr["ZPZ_Bis"]);
                            pra = items.Select(x => x.ZPZ_Datum == datum).FirstOrDefault();
                            //check if day was already added
                            if (pra != null)
                            {
                                pra.arbeitszeit = pra.arbeitszeit + (bis - von);
                            }
                            else
                            {
                                pra = new PRAESENZZEIT();
                                pra.ZPZ_Datum = datum;
                                // DateTime gehen = DateTime.Now;
                                pra.arbeitszeit = bis - von;
                                // Convert.ToString(Convert.ToInt32(arbeitszeit));
                                items.Add(pra);
                            }
                        }
