using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class emsg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MultiView1.SetActiveView(View1);
            TextBox1.Text = Session["uname"].ToString();
            TextBox4.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con;
        con = new SqlConnection(WebConfigurationManager.ConnectionStrings["bposol"].ToString());
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into [msg] values(@name,@date,@msgs)", con);
        cmd.Parameters.AddWithValue("@name", TextBox1.Text);
        cmd.Parameters.AddWithValue("@date", TextBox4.Text);
        cmd.Parameters.AddWithValue("@msgs", TextBox3.Text);
        int a = cmd.ExecuteNonQuery();
       // int b = cmd2.ExecuteNonQuery();
        if (a == 1 )
        {
            Response.Write("<script language='javascript'>alert('successfull...');</script>");
           // Response.Redirect("emphome.aspx");
        }
        con.Close();

       
        
        TextBox3.Text = "";
    }

   

}