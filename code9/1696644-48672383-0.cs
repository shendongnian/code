    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MySql.Data.MySqlClient;
    using Newtonsoft.Json;
    using PastPapers.Helpers;
    using Microsoft.AspNetCore.Http;
    
    namespace PastPapers.Models
    {
        public class LoginModel : IHttpContextAccessor
        {
            public string username { get; set; }
            public string password { get; set; }
            public bool loginSuccess { get; set; }
            public string loginErrorMessage { get; set; }
    
            public string newUsername { get; set; }
            public string newPassword { get; set; }
            public string newEmail { get; set; }
            public bool registerSuccess { get; set; }
            public string registerErrorMessage { get; set; }
    
            [JsonIgnore]
            public AppDb Db { get; set; }
            public HttpContext HttpContext { get; set; }
    
            public LoginModel(AppDb db = null)
            {
                Db = db;
                loginSuccess = false;
                registerSuccess = false;
            }
    
            public LoginModel()
            {
    
            }
    
            public void AttemptRegister()
            {
                try
                {
                    Db.Connection.Open();
    
                    string sql = "INSERT INTO users (id, username, password, email) VALUES (DEFAULT, @username, @password, @email)";
                    MySqlCommand cmd = new MySqlCommand(sql, Db.Connection);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@username", newUsername);
                    cmd.Parameters.AddWithValue("@password", SecurePasswordHasher.Hash(newPassword));
                    cmd.Parameters.AddWithValue("@email", newEmail);
    
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        System.Diagnostics.Debug.WriteLine("Account failed to create!");
                        registerSuccess = false;
                    } else
                    {
                        registerSuccess = true;
                    }
    
                } catch (Exception ex)
                {
                    registerErrorMessage = "Error connecting to database";
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
    
            public void AttemptLogin()
            {
                try
                {
                    Db.Connection.Open();
    
                    string sql = "SELECT password FROM users WHERE username=@username";
                    MySqlCommand cmd = new MySqlCommand(sql, Db.Connection);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@username", username);
                    MySqlDataReader reader = cmd.ExecuteReader();
    
                    if (reader.Read())
                    {
                        string dbPassword = reader.GetString(0);
    
                        if (SecurePasswordHasher.Verify(password, dbPassword))
                        {
                            loginSuccess = true;
                            HttpContext.Session.SetString("username", username);
                            
                        } else
                        {
                            loginSuccess = false;
                            loginErrorMessage = "Incorrect password";
                        }
                    } else
                    {
                        loginErrorMessage = "Unknown username";
                    }
    
                } catch (Exception ex)
                {
                    loginErrorMessage = "Error connecting to database";
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
                
            }
        }
    }
