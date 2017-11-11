using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class shift : System.Web.UI.Page
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
            string strQuery = "SELECT * FROM shiftas";
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
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
     
        Button1.Text = "Submit";
        addlist();
        addlist1();

    }

    public void clr()
    {
        //DropDownList2.Items.Clear = "";
        DropDownList2.SelectedIndex = 0;
        DropDownList4.SelectedIndex = 0;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con;
        con = new SqlConnection(WebConfigurationManager.ConnectionStrings["bposol"].ToString());
        con.Open();
        SqlCommand cmd2 = new SqlCommand("insert into [shiftas] values(@eid,@sid,@status) ", con);
        cmd2.Parameters.AddWithValue("@eid", DropDownList2.Text); 
        cmd2.Parameters.AddWithValue("@sid", DropDownList4.Text);
        cmd2.Parameters.AddWithValue("@status", "1 Month");
        cmd2.ExecuteNonQuery();
        string qry2 = ("update employee set status='assigned' where ename='" + DropDownList2.Text + "'");
        SqlCommand cmd = new SqlCommand(qry2, con);
        cmd.ExecuteNonQuery();
        Response.Write("<script>" + "alert('Successfully assigned')" + "</script>");
        addlist();
      //  MultiView1.SetActiveView(View1);
        Response.Redirect("shift.aspx");
        con.Close();
        clr();
    }
    public void addlist()
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["bposol"].ToString());
        SqlCommand cmd;
       //SqlCommand cmd1;
        con.Open();
        cmd = new SqlCommand("select ename from employee where status= 'Active' ", con);
        DropDownList2.Items.Clear();
        DropDownList2.Items.Add("---select Employee---");
        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            DropDownList2.Items.Add(new ListItem(dr[0].ToString()));
        }

        con.Close();
        
    }
    public void addlist1()
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["bposol"].ToString());
        SqlCommand cmd;
        con.Open();
        cmd = new SqlCommand("select sname from shift", con);
        DropDownList4.Items.Clear();
        DropDownList4.Items.Add("---Select Shift---");
        SqlDataReader ds = cmd.ExecuteReader();

        while (ds.Read())
        {
            DropDownList4.Items.Add(new ListItem(ds[0].ToString()));
        }
        con.Close();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        addlist2();
        addlist3();
        MultiView1.SetActiveView(View3);
        

    }
    public void addlist2()
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["bposol"].ToString());
        SqlCommand cmd;
        //SqlCommand cmd1;
        con.Open();
        cmd = new SqlCommand("select sname from shift", con);
        DropDownList6.Items.Clear();
        DropDownList6.Items.Add("---select Shift---");
        SqlDataReader dp = cmd.ExecuteReader();

        while (dp.Read())
        {
            DropDownList6.Items.Add(new ListItem(dp[0].ToString()));
        }

        con.Close();

    }
    public void addlist3()
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["bposol"].ToString());
        SqlCommand cmd;
        con.Open();
        cmd = new SqlCommand("select eid from shiftas", con);
        DropDownList5.Items.Clear();
        DropDownList5.Items.Add("---Select Employee---");
        SqlDataReader dl = cmd.ExecuteReader();

        while (dl.Read())
        {
            DropDownList5.Items.Add(new ListItem(dl[0].ToString()));
        }
        con.Close();
    }
    
        
   
    protected void Button3_Click1(object sender, EventArgs e)
    {
        SqlConnection con;
        con = new SqlConnection(WebConfigurationManager.ConnectionStrings["bposol"].ToString());
        con.Open();
        SqlCommand cmd2 = new SqlCommand("update [shiftas] set sid='" + DropDownList6.Text + "' where eid='" + DropDownList5.Text + "' ", con);
      
        cmd2.Parameters.AddWithValue("@sid", DropDownList6.Text);
        cmd2.Parameters.AddWithValue("@eid", DropDownList5.Text);
        cmd2.Parameters.AddWithValue("@status", "1month");
        cmd2.ExecuteNonQuery();
        Response.Write("<script>" + "alert('Successfully Updated')" + "</script>");
        Response.Redirect("shift.aspx");
        con.Close();
        clr();
    }
}