using (var csv = new CsvWriter(writer))
{
    csv.Configuration.MemberTypes = CsvHelper.Configuration.MemberTypes.Fields;
.....
}
