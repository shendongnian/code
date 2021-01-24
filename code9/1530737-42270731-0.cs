    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            enum State
            {
                GET_FLIGHT,
                EMBARKATION,
                PASSENGER_HEADER,
                CLASS,
                PASSENGERS,
                DONE
            }
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                State state = State.GET_FLIGHT;
                string flight = "";
                DateTime date;
                string embarkation = "";
                string destination = "";
                string _class = "";
                string inputline = "";
                while((inputline = reader.ReadLine()) != null)
                {
                    if (inputline.Trim().Length  > 0)
                    {
                        switch (state)
                        {
                            case State.GET_FLIGHT :
                                string flightPattern = @"FLIGHT:\s+(?'flight'.+)DATE:\s+(?'date'[^$]+)$";
                                Match flightDate = Regex.Match(inputline, flightPattern);
                                flight = flightDate.Groups["flight"].Value.Trim();
                                string dateStr = flightDate.Groups["date"].Value.Trim();
                                date = DateTime.Parse(dateStr);
                                state = State.EMBARKATION;
                                break;
                            case State.EMBARKATION :
                                string embarkPattern = @"EMBARKATION:\s+(?'embarkation'.+)DEST:\s+(?'dest'[^$]+)$";
                                Match embarkDest = Regex.Match(inputline, embarkPattern);
                                embarkation = embarkDest.Groups["embarkation"].Value.Trim();
                                destination = embarkDest.Groups["dest"].Value.Trim();
                                state = State.PASSENGER_HEADER;
                                break;
                            case State.PASSENGER_HEADER:
                                state = State.CLASS;
                                break;
                            case State.CLASS :
                                _class = inputline;
                                state = State.PASSENGERS;
                                break;
                            case State.PASSENGERS :
                                Passenger.GetPassengers(inputline);
                                state = State.DONE;
                                break;
                        }
                    }
                }
            }
            public class Passenger
            {
                public static List<Passenger> passengers = new List<Passenger>();
                public string number { get; set; }
                public string lName {get; set;}
                public string fName {get; set;}
                public string type { get; set;}
                public string seat { get; set; }
                public string bags {get; set; }
                public string weight { get; set; }
                public string tag { get; set;}
                public string ticket { get; set;}
                public string inFlight {get; set; }
                public string trOrg { get; set;}
                public string otFlt { get; set;}
                public string fDst { get; set; }
                public string special { get; set; }
                //LNAME/FNAME/TYPE/SEAT/BAGS/WEIGHT/BAGTAG/TKT#/IN.FLT/TR.ORG/OT.FLT/F.DST/SPECIAL
                public static void GetPassengers(string inputline)
                {
                    string endPattern = @"(?'passengers'.+)\.\s\d+\sTOTALS:";
                    Match passengersMatch = Regex.Match(inputline, endPattern);
                    string passengers = passengersMatch.Groups["passengers"].Value.Trim();
                    string passengerPattern = 
                              @"(?'no'\d+)\s" +
                              @"(?'lname'[^/]+)/" +
                              @"(?'fname'[^/]+)/" +
                              @"(?'type'[^/]+)/" +
                              @"(?'seat'[^/]+)/" +
                              @"(?'bags'[^/]+)/" +
                              @"(?'weight'[^/]+)/" +
                              @"(?'tag'[^/]+)/" +
                              @"(?'ticket'[^/]+)/" +
                              @"(?'inFlight'[^/]+)/" +
                              @"(?'trOrg'[^/]+)/" +
                              @"(?'otFlt'[^/]+)/" +
                              @"(?'fDst'[^/]+)/" +
                              @"(?'special'[\w\.]+)";
                    MatchCollection  passengerMatch = Regex.Matches(passengers, passengerPattern);
                    foreach (Match match in passengerMatch)
                    {
                        Passenger newPassenger = new Passenger();
                        Passenger.passengers.Add(newPassenger);
                        newPassenger.number = match.Groups["no"].Value;
                        newPassenger.lName = match.Groups["lname"].Value;
                        newPassenger.fName = match.Groups["fname"].Value;
                        newPassenger.type = match.Groups["type"].Value;
                        newPassenger.seat = match.Groups["seat"].Value;
                        newPassenger.bags = match.Groups["bags"].Value;
                        newPassenger.weight = match.Groups["weight"].Value;
                        newPassenger.tag = match.Groups["tag"].Value;
                        newPassenger.ticket = match.Groups["ticket"].Value;
                        newPassenger.inFlight = match.Groups["inFlight"].Value;
                        newPassenger.trOrg = match.Groups["trOrg"].Value;
                        newPassenger.otFlt = match.Groups["otFlt"].Value;
                        newPassenger.fDst = match.Groups["fDst"].Value;
                        newPassenger.special = match.Groups["special"].Value; 
                    }
                }
            }
        }
    }
