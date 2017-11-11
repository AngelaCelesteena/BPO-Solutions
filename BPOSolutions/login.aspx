<%@ Page Title="" Language="C#" MasterPageFile="~/BPOMasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
   <h1><span>LOGIN</span></h1>
              <p><strong>BPO Solutions</strong> Set up or display tracking numbers and manage performance reporting using call tracking software for PPC, SEO, and offline campaigns.It is easy to set up, use and manage, it requires no capital outlay.The software enables businesses to drive a more effective sales team, and create effortless omnichannel customer experiences, journeys, and relationships. It provides full visibility and valuable context in the customer journey across all channels, to help companies engage their customers while delivering transformative business results. Management couldn't be simpler. </p>
        <p>&nbsp;</p>
        <p>
           <b> <asp:Label ID="Label1" runat="server" Text="USERNAME"></asp:Label> </b>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Invalid" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <b>   <asp:Label ID="Label2" runat="server" Text="PASSWORD"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            </b>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Invalid" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="Button1" runat="server" ForeColor="#000066" Text="LOGIN" OnClick="Button1_Click" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        </div>
                <div id="text_bottom">
                	<div id="text_bottom_left"></div>
                    <div id="text_bottom_right"></div>
                </div>
          </div>
      </div>
        <div id="content_bottom">
        	<div id="content_bottom_left"></div>
            <div id="content_bottom_right"></div>
        </div>
    </div>
    <!-- end main -->
    <!-- footer -->
    <div id="footer">
    <div id="left_footer">© Copyright 2017 <strong>BPO Solutions</strong> </div>
    <div id="right_footer">


    </form>

</asp:Content>

