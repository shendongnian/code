    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                reader.MoveToContent();
                while (!reader.EOF)
                {
                    if (reader.Name != "Placemark")
                    {
                        reader.ReadToFollowing("Placemark");
                    }
                    if (!reader.EOF)
                    {
                        XElement placemark = (XElement)XElement.ReadFrom(reader);
                        Location location = new Location();
                        Location.locations.Add(location);
                        XElement name = placemark.Elements().Where(x => x.Name.LocalName == "name").FirstOrDefault();
                        location.name = (string)name;
                        XElement longitude = placemark.Descendants().Where(x => x.Name.LocalName == "longitude").FirstOrDefault();
                        location.longitude = (int?)longitude;
                        XElement latitude = placemark.Descendants().Where(x => x.Name.LocalName == "latitude").FirstOrDefault();
                        location.latitude = (int?)latitude;
                        XElement altitude = placemark.Descendants().Where(x => x.Name.LocalName == "altitude").FirstOrDefault();
                        location.alt = (int?)altitude;
                        XElement tilt = placemark.Descendants().Where(x => x.Name.LocalName == "tilt").FirstOrDefault();
                        location.tilt = (int?)tilt;
                        XElement heading = placemark.Descendants().Where(x => x.Name.LocalName == "heading").FirstOrDefault();
                        location.heading = (double?)heading;
                        XElement range = placemark.Descendants().Where(x => x.Name.LocalName == "range").FirstOrDefault();
                        location.range = (double?)range;
                        XElement coordinates = placemark.Descendants().Where(x => x.Name.LocalName == "coordinates").FirstOrDefault();
                        if (coordinates != null)
                        {
                            List<string> coordinatesArray = ((string)coordinates).Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                            foreach(string coordinate in coordinatesArray)
                            {
                                string[] coordinateArray = coordinate.Split(new char[] { ',' });
                                Coordinate newCoordinate = new Coordinate();
                                if (location.coordinates == null) location.coordinates = new List<Coordinate>();
                                location.coordinates.Add(newCoordinate);
                                newCoordinate.longitude = double.Parse(coordinateArray[0]);
                                newCoordinate.latitude = double.Parse(coordinateArray[1]);
                                newCoordinate.alt = double.Parse(coordinateArray[2]);
                            }
                                
                        }
                    }
                }
            }
        }
        public class Location
        {
            public static List<Location> locations = new List<Location>();
            public string name { get; set; }
            public int? longitude { get; set; }
            public int? latitude { get; set; }
            public int? alt { get; set; }
            public int? tilt { get; set; }
            public double? heading { get; set; }
            public double? range { get; set; }
            public List<Coordinate> coordinates { get; set; }
        }
        public class Coordinate
        {
            public double longitude { get; set; }
            public double latitude { get; set; }
            public double alt { get; set; }
        }
    }
