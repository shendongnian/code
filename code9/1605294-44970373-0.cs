        public IEnumerable<SelectListItem> ReverseMonthsLists()
        {
            var stringViewOfDates = GetDates().Select(_ => _.ToString("MMM yyyy")).ToList();
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Selected = true, Text = stringViewOfDates[0], Value = stringViewOfDates[0] });
            for (int i = 1; i < stringViewOfDates.Count(); i++)
            {
                list.Add(new SelectListItem { Selected = false, Text = stringViewOfDates[i], Value = stringViewOfDates[i] });
            }
            return list;
        }
