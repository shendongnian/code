    if (Display.Dispaylist.Count > 0)
            {
                //Initialise the list outside of the loop, just do it once 
                Displayinfo.Dispaylisted = new List<DisplacedModelList>();
                foreach (var d in Display.Dispaylist)
                {
                    requestUri = string.Format("https://maps.googleapis.com/maps/api/place/details/xml?placeid=" + d.Placeid + "&radius=7500&sensor=true&key=AIzaSyA0SrtzNyotUjgqI8cwbfYNrRUkdCoACd8");
                    WebRequest request2 = WebRequest.Create(requestUri);
                    WebResponse response2 = request2.GetResponse();
                    XDocument xdoc2 = XDocument.Load(response2.GetResponseStream());
                    XElement generalElement1 = xdoc2.Element("PlaceSearchResponse");
                    Displayinfo.Dispaylisted.AddRange(
                        (from e in xdoc2.Descendants("result")
                         select new DisplacedModelList()
                         {
                             Name = Convert.ToString(e.Element("name").Value),
                             Address = (e.Element("formatted_address") != null ? Convert.ToString(e.Element("formatted_address").Value) : null),
                             Type = keyword,
                             PhoneNo = (e.Element("international_phone_number") != null ? Convert.ToString(e.Element("international_phone_number").Value) : null),
                             WebSite = (e.Element("website") != null ? Convert.ToString(e.Element("website").Value) : null),
                             Rating = (e.Element("rating") != null ? Convert.ToString(e.Element("rating").Value) : null)
                         }).ToList<DisplacedModelList>()
                    );
                }
            }
            return View(Displayinfo);
