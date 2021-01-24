    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    using System.Data;
    using System.Configuration;
    
    public partial class _Default : System.Web.UI.Page
    {
    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (!this.IsPostBack)
    		{
    			BindRemUserList();
    		}
    	}
    
    	protected void BindRemUserList()
    	{
    		string CS = ConfigurationManager.ConnectionStrings["EP_PLANNING_NEW"].ConnectionString;
    		using(SqlConnection con = new SqlConnection(CS))
    		{
    			using (SqlCommand cmd = new SqlCommand("SELECT [ID],[First Name] + ' ' + [Last Name] AS [Full Name] FROM [dbo].[team_members]"))
    			{
    
    				cmd.CommandType = CommandType.Text;
    				cmd.Connection = con;
    
    				try
    				{
    					con.Open();
    					RemUserList.DataSource = cmd.ExecuteReader();
    					RemUserList.DataTextField = "Full Name";
    					RemUserList.DataValueField = "ID";
    					RemUserList.DataBind();
    				}
    
    				catch (Exception ex)
    				{
    					throw ex;
    				}
    
    				finally
    				{
    					con.Close();
    					con.Dispose();
    				}
    
    			}
    		}
    
    		RemUserList.Items.Insert(0, new ListItem("- Select Team Member to remove -", "0"));
    	}
    
    	protected void RemUserList_SelectedIndexChanged(object sender, EventArgs e)
    	{
    
    	}
    
    	protected void AddUserButton_Click(object sender, EventArgs e)
    	{
    		string CS = ConfigurationManager.ConnectionStrings["EP_PLANNING_NEW"].ConnectionString;
    		using(SqlConnection con = new SqlConnection(CS))
    		{
    			SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[team_members] ([First Name],[Last Name]) VALUES (@FirstName,@LastName)", con);
    			cmd.Parameters.AddWithValue("@FirstName", AddUserFirstName.Text);
    			cmd.Parameters.AddWithValue("@LastName", AddUserLastName.Text);
    
    			try
    			{
    				con.Open();
    				cmd.ExecuteNonQuery();
    			}
    
    			catch (Exception ex)
    			{
    				throw ex;
    			}
    
    			finally
    			{
    				con.Close();
    				con.Dispose();
    			}
    			MsgLbl.Text = "** User Successfully Added **";
    			AddUserFirstName.Text = "";
    			AddUserLastName.Text = "";
    			BindRemUserList();
    		}
    	}
    
    	protected void RemUserButton_Click(object sender, EventArgs e)
    	{
    		string CS = ConfigurationManager.ConnectionStrings["EP_PLANNING_NEW"].ConnectionString;
    		using(SqlConnection con = new SqlConnection(CS))
    		{
    			SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[team_members] WHERE [ID] = @ID", con);
    			cmd.Parameters.AddWithValue("@ID", RemUserList.SelectedValue);
    			try
    			{
    				con.Open();
    				cmd.ExecuteNonQuery();
    			}
    			catch (Exception ex)
    			{
    				throw ex;
    			}
    			finally
    			{
    				con.Close();
    				con.Dispose();
    			}
    		}
    		MsgLbl.Text = "** User Successfully Removed **";
    		BindRemUserList();
    	}
    }
