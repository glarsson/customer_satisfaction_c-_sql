<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reports_main.aspx.cs" Inherits="satisfaction.reports_main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="mainReportPageForm" runat="server">
        <p>Reports available:</p>
        <br />
        <asp:Button id="reports_all_time" Text="All surveys" runat="server" OnClick="allTimeClick"/>
        <br /><br />
        <asp:Button id="reports_this_month" Text="This months surveys" runat="server" OnClick="thisMonthClick"/>
        <br /><br />
        <asp:Button id="reports_last_month" Text="Last months surveys" runat="server" OnClick="lastMonthClick"/>

    </form>
</body>
</html>
