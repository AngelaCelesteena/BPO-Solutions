using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class ews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MultiView1.SetActiveView(View1);
            SqlConnection con;
            con = new SqlConnection(WebConfigurationManager.ConnectionStrings["bposol"].ToString());
            con.Open();
            string s = ("select sid from shiftas where eid='" + Session["uname"].ToString() + "'");
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextBox2.Text = dr[0].ToString();

            }
          
            TextBox1.Text = Session["uname"].ToString();
            TextBox3.Text = DateTime.Now.ToString("yyyy-MM-dd");
            con.Close();
            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con;
        con = new SqlConnection(WebConfigurationManager.ConnectionStrings["bposol"].ToString());
        con.Open();

        SqlCommand cmd = new SqlCommand("insert into [wss] values(@ename,@sname,@date,@des)", con);
        cmd.Parameters.AddWithValue("@ename", TextBox1.Text);
        cmd.Parameters.AddWithValue("@sname", TextBox2.Text);
        cmd.Parameters.AddWithValue("@date", TextBox3.Text);
        cmd.Parameters.AddWithValue("@des", TextBox4.Text);
        int a = cmd.ExecuteNonQuery();
        if (a == 1)
        {
            Response.Write("<script language='javascript'>alert('Work status Updated...');</script>");
            // Response.Redirect("emphome.aspx");
        }
        con.Close();
        
        TextBox4.Text = "";
    }
}