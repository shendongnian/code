       public string CreateHtml(Form formInfo, XmlNode _MainNode,string oldHtml)
           {
               ConvertXmlToHtml(_MainNode, ref Result);  
           }
       public void ConvertXmlToHtml(XmlNode XmlElement, ref string s)
            {
                
                PropertyInfo _propList = new PropertyInfo(); 
       #region grid for create arrye
    
                foreach (XmlNode item in XmlElement.ChildNodes)
                {
                    if (item.Name == "AvailableItems" || item.Name == "DataSource" || item.Name == "GridBinding")
                    {
                        continue;
                    }
                    if ((item as XmlElement).Attributes["Type"].Value == "Grid")
                    {
                        string Id_elem = (item as XmlElement).Attributes["ID"].Value;
                    
                        foreach (XmlNode itemgrigOut in XmlElement.ChildNodes)
                        {
                            
                            if (itemgrigOut.Name == "GridBinding")
                            {
                                countgrid++;
                                if (countgrid < 2)
                                      s += "<script>  $(document).ready(function() { var object_grid = {" ;
    
                                foreach (XmlNode itemgrigIn in itemgrigOut)
                                {
                                    if (Id_elem == (itemgrigIn as XmlElement).Attributes["ID"].Value)
                                    {
                                        s += Id_elem + " :[  ";
                                        if (Orientation == "Horizontal" || Orientation == "" || Orientation == null)
                                        {
                                            //ساخت گرید مورد نظر                                    
                                        }
                                        else
                                        {
                                            foreach (XmlNode itemcildgrid in itemgrigIn)
                                            {
                                              
                                                if ((itemcildgrid as XmlElement).Attributes[Properties.Resources.PropertiesInfo] != null)
                                                    _propList = new PropertyInfo() { PropertyList = (itemcildgrid as XmlElement).Attributes[Properties.Resources.PropertiesInfo].Value };
                                                s += " { ID : " + ReturnAttribute((itemcildgrid as XmlElement), "IDgrid", false);
                                                s += ", Visible : " + ReturnAttribute((itemcildgrid as XmlElement), "Visible", false);
                                                s += ", VisibleIndex : " + ReturnAttribute((itemcildgrid as XmlElement), "VisibleIndex", false);
                                                s += ", ReadOnly : " + ReturnAttribute((itemcildgrid as XmlElement), "ReadOnly", false);
                                                s += ", SortOrder : " + ReturnAttribute((itemcildgrid as XmlElement), "SortOrder", false);
                                                s += ", Mask : " + ReturnAttribute((itemcildgrid as XmlElement), "Mask", false);
                                                s += ", IsCondition : " + ReturnAttribute((itemcildgrid as XmlElement), "IsCondition", false);
                                                s += ", ISFormulla : " + ReturnAttribute((itemcildgrid as XmlElement), "ISFormulla", false);
                                                s += ", ReadOnly : " + ReturnAttribute((itemcildgrid as XmlElement), "ReadOnly", false);
                                                s += ", IsForce : " + ReturnAttribute((itemcildgrid as XmlElement), "IsForcegrid", false);
    
                                                s += "}, ";
                                            }
                                            s += "], ";
    
                                        }
                                    }
    
                                }
    
    
                            }
                        }
                       
                    }
                  
    
                }
                if (countgrid == CountAll_grid)
                    s += " } }); </script> ";
                #endregion
    
    
                #region grid
    
                foreach (XmlNode item in XmlElement.ChildNodes)
                {
                    childCount++;
                    if (item.Name == "AvailableItems"  || item.Name == "DataSource" || item.Name == "GridBinding")
                    {
                        continue;
                    }
                    if ((item as XmlElement).Attributes["Type"].Value == "Grid")
                    {
                        string Id_elem = (item as XmlElement).Attributes["ID"].Value;
             
                     
                        foreach (XmlNode itemgrigOut in XmlElement.ChildNodes)
                        {
          
                            if (itemgrigOut.Name == "GridBinding")
                           {
                                //شمارش تعداد گریدها
                                countgrid++;
                                  if (countgrid ==0)
                                {    }
    
                                foreach (XmlNode itemgrigIn  in itemgrigOut)
                                {
                                    if (Id_elem == (itemgrigIn as XmlElement).Attributes["ID"].Value)
                                    {
                                        if (Orientation == "Horizontal" || Orientation == "" || Orientation == null)
                                        {
                                            //ساخت گرید مورد نظر
                                            s += string.Format("<br/><div  dir = 'rtl' align = 'center' class='table-responsive'><div class='row well'>" +
                                                "<table id=" + Id_elem + "cellpadding='0' cellspacing='0'></table> <div id = pager_" + Id_elem + "></div></div></div>"
                                             );
                                        }
                                        else
                                        {
                                           s += " <div id=" + Id_elem + "myDiv" + " dir='rtl' align='center' class='table-responsive'></div> " +
                                                " <script>  $(document).ready(function() {var " + Id_elem + "Divresult  = $(" + "'" + "<div id=" + Id_elem + "Div" + " ></div>" + "'" + ") ; " +
                                              " $(" + Id_elem + "Div" + ").append(" + Id_elem + "Divresult);   var " + Id_elem + " = new grid(" + "'" + Id_elem + "'" + "," + countgrid + ");" + Id_elem + ".init(); }); </script> ";
    $(document).ready(function() {var object_grid = {" + Id_elem  +" :[  ";
                               
    
                                        }
                                    }
                                 
                                }
                              
    
                            }
                        
                        }
                  
                          
               }
                    #endregion
            }
