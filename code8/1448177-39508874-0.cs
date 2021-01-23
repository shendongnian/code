     public List<Control> GetvisibleControls(Control parent)
                {
                    List<Control> returnList = new List<Control>();
                    foreach(Control child in parent.Controls)
                    {
                        if (child.Location.X < parent.Width && child.Location.Y < parent.Height)
                            returnList.Add(child);
                    }
                    return returnList;
                }
