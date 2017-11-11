using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class empchngpws : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
         SqlConnection con;
        con = new SqlConnection(WebConfigurationManager.ConnectionStrings["bposol"].ToString());
        con.Open();
        String s = Session["uname"].ToString();
        String pass="";
       
        String C_p = TextBox1.Text;
        
         SqlCommand cmd = new SqlCommand("select pwd from [login] where uname='" + s + "' ", con);
         SqlDataReader dr = cmd.ExecuteReader();
         if (dr.Read())
         {
            pass = dr[0].ToString();
         }
         if (C_p == pass)
         {
             SqlCommand cmd1 = new SqlCommand("update  login set pwd='" + TextBox3.Text + "' where uname='" + s + "'",con);
             cmd1.ExecuteNonQuery();
             Response.Write("<script language='javascript'> alert('successful'); </script>");
             Response.Redirect("login.aspx");

         }
         else
         {
             Response.Write("<script>" + "alert('current Password is Wrong')" + "</script>");
         }
       
        con.Close();
       

    }
}