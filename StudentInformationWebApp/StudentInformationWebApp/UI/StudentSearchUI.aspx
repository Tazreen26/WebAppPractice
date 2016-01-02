<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentSearchUI.aspx.cs" Inherits="StudentInformationWebApp.UI.StudentSearchUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>    
                <td> Registration No.   </td>
                <td><asp:TextBox ID="regNoTextBox" runat="server"></asp:TextBox></td>
                <td><asp:Button ID="searchStudentButton" Text="Search" runat="server" OnClick="searchStudentButton_Click"/></td>
            </tr>
            <tr>
                <td> Name </td>
                <td><asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Address</td>
                <td> <asp:TextBox ID="addressTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Phone</td>
                <td><asp:TextBox ID="phoneTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="messageLabel" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="redirectToHomeButton" runat="server" OnClick="redirectToHomeButton_Click" Text="Back" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
