using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoodsInventory
{
    public partial class Inventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DAL dal = new DAL();
                DataTable dt = dal.GetDataTable("GetInventory");
                gdvInventory.DataSource = dt;
                gdvInventory.DataBind();
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            DAL dal = new DAL();
            DataTable dt = dal.GetDataTable("GetInventory");
            gdvInventory.DataSource = dt;
            gdvInventory.DataBind();
        }
    }
}