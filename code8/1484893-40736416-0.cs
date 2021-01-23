    int nbItems = listDonnees.Count ;
    var hashCodes = new List<String>() {"#FFFFFF", "#FFD700", "#FF6347"};
                
    for(int cpt = 0; cpt < nbItems; cpt++)
    {
        string colorcode = string.Empty;
        if(cpt + 1 < nbItems)
        {
           colorcode = listDonnees[cpt].FirstOrDefault(s => hashCodes.Contains(s));
        }
        if(colorcode != string.Empty)
        {
           <td style="background-color:@ViewBag.listDonnees[cpt+1]">colorcode</td>
           //cpt++; See below!    
         }
         else
         {
             var str = String.Join(",", listDonnees[cpt]);
             <td>str</td>
         }
         // I Think your cpt++; needs to be here:
         cpt++;
    }
