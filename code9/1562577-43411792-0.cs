        private IEnumerable<FILELOGElements> FileInfo(XElement doc, string FileNo)
        {
            IEnumerable <FILELOGElements> Info = from el in doc.Elements("FILE_NO")
                                              where el.Attribute("ID").Value.ToUpper() == FileNo
                                              select new FILELOGElements
                                              {
                                                  FileNo = el.Attribute("ID").Value.ToUpper(),
                                                  TotPieces = Convert.ToDouble(el.Element("TOTAL_PIECES").Value),
                                                  TotWeight = Convert.ToDouble(el.Element("TOTAL_WEIGHT").Value),
                                                  PiecesUsed = Convert.ToDouble(el.Element("PIECES_USED").Value),
                                                  Pieces = el.Elements("PIECE_WGT").Attributes("CNT").Select(a => Convert.ToDouble(a.Value)).ToList(),
                                                  Weight = el.Elements("PIECE_WGT").Select(a => Convert.ToDouble(a.Value)).ToList()
                                              };
            
            return Info;
        }
    }
    class FILELOGElements
    {
        public string FileNo { get; set; }
        public double TotPieces { get; set; }
        public double TotWeight { get; set; }
        public double PiecesUsed { get; set; }
        public List<double> Pieces { get; set; }
        public List<double> Weight { get; set; }
    }
