    foreach(var father in fathers)
    {
         Response.Write($"Son1={father.Son1}  ");
         Response.Write($"Son2={father.Son2}  ");
         Response.Write($"Son3={father.Son3}  ");
         Response.Write($"Son4={father.Son4}  ");     
         Response.Write(String.Join("  ", father.Son5.Select(son5 => $"Son5={son5}"));    
         Response.Write("<br />");  
    }
