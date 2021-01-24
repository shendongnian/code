        public static string AddCartItem(this Dictionary<int, string[]> CartList, int pId)
        {
            products p = new products();     
            
            ProductOptions po = new ProductOptions(); 
            if (pId > 0)
            {
                p.GetDataById(pId); 
                po.GetDataByProductId(pId);
            }
            CartList = (Dictionary<int, string[]>)HttpContext.Current.Session["CartList"];
            int count = 1;
            if (p.ID > 0)
            {
                if (CartList.Count > 0)
                {
                    foreach (KeyValuePair<int, string[]> item in CartList)
                    {
                        if (item.Key == p.ID)
                        {
                            count = Convert.ToInt32(item.Value[0]) + 1;
                        }
                    }
                }
                if (count > 1)
                {
                    CartList[p.ID][0] = count.ToString();
                }
                else
                {
                    string[] value = new string[] { count.ToString(), po.Options };
                    CartList.Add(p.ID, value);
                }
            }
            HttpContext.Current.Session["CartList"] = CartList;
            return p.Name; 
        }
    }
