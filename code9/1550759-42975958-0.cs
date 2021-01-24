    int i = 2;
    
    foreach (UITestControl con in uIItemCustom.GetChildren())
                    {
    
                        Description = new HtmlCell(con);
                        Description.FilterProperties[HtmlCell.PropertyNames.ColumnIndex] = "4";
                        Date = new HtmlCell(con);
                        Date.FilterProperties[HtmlCell.PropertyNames.ColumnIndex] = "5";
    
                    if (TestContext.DataRow["BillableLine"].ToString() == Description.InnerText.ToString() && TestContext.DataRow["Date"].ToString() == Date.InnerText.ToString())
                            {
                            HtmlSpan chk = FindControl<HtmlSpan>(x =>
                            {
                                x.Add(HtmlSpan.PropertyNames.Id, "timeMaterialGrid0_ctl0" + i + "_TriStateChkB");
                                x.Add(HtmlSpan.PropertyNames.TagName, "SPAN");
                            });
                            Mouse.Click(chk);
                            break;
                            }
    			// This is the part you need to add - an else and break
    else{
      break;
    }              
                        i++;         
                }
