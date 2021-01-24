        // GETAll api/category
        [WebMethod]
        public string GetAllCategories()
        {
            using (var db = new nopMass())
            {
                var cats = db.Categories
                            .Where(x => x.ParentCategoryId == 1
                                        && x.Deleted == false
                                        && x.Published == true)
                            .OrderBy(c => c.ParentCategoryId)
                            .ThenBy(c => c.DisplayOrder)
                            .AsEnumerable()
                            .Select(cat => new Category
                            {
                                Id = cat.Id,
                                Name = cat.Name,
                                Description = cat.Description,
                                MetaKeywords = cat.MetaKeywords,
                                MetaDescription = cat.MetaDescription,
                                MetaTitle = cat.MetaTitle,
                                PictureId = cat.PictureId,
                                DisplayOrder = cat.DisplayOrder,
                                CreatedOnUtc = cat.CreatedOnUtc,
                                Product_Category_Mapping = cat.Product_Category_Mapping,
                                ParentCategoryId = cat.ParentCategoryId,
                            })
                            .ToList();
                string XML = "";
                
                #region BuildXMLString
                XML += "<Collection>";
                foreach (var item in cats)
                {
                    XML += "<Category>";
                    XML += "<Id>";
                    XML += item.Id.ToString();
                    XML += "</Id>";
                    XML += "<Name>";
                    XML += item.Name;
                    XML += "</Name>";
                    XML += "<Description>";
                    XML += item.Description;
                    XML += "</Description>";
                    XML += "<MetaKeywords>";
                    XML += item.MetaKeywords;
                    XML += "</MetaKeywords>";
                    XML += "<MetaDescription>";
                    XML += item.MetaDescription;
                    XML += "</MetaDescription>";
                    XML += "<MetaTitle>";
                    XML += item.MetaTitle;
                    XML += "</MetaTitle>";
                    XML += "<PictureUrl>";
                    try
                    {
                        XML += GetPictureUrl(item.PictureId);
                    }
                    catch { }
                    XML += "</PictureUrl>";
                    XML += "<DisplayOrder>";
                    XML += item.DisplayOrder.ToString();
                    XML += "</DisplayOrder>";
                    XML += "<CreatedOnUtc>";
                    XML += item.CreatedOnUtc.ToString();
                    XML += "</CreatedOnUtc>";
                    XML += "<ParentCategoryId>";
                    XML += item.ParentCategoryId.ToString();
                    XML += "</ParentCategoryId>";
                    XML += "</Category>";
                }
                XML += "</Collection>";
                #endregion
                
                return XML;
            }
        }
