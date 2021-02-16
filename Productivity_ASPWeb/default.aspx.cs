using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Productivity_ASPWeb
{
    public class GlobalVariables
    {
        public static string strConnection;
        public static int logProd = 1;
    }

    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert(exception);", true);

            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString("N"), "alert(exception);", true);
        }

        protected void BtnServices_Click(object sender, EventArgs e)
        {
            Response.Redirect("DM_Services.aspx");
        }
    }
}