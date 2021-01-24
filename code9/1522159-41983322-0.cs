        [Route("api/CDS/ExternalLink/{id_cd}")]
        public async Task<List<ExternalLink>> GetAllExternalLinks(int id_cd)
        {
            
            List<ExternalLink> ListAllExternalLinks = new List<ExternalLink>();
                foreach (var item in await db.ExternalLink
                    .Where(EL => EL.id_cd == id_cd)
                    .ToListAsync())
                {
                ExternalLink CDEL = new ExternalLink();
                CDEL.id_cd = item.id_cd;
                CDEL.Name = item.Name;
                if (CDEL.Name == "Itunes") {
                    var query = from EL in db.ExternalLink
                            join AP in db.AffiliateProgram on EL.Name equals AP.AffiliateName
                            select new
                            {
                            AffiliateName = AP.AffiliateName,
                            Name = EL.Name,
                            AffilateCode = AP.AffiliateCode,
                            URL = EL.URL
                            };
                    CDEL.URL = item.URL + query.First().Name + "?mt=1&at=" + query.First().AffilateCode + "&ct=" + id_cd;          
                }
                ListAllExternalLinks.Add(/CDEL);
            }
            return ListAllExternalLinks;
        }
