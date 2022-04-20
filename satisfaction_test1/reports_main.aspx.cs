using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace satisfaction
{
    public partial class reports_main : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void allTimeClick(object sender, EventArgs e)
        {
            Response.Redirect("~/reports_all_time.aspx");
        }

        protected void thisMonthClick(object sender, EventArgs e)
        {
            Response.Redirect("~/reports_this_month.aspx");
        }

        protected void lastMonthClick(object sender, EventArgs e)
        {
            Response.Redirect("~/reports_last_month.aspx");
        }
    }
}