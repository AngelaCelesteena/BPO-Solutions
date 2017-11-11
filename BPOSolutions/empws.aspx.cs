using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;


public partial class empws : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MultiView1.SetActiveView(View1);
            this.BindData();
        }
    }
    private void BindData()
    {
        string strConnString = WebConfigurationManager.ConnectionStrings["bposol"].ConnectionString;
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            string strQuery = "SELECT eid, sid, status from shiftas";
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

    
   
    protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
    {
        MultiView1.SetActiveView(View2);
        
        
    }
    public static string r = "";
    
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        SqlConnection con;
        con = new SqlConnection(WebConfigurationManager.ConnectionStrings["bposol"].ToString());
        con.Open();
        int i = e.NewSelectedIndex;
        r = GridView1.Rows[i].Cells[3].Text.ToString();
        MultiView1.SetActiveView(View2);
       // DataTable dt= con.t("select * from dept where dept_id='" + r + "'");
        SqlCommand cmd2 = new SqlCommand("select * from ws where wid1='" + r + "'");
       // TextBox1.Text =GridView1.Rows.add();
        Button1.Text = "update";
    }
}