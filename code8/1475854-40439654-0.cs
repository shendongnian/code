    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<RoomGroup> roomGroup = new List<RoomGroup>() {
                    new RoomGroup() {
                        id = 1,
                        roomdetails = new List<RoomDetails>() {
                            new RoomDetails() {
                                roomcategoryID = "001:AMB1:7736:S7519:8456:115266"
                            },
                            new RoomDetails() {
                                roomcategoryID = "001:AMB1:7736:S7519:8456:33689"
                            },
                        }
                    },
                    new RoomGroup() {
                        id = 2,
                        roomdetails = new List<RoomDetails>() {
                            new RoomDetails() {
                                roomcategoryID = "001:AMB1:7736:S7519:8456:115266"
                            },
                            new RoomDetails() {
                                roomcategoryID = "001:AMB1:7736:S7519:8456:33707"
                            },
                        }
                    },
                    new RoomGroup() {
                        id = 3,
                        roomdetails = new List<RoomDetails>() {
                            new RoomDetails() {
                                roomcategoryID = "001:AMB1:7736:S7519:8456:115266"
                            },
                            new RoomDetails() {
                                roomcategoryID = "001:AMB1:7736:S7519:8456:33695"
                            }
                        }
                    },
                    new RoomGroup() {
                        id = 4,
                        roomdetails = new List<RoomDetails>() {
                            new RoomDetails() {
                               roomcategoryID = "001:AMB1:7736:S7519:8456:115266"
                            },
                            new RoomDetails() {
                               roomcategoryID = "001:AMB1:7736:S7519:8456:115266"
                            }
                        }
                    }
                };
                foreach (RoomGroup group in roomGroup)
                {
                    string output = string.Format("RoomGroup {0} {1}", 
                            group.id.ToString(),
                            string.Join(" ", group.roomdetails.Select(x => "roomCategoryID " + x.roomcategoryID).ToArray())
                            );
                    Console.WriteLine(output);
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
        }
        public class RoomGroup
        {
           public  int id {get;set;}
           public  List<RoomDetails> roomdetails{get;set;}
        }
        public class RoomDetails
        {
           public string roomcategoryID{get;set;}
           public decimal roomPrice{get;set;}
        }
    }
