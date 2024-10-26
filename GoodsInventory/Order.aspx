<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="GoodsInventory.Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="visibility:hidden">
                <asp:Label ID="lblPizzaType" runat ="server" Text="Pizza Type/Category"></asp:Label>
                <asp:DropDownList ID="ddlPizzaType" runat="server"></asp:DropDownList>
            </div>
                        <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell>

                    </asp:TableCell>
                    <asp:TableCell>

                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                <asp:Label ID="lblPizza" runat ="server" Text="Pizza Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                <asp:DropDownList ID="ddlPizza" runat="server" Width="100%"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>                        
                <asp:Label ID="lblSize" runat ="server" Text="Pizza Size"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                <asp:DropDownList ID="ddlSize" runat="server" Width="100%"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                <asp:Label ID="lblQuantity" runat ="server" Text="Pizza Quantity"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                <asp:TextBox ID="txtQuantity" runat="server" TextMode="Number" Width="97%"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>                        
                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                    </asp:TableCell>
                    <asp:TableCell>
                <asp:Button ID="btnOrder" runat="server" Text="Place Order" OnClick="btnOrder_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <div>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
