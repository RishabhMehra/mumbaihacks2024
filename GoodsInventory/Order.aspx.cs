using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoodsInventory
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DAL dal = new DAL();
                DataTable dt = dal.GetDataTable("GetPizzaSize");
                ddlSize.DataSource = dt;
                ddlSize.DataValueField = "PizzaSizeId";
                ddlSize.DataTextField = "PizzaSizeName";
                ddlSize.DataBind();

                dt = dal.GetDataTable("GetPizzaList");
                ddlPizza.DataSource = dt;
                ddlPizza.DataValueField = "PizzaName";
                ddlPizza.DataTextField = "PizzaName";
                ddlPizza.DataBind();

                dt = dal.GetDataTable("GetPizzaType");
                ddlPizzaType.DataSource = dt;
                ddlPizzaType.DataValueField = "PizzaTypeId";
                ddlPizzaType.DataTextField = "PizzaTypeName";
                ddlPizzaType.DataBind();
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                lblMessage.Text = "Please enter quantity";
                return;
            }

            for (int counter = 0; counter < Convert.ToInt32(txtQuantity.Text); counter++)
            {
                DAL dal = new DAL();
                dal.cmd.Parameters.AddWithValue("PizzaName", ddlPizza.SelectedValue);
                dal.cmd.Parameters.AddWithValue("PizzaSizeId", ddlSize.SelectedValue);
                dal.GetExecuteNonQuery("UpdateInventory");
            }
            lblMessage.Text = "Order placed successfully";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddlPizza.Enabled = true;
            ddlPizzaType.Enabled = true;
            txtQuantity.Text = "";
            lblMessage.Text = "";
        }
    }
}