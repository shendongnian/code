    public ActionResult CheckOut(int idCheck)
            {
                int index = isExisting(idCheck);
                if(index != -1) { 
                    foreach (Item item in ((List<Item>)Session["cart"]).ToList()) {
                        Item.Cl.Amount--;
                        Delete(Item.Cl.Id);
                    }
                }
                return View();
            }
