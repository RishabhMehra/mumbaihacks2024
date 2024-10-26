<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PizzaIngrediants.aspx.cs" Inherits="GoodsInventory.PizzaIngrediants" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:DropDownList ID="ddlPizza" runat="server" Width="30%"></asp:DropDownList>
                <asp:DropDownList ID="ddlSize" runat="server" Width="10%"></asp:DropDownList>
                <asp:Button ID="btnSearch" runat="server" Text="Get Ingrediants" OnClick="btnSearch_Click" Width="20%"/>
            </div>
            <div style="margin-top:10%">
                <asp:GridView ID="gdvIngrediants" runat="server" Width="70%"></asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
