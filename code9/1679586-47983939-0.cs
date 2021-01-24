    var ans = (from a in DBTableA
               where a.Identifier == number
               join b in DBTableB on new { a.Code, HouseNo = a.HouseNo.ToString(), a.FirstName, VCode = vCode } equals new { b.Code, b.HouseNo, FirstName = b.BusinessName, b.VCode }
               select b).ToList();
    return ans;
