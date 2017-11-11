using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class emplist : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MultiView1.SetActiveView(View1);
            //  DataTable dt = db.table("SELECT * from process");
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }
    }

   
}