using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class empreg : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            addlist();
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con;
        con = new SqlConnection(WebConfigurationManager.ConnectionStrings["bposol"].ToString());
        con.Open();
        //SqlCommand cmd = new SqlCommand("");

        SqlCommand cmd = new SqlCommand("insert into [employee] values(@ename,@gender,@dob,@addr,@city,@mob,@email,@pname,@uname,@status) ", con);
        SqlCommand cmd2 = new SqlCommand("insert into [login] values(@uname,@pwd,@type) ", con);

        cmd.Parameters.AddWithValue("@ename", TextBox1.Text);
        //cmd.Parameters.AddWithValue("@uname", TextBox2.Text);
        cmd.Parameters.AddWithValue("@gender", RadioButtonList1.SelectedValue);
        cmd.Parameters.AddWithValue("@dob", TextBox8.Text);
        cmd.Parameters.AddWithValue("@addr", TextBox9.Text);
        cmd.Parameters.AddWithValue("@city", TextBox2.Text);
        cmd.Parameters.AddWithValue("@mob", TextBox3.Text);
        cmd.Parameters.AddWithValue("@email", TextBox4.Text);
        cmd.Parameters.AddWithValue("@pname", DropDownList2.Text);
        cmd.Parameters.AddWithValue("@uname", TextBox5.Text);
        cmd.Parameters.AddWithValue("@status", "Active");
        cmd2.Parameters.AddWithValue("@uname", TextBox5.Text);
        cmd2.Parameters.AddWithValue("@pwd", TextBox7.Text);
        cmd2.Parameters.AddWithValue("@type", "employee");
       // cmd2.Parameters.AddWithValue("@mail_id", TextBox9.Text);
       // cmd2.Parameters.AddWithValue("@pass", TextBox3.Text);

        int a = cmd.ExecuteNonQuery();
        int b = cmd2.ExecuteNonQuery();
        if (a == 1 && b == 1)
        {
            Response.Write("<script language='javascript'>alert('successfull...');</script>");
            Response.Redirect("adminhome.aspx");
        }


        //cmd.ExecuteNonQuery();

        con.Close();

        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        RadioButtonList1.SelectedValue = "";
        DropDownList2.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
       // TextBox10.Text = "";
        //TextBox10.Text = "";
        //TextBox11.Text = ""; 
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    public void addlist()
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["bposol"].ToString());
        SqlCommand cmd;
        con.Open();
        cmd = new SqlCommand("select pname from process", con);
        DropDownList2.Items.Clear();
        DropDownList2.Items.Add("---select process---");
        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            DropDownList2.Items.Add(new ListItem(dr[0].ToString()));
        }
        con.Close();
    }
}
    