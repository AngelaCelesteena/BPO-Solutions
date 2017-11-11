using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class adminchngpwd : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        SqlConnection con;
        con = new SqlConnection(WebConfigurationManager.ConnectionStrings["bposol"].ToString());
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from login where pwd='" + TextBox1.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        string username = ds.Tables[0].Rows[0][1].ToString();
        string OLdpassword = ds.Tables[0].Rows[0][2].ToString();
        if (OLdpassword == TextBox1.Text)
        {
            if (TextBox2.Text == TextBox3.Text)
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("update login set pwd='" + TextBox3.Text + "' where uname='admin'");
                int querystatus = cmd.ExecuteNonQuery();
                if (querystatus > 0)
                {
                    Response.Write("<script language='javascript'> alert('successful'); </script>");
                    //lblError.ForeColor = System.Drawing.Color.Green;
                    // lblError.Text = "Password updated successfully";
                }
                else
                {
                    Response.Write("<script language='javascript'> alert('failed'); </script>");
                    // lblError.ForeColor = System.Drawing.Color.Red;
                    // lblError.Text = "Execution error";
                }
            }
            else
            {
             //   lblError.ForeColor = System.Drawing.Color.Red;
               // lblError.Text = "Password miss match";
                Response.Write("<script language='javascript'> alert('Password miss match'); </script>");
            }
        }
        else
        {
           // lblError.ForeColor = System.Drawing.Color.Red;
            //lblError.Text = "Old password is incorrect";
            Response.Write("<script language='javascript'> alert('Old password is incorrect'); </script>");
        }
        con.Close();
    }
}