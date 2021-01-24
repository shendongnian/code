updatechild(objCas.ECC_Decision, PromatCon.ECC_Decision.Where(c => c.rid == objCas.rid & !objCas.ECC_Decision.Select(x => x.dcid).Contains(c.dcid)).toList())
public void updatechild<Ety>(ICollection<Ety> amList, ICollection<Ety> rList)
{
        foreach (var obj in amList)
        {
            var x = PromatCon.Entry(obj).GetDatabaseValues();
            if (x == null)
                PromatCon.Entry(obj).State = EntityState.Added;
            else
                PromatCon.Entry(obj).State = EntityState.Modified;
        }
        foreach (var obj in rList.ToList())
            PromatCon.Entry(obj).State = EntityState.Deleted;
}
    PromatCon.SaveChanges()
