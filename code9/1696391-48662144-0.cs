    Foreach(EA.DiagramObject dObj in selectedDiagram.DiagramObjects)
    {
           EA.Element ele = Repository.GetElementByID(dObj .ElementID);
           if(ele.Type=="Trigger")
		   {
               //You will get the trigger elements in the diagram
           }
    }
