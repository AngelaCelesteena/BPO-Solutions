<%@ Page Title="" Language="C#" MasterPageFile="~/empmaster.master" AutoEventWireup="true" CodeFile="empvwtask.aspx.cs" Inherits="empvwtask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bsConnectionString6 %>" SelectCommand="SELECT [eid], [sid], [status] FROM [shiftas]" ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                <asp:Label ID="Label1" runat="server" style="font-size: large; color: #FFFFFF; font-weight: 700" Text="Shift Assigned List"></asp:Label>
                <br />
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" Height="229px" Width="398px">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="eid" HeaderText="Employee" SortExpression="eid" />
                        <asp:BoundField DataField="sid" HeaderText="Shift" SortExpression="sid" />
                        <asp:BoundField DataField="status" HeaderText="Valid" SortExpression="status" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </asp:View>
        </asp:MultiView>
        <br />
        <br />
    </form>
</asp:Content>

