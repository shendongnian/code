    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ServiceModel.Activation;
    using System.ServiceModel;
    using System.Data;
    using Oracle.DataAccess.Client;
    namespace RESTFulDemo
    {
        [AspNetCompatibilityRequirements
            (RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
        public class RestSerivce : IRestSerivce 
        {
            List<Person> objPerson = new List<Person>();
            int personCount = 0;
            public Person CreatePerson(Person createPerson)
            {
                createPerson.ID = (++personCount).ToString();
                objPerson.Add(createPerson);
                return createPerson;
            }
            public List<Person> GetAllPerson()
            {
                return objPerson.ToList();
            }
            public Person GetAPerson(string id)
            {
                return objPerson.FirstOrDefault(e => e.ID.Equals(id));
            }
            public Person UpdatePerson(string id, Person updatePerson)
            {
                Person p = objPerson.FirstOrDefault(e => e.ID.Equals(id));
               p.Name = updatePerson.Name;
                p.Age = updatePerson.Age;
               return p;
            }
            public void DeletePerson(string id)
            {
                objPerson.RemoveAll(e => e.ID.Equals(id));
            }
            public DataSet GETDS()
            {
                return new DataSet();
            }
            public OracleConnection OpenConnection(string pUserName, string pPassword)
            {
                OracleConnection functionReturnValue = default(OracleConnection);
                try
                {
                    OracleConnection ConnObject = new OracleConnection();
                    ConnObject.ConnectionString = "User ID=" + pUserName + ";password=" + pPassword + ";Data Source=Data";
                    ConnObject.Open();
                    functionReturnValue = ConnObject;
                }
                catch (Exception Exc)
                {
                    throw new Exception("Error occured while connecting to the database, the error is: " + Exc.Message);
                }
                return functionReturnValue;
            }
            public string Logon(string pUsername, string pPassword)
            {
                OracleConnection MyConnection = OpenConnection("SuperUser_UserName", "SuperUser_Password");
                string MyReturnString = "";
                try
                {
                    string MyUserType = GetUserType(MyConnection, pUsername);
                    if (MyUserType != "")
                    {
                        MyConnection.Close();
                        try
                        {
                            MyConnection = OpenConnection(pUsername, pPassword);
                            MyReturnString = "CONNECTED";
                        }
                        catch (Exception ex)
                        {
                            return "FAILED: Invalid Username or Password.";
                        }
                    }
                    else
                    {
                        MyReturnString = "FAILED: Access Denied";
                    }
                    MyConnection.Close();
                    MyConnection.Dispose();
                    MyConnection = null;
                    return MyReturnString;
                }
                catch (Exception ex)
                {
                    MyConnection.Dispose();
                    MyConnection = null;
                    return "FAILED: Invalid Uername or Password.";
                }
            }
            public string GetUserType(OracleConnection TheConnection, string pUsername)
            {
                string functionReturnValue = null;
                OracleCommand myCommand = new OracleCommand();
                string Result = "";
                try
                {
                    var _with1 = myCommand;
                    _with1.Connection = TheConnection;
                    _with1.CommandText = "SchemaName.UserData.GetUserType";
                    _with1.CommandType = CommandType.StoredProcedure;
                    _with1.Parameters.Clear();
                    _with1.Parameters.Add(new OracleParameter("pUserName", OracleDbType.Varchar2, pUsername.Length)).Value = pUsername;
                    _with1.Parameters.Add(new OracleParameter("pUserType", OracleDbType.Varchar2, 100)).Direction = ParameterDirection.Output;
                    _with1.Parameters[0].Direction = ParameterDirection.Input;
                    _with1.ExecuteNonQuery();
                    functionReturnValue = _with1.Parameters[1].Value.ToString();
                }
                catch (Exception exc)
                {
                    throw new Exception("Error occured while retreiving user type, the error is: " + exc.Message);
                }
                myCommand = null;
                return functionReturnValue;
            }
        }
    }
