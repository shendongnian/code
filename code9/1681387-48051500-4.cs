	    var doc = Application.ActiveUIDocument.Document;
		FilteredElementCollector Collector = new FilteredElementCollector(doc);
		ICollection<Element> StructuralFraming = Collector.OfClass(typeof(FamilyInstance)).OfCategory(BuiltInCategory.OST_StructuralFraming).ToList();		
		List<int> bIntegerList = new List<int> (from Element element in StructuralFraming select Convert.ToInt32(doc.GetElement(element.GetTypeId()).LookupParameter("b").AsValueString())).ToList();
     	List<int> dIntegerList = new List<int>(from Element element in StructuralFraming select Convert.ToInt32(doc.GetElement(element.GetTypeId()).LookupParameter("d").AsValueString())).ToList();
     	List<int> ClIntegerList = new List<int>(from Element element in StructuralFraming select Convert.ToInt32(element.LookupParameter("Cut Length").AsValueString())).ToList();
     
     	
     	var wrapperList = bIntegerList.Zip(dIntegerList, (b, d) => new { b, d });
        var dimListReal = wrapperList.Zip(ClIntegerList, (w, cl) => new Dimensions() { b = w.b, d = w.d, CutLength = cl });
        var Order = from m in dimListReal orderby m.b, m.d, m.CutLength select m;
            foreach (var n in Order)
            {
               TaskDialog.Show("Test", n.b.ToString() + " x " + n.d.ToString() + " x " + n.CutLength.ToString());
            }
