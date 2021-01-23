    foreach (var item in Requests)
                {
                  var itemEdit = db.Requests.where(s=>s.Id == item.Id).FirstOrDefault();
                    decimal sold = Requests.Where(a => a.statId == StatusTwo.statId).Sum(a => a.soldAmount);
                    decimal available = amount - sold;
                    if (available >= item.reqAmount)
                    {
                        itemEdit.soldAmount = item.reqAmount;
                        itemEdit.StatusId = StatusOne.StatusId;
                    }
                    db.Entry(itemEdit).State = EntityState.Modified;
                    db.SaveChanges();
                }
