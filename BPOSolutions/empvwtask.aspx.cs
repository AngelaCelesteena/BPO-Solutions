using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class empvwtask : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            MultiView1.SetActiveView(View1);
            // MultiView1.SetActiveView(View1);
            //DataTable dt = db.table("SELECT * from pshift_as");
           // GridView1.DataSource = dt;
           // GridView1.DataBind();
           // this.BindData();
        }
    }
   /* private void BindData()
    {
        string strConnString = WebConfigurationManager.ConnectionStrings["bposol"].ConnectionString;
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            string strQuery = "SELECT * FROM shift_as";
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
    } */
}