<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reports_all_time.aspx.cs" Inherits="satisfaction.reports_all_time" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="AllRecordsForm" runat="server">
        <p>Average: <%= averageFinal%></p>
        <asp:GridView runat="server" ID="allRecordsGrid" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Date" DataField="Date" />
                <asp:BoundField HeaderText="Ticket number" DataField="Ticket" />
                <asp:BoundField HeaderText="Rating" DataField="Score" />
                <asp:BoundField HeaderText="Comment" DataField="Comment" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
