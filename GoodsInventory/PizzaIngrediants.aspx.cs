using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoodsInventory
{
    public partial class PizzaIngrediants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DAL dal = new DAL();
                DataTable dt = dal.GetDataTable("GetPizzaList");
                ddlPizza.DataSource = dt;
                ddlPizza.DataValueField = "PizzaName";
                ddlPizza.DataTextField = "PizzaName";
                ddlPizza.DataBind();

                dt = dal.GetDataTable("GetPizzaSize");
                ddlSize.DataSource = dt;
                ddlSize.DataValueField = "PizzaSizeId";
                ddlSize.DataTextField = "PizzaSizeName";
                ddlSize.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DAL dal = new DAL();
            Common common = new Common();
            dal.cmd.Parameters.AddWithValue("PizzaName", ddlPizza.SelectedValue);
            dal.cmd.Parameters.AddWithValue("PizzaSizeId", ddlSize.SelectedValue);
            DataTable dt = dal.GetDataTable("GetPizzaIngrediants");
            DataTable transposeTable = common.TransposeTable(dt,"Ingrediant","Quantity");

            gdvIngrediants.DataSource = transposeTable;
            gdvIngrediants.DataBind();
        }
    }
}