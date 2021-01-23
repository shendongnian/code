    public void importdatafromexcel(string excelfilepath)
    {
        //declare variables - edit these based on your particular situation
        string ssqltable = "tdatamigrationtable";
        // make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have
        different
        string myexceldataquery = "select student,rollno,course from [sheet1$]";
        try
        {
            //create our connection strings
            string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + excelfilepath +
            ";extended properties=" + "\"excel 8.0;hdr=yes;\"";
            string ssqlconnectionstring = "server=mydatabaseservername;user
            id=dbuserid;password=dbuserpassword;database=databasename;connection reset=false";
            //execute a query to erase any previous data from our destination table
            string sclearsql = "delete from " + ssqltable;
            sqlconnection sqlconn = new sqlconnection(ssqlconnectionstring);
            sqlcommand sqlcmd = new sqlcommand(sclearsql, sqlconn);
            sqlconn.open();
            sqlcmd.executenonquery();
            sqlconn.close();
            //series of commands to bulk copy data from the excel file into our sql table
            oledbconnection oledbconn = new oledbconnection(sexcelconnectionstring);
            oledbcommand oledbcmd = new oledbcommand(myexceldataquery, oledbconn);
            oledbconn.open();
            oledbdatareader dr = oledbcmd.executereader();
            sqlbulkcopy bulkcopy = new sqlbulkcopy(ssqlconnectionstring);
            bulkcopy.destinationtablename = ssqltable;
            while (dr.read())
            {
                bulkcopy.writetoserver(dr);
            }
         
            oledbconn.close();
        }
        catch (exception ex)
        {
            //handle exception
        }
    }
