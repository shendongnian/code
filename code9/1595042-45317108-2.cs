    // Top of program
    using System.Reflection;
    ....
    ....
    string qstring = "propertiesCombinedNamesQuery";
    string query = ""
    gridQueries q2 = new gridQueries();
    MethodInfo methodInfo = q2.GetType().GetMethod(qstring);
    query = (string)methodInfo.Invoke(q2, null);
    ....
