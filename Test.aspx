<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="grp_assignment.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <asp:Image runat="server" ID="Image1" ImageUrl="/assets/bg.png" ImageAlign="AbsMiddle" Height="300px"></asp:Image><br /><br />
                <asp:FileUpload runat="server" ID="FileUpload1"></asp:FileUpload> <br /> <br />
                <asp:Button runat="server" OnClick="upload_click" Text="UPLOAD"/>
                <asp:Button runat="server" OnClick="Page_Load" Text="DELETE"/><br />
                <asp:Label runat="server" ID="Label1" Text="You are uploading: "></asp:Label>
            </center> 
        </div>
    </form>
</body>
</html>
