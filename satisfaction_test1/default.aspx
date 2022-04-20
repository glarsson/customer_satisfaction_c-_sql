<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="satisfaction._default" validateRequest="false" %>

<style type="text/css">
    a { 
        color: #0079C2;
    }

    body {
        background-color: #eaf4fb;
    }

    .center-div
    {
        text-align: center;
        margin: auto;
    }

    #dropshadow {
        border: 1px solid;
        padding: 10px;
        box-shadow: 5px 10px 18px #888888;
	    background-color: #69bce9;
    }

</style>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CMSO CUSTOMER SATISFACTION SURVEY</title>
</head>
<body>
    
    <br /><br /><br />
    <table style="width: 800px; background-color: #69bce9; text-align:center; margin: auto">
        <tr>
            <td>
                <div id="dropshadow" style="font-family: Arial,Helvetica Neue,Helvetica,sans-serif">
                    <table>
                        <tr>
                            <td>
                                <img src="cmso_logo.png">
                            </td>
                            <td>
                                <img src="wide_logo_with_name.png">
                            </td>
                    </table>
                    <table>
                    <tr>
                        <td>
                            <br />
                            <p>Thank you for taking the time to rate your experience with ticket number <b><%=ticketQueryStringSanitized%></b>, please choose a rating between 1-5 with 5 being <b>excellent.</b></p>
                            <form method="post" id="satisfaction_form" runat="server">
                                <!--<asp:HiddenField ID="ticket" runat="server" /> -->
                                <input type="radio" name="rating" value="1" />1
                                <input type="radio" name="rating" value="2" />2
                                <input type="radio" name="rating" value="3" />3
                                <input type="radio" name="rating" value="4" />4
                                <input type="radio" name="rating" value="5" checked="checked" />5
                                <br/><br/>
                                <p>Additional comments (not required)</p>
                                <input type="text" name="comment" value="" size="118" />
                                <br/><br/>
                                <asp:Button runat="server" Text="Submit" OnClick="submitClick"/>
                            </form>
                        </td>
                    </table>
                </div>
            </td>
        </tr>
    </table>



</body>
</html>