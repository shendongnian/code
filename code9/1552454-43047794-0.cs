     private void getSelectedElement(EA.Repository Rep)
                {
                    EA.Element ele;
                    switch(Rep.GetContextItemType())
                    {
                        case EA.ObjectType.otElement:
                            {
                                ele = Rep.GetContextObject();
                                //Operations on the selected element
                                break;
                            }
                    } 
                }
