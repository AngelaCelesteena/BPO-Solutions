using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class adminhome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con;
        con = new SqlConnection(WebConfigurationManager.ConnectionStrings["bposol"].ToString());
        con.Open();
        Label1.Text = Session["uname"].ToString();

        con.Close();
    }
}