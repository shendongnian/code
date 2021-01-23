    // trim off any whitespace on the ends
    string term = value.Trim();
    
    // remove and replace extended spaces with a single space
    RegexOptions options = RegexOptions.None;
    Regex regex = new Regex("[ ]{2,}", options);
    term = regex.Replace(term, " ");
    
    // break down the property into a collection of strings
    List<string> searchTerms = term.Split(' ')
        .Select(v => v.Trim().ToLower())
        .ToList();
                
    // query the dbset
    IEnumerable<employee> data = this.employees
        .Where(e => searchTerms.Any(s => e.fname.Contains(s)) ||
                    searchTerms.Any(s => e.lname.Contains(s)) ||
                    searchTerms.Any(s => e.dept.name.Contains(s)) ||
                    searchTerms.Any(s => e.dept_sub.name.Contains(s))) // new line
                    // e.dept.dept_subs.Where(d => 
                    //      searchTerms.Any(s => d.name.Contains(s))).Any())
        .Where(e => e.isActive == true)
        .OrderBy(e => e.lname)
        .ThenBy(e => e.fname);
