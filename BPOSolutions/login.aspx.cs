using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con;
        con = new SqlConnection(WebConfigurationManager.ConnectionStrings["bposol"].ToString());
        con.Open();

        SqlCommand cmd = new SqlCommand("select * from [login] where uname='" + TextBox1.Text + "' and pwd='" + TextBox2.Text + "'", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            HttpCookie hc = new HttpCookie("hc1");
            hc["uname"] = dr[0].ToString();

            hc["type"] = dr[2].ToString();

            Response.Cookies.Add(hc);
            if (dr[2].ToString() == "admin")
            {
                Session["uname"] = dr[0].ToString();
                Session["type"] = "admin";
                Response.Redirect("adminhome.aspx");

            }
            if (dr[2].ToString() == "employee")
            {

                Session["uname"] = dr[0].ToString();
                Session["type"] = "employee";
                Response.Redirect("emphome.aspx");
                // Response.Write("<script>" + "alert('welcome customer')" + "</script>");

            }
        }
    }
}