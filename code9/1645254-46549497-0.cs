             private class R2SortHelper : System.Collections.IComparer
                {
                    public int Compare(object x, object y)
                    {
                        Model xModel = (Model)x;
                        Model yModel = (Model)y; 
                       if((Model.Valid()==true) && (yModel.Valid()==true))
                        { 
                        double m1 = xModel.R2() + xModel.GetHashCode();
                        double m2 = yModel.R2() + yModel.GetHashCode();
                        return (m1 > m2) ? -1 : ((m1 < m2) ? 1 :0);   
                        }
                       return 0;
                   }
              }
