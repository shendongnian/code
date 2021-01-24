    var d = 2.147483648;
    //Replace , and . for international usability
    var temp = d.ToString().Replace(".", string.Empty).Replace(",", string.Empty);
    if (temp.Length < 10) {
         var i = Convert.ToInt32(temp);
    } else {
         //there is a big change that the number is not fitting into a int => Do some error handling or use a long or Keep the string or ...
    }
