<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForecastingUsingAI.aspx.cs" Inherits="GoodsInventory.ForecastingUsingAI" Async="true" %>
<%--<%@ Page Async="true" %>--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="background-color:grey">
<head runat="server">
    <title></title>
    <Script>  
        function funfordefautenterkey1(btn, event) {  
            if (document.all) {  
                if (event.keyCode == 13) {  
                    event.returnValue = false;  
                    event.cancel = true;  
                    btn.click();  
                }  
            }            
    </Script>  
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:100%;height:60%">
            <%--<asp:ScriptManager ID="scrptManager" runat="server">

            </asp:ScriptManager>
            <asp:Timer ID="tmrChatWindow" runat="server" OnTick="tmrChatWindow_Tick" Interval="500000">

            </asp:Timer>--%>
            <asp:TextBox runat="server" ID="txtChatWindow" TextMode="MultiLine" Rows="25" Width="100%" style="margin-top:20px;background-color:black;" ForeColor="Green" Enabled="false"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox runat="server" ID="txtChatQuery" Width="93%"></asp:TextBox>
            <asp:Button runat="server" ID="btnSubmitQuery" Text="Send" OnClick="btnSubmitQuery_Click"/>
        </div>
    </form>
</body>
</html>
