<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentInfoUI.aspx.cs" Inherits="StudentInformationWebApp.UI.StudentInfoUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 293px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:HiddenField ID="idToChange" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Name</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Reg No.</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="regNoTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Phone No.</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="phoneNoTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Address</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="addressTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="messageLabel" runat="server"></asp:Label>
                        <asp:Button ID="saveButton" Text="Save" runat="server" OnClick="saveButton_Click" Width="67px" />
                        <br />
                        <br />
                        <asp:Button ID="showButton" runat="server" OnClick="showButton_Click" Text="Show Student Info" />
                        <asp:GridView ID="showStudentInfoGridView" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HiddenField runat="server" ID="studentIdHiddenField" Value='<%#Eval("Id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText='Reg. <br/>Number'>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("StudentRegNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText='Name'>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("StudentName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Phone">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("Phone") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="updateButton" Text="Update" OnClick="updateButton_OnClick"></asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="deleteButton" Text="Delete" OnClick="deleteButton_OnClick"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#333333" />
                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="White" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#487575" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#275353" />
                        </asp:GridView>
                        <br />
                        <br />
                        <asp:Button ID="redirectToSearchButton" runat="server" OnClick="redirectToSearchButton_Click" Text="Search Student" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
