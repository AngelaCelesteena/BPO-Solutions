using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class vshift : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //SqlConnection con;
      //  con = new SqlConnection(WebConfigurationManager.ConnectionStrings["bposol"].ToString());
       // con.Open();
        if (!IsPostBack)
        {
            MultiView1.SetActiveView(View1);
            this.BindData();
            //SqlCommand cmd2 = new SqlCommand("select * from [shift] ", con);
            //GridView1.DataSource = ;
           // GridView1.DataBind();
            
        }
    }
    private void BindData()
{
    string strConnString = WebConfigurationManager.ConnectionStrings["bposol"].ConnectionString;
    DataTable dt = new DataTable();
    using (SqlConnection con = new SqlConnection(strConnString))
    {
        string strQuery = "SELECT * FROM shift";
        SqlCommand cmd = new SqlCommand(strQuery);
        using (SqlDataAdapter sda = new SqlDataAdapter())
        {
            cmd.Connection = con;
            con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}
   
    }
