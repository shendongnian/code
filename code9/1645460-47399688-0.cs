                        //assume you have your string from Serial Port (COM)
					string[] strArr = data.Split('$'); //split different GPS string
					for (int j = 0; j < strArr.Length; j++)
                    {
                        string strTemp = strArr[j];
                        debug = strTemp;
                        string[] lineArr = strTemp.Split(',');
                        if (lineArr[0] == "GPGGA")
                        {
                            try
                            {
                                //Latitude
                                if (lineArr.Length >= 7 && lineArr[2] != "")
                                {
								    //Latitude
                                    double converted = Convert.ToDouble(lineArr[2]) / 100;
                                    string[] lat = converted.ToString().Split('.');
                                    string altered = lat[1] + "000000000000000000000000";
                                    double me = Convert.ToDouble(lat[0].ToString()) + ((Convert.ToDouble(altered.Substring(0, 6)) / 60)) / 10000;
                                    Latitude = lineArr[3].ToString() + me.ToString();
                                    //Longitude
                                    double converted1 = Convert.ToDouble(lineArr[4]) / 100;
                                    string[] lon = converted.ToString().Split('.');
                                    string altered1 = lon[1] + "000000000000000000000000";
                                    double me1 = Convert.ToDouble(lon[0].ToString()) + ((Convert.ToDouble(altered1.Substring(0, 6)) / 60)) / 10000;
                                    Longitude = lineArr[5].ToString() + me1.ToString();
                                    //Time
                                    string timeMinAndSec = lineArr[1][0].ToString() + lineArr[1][1].ToString();
                                    //Altitude
                                    if (lineArr.Length >= 10)
                                    { 
                                        Altitude = lineArr[9].ToString();
                                    }
								}
							}
						}
					}
