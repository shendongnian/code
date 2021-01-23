     //Responsible for filtering case studies when item in DropDownList is selected. 
        public PartialViewResult CaseStudiesByIndustryPartial(string id)
        {
            if (id == "Select an industry") return PartialView(
                _context.CaseStudies.OrderByDescending(c => c.CaseStudyDate)
                    .ThenBy(c => c.CaseStudyTitle).ToList());
            else return PartialView(
                _context.CaseStudies.Where(c => c.CaseStudyIndustry == id).OrderByDescending(c => c.CaseStudyDate)
                     .ThenBy(c => c.CaseStudyTitle).ToList());
        }
