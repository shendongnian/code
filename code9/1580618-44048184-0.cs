    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MySql.Data.MySqlClient;
    using Windows.UI.Popups;
    using Walsall_College_Auditor.Classes;
    namespace Walsall_College_Auditor.Models
    {
    class dbConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        //Constructor
        public dbConnect()
        {
            Initialize();
        }
        //Initialize values
        private void Initialize()
        {
            //Prevent the application from throwing "windows-1252' is not a supported encoding name."
            System.Text.EncodingProvider ppp;
            ppp = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);
            server = "localhost";
            database = "your_db_name"; //Put the new database name here
            uid = "root"; //Your db Login/Username
            password = ""; //Your db login password
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" 
                + "UID=" + uid + ";" + "PASSWORD=" + password + ";SslMode=None";
            connection = new MySqlConnection(connectionString);
        }
        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to the server.
                //1045: Invalid username and/or password.
                switch (ex.Number)
                { 
                    case 0:
                        var dialog1 = new MessageDialog("Cannot connect to server.  Contact administrator");
                        dialog1.Title = "Connection Error";
                        dialog1.ShowAsync();
                        break;
                    case 1045:
                        var dialog2 = new MessageDialog("Invalid username/password, please try again");
                        dialog2.Title = "Connection Error";
                        dialog2.ShowAsync();
                        break;
                }
                return false;
            }
        }
        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                var dialog = new MessageDialog(ex.Message);
                dialog.Title = "Disconnecting Error";
                dialog.ShowAsync();
                return false;
            }
        }
    
