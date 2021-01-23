public override void SetSession(ISession session)
{
    using (var cmd = session.Connection.CreateCommand())
    {
        var param1 = cmd.CreateParameter();
        param1.ParameterName = "@key";
        param1.Value = "TenantId";
        var param2 = cmd.CreateParameter();
        param2.ParameterName = "@value";
        param2.Value = _tenantResolver.Current.Id;
        
        cmd.CommandText = "sp_set_session_context";
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        cmd.ExecuteNonQuery();
    }
    base.SetSession(session);
}
