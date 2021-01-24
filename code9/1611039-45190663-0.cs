    var ids = new StringBuilder();
    var aspects = new StringBuilder();
    foreach (RiskAspect riskAspect in aspects)
    {           
        ids.AppendLine(riskAspect.Id);  // You can use Append to keep in the same line
        aspects.AppendLine(riskAspect.AspectHazard);
    }
    impactRow.SetField("AspectId", ids.ToString());
    impactRow.SetField("Aspect", aspects.ToString());
