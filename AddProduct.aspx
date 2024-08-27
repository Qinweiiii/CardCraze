<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="grp_assignment.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!DOCTYPE html>

    <title>>Add Product Page</title>
    <link rel="stylesheet" href="MasterFooterStyle.css" />
    <link href="/addProductStyle.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="content1" runat="server">
    <div>
        <asp:Panel runat="server">
            <center>
                <%-- The title of "Add Product" subpage. --%>
                <div style="width: 16%; height: 60px; margin-top: 20px; object-fit: cover;">
                    <img src="/assets/blackjack.png" alt="" style="height: 60px; float: left;" />
                    <span style="font-size: 32px; line-height: 60px; float: right; font-weight: 600; font-family: Cambria, Cochin, Georgia, Times, Times New Roman, serif;">Add Product</span>
                </div>

                <%-- Next will be the form section for seller to fill in the info about the new product. --%>
                <div class="formBody">
                    <%-- Error message for users if there is any blank empty --%>
                    <center>
                        <asp:Label runat="server" ID="errorMsg"></asp:Label>
                    </center>

                    <%-- Name --%>
                    <asp:Label runat="server" CssClass="formTitle">Name<span style="color: red;">*</span></asp:Label><br />
                    <asp:TextBox runat="server" ID="prodName" Placeholder="Product Name" CssClass="formBlank"></asp:TextBox>
                    <br />

                    <%-- Description --%>
                    <asp:Label runat="server" CssClass="formTitle">Description<span style="color: red;">*</span></asp:Label><br />
                    <asp:TextBox runat="server" ID="prodDesp" Placeholder="The Description of Product" TextMode="MultiLine" CssClass="formBlankDesp"></asp:TextBox>

                    <asp:Panel runat="server" Height="90px" class="subTable">

                        <%-- Left Part: Price, Stock, Category, Type --%>
                        <div style="width: 50%; float: left;">
                            <img src="/assets/moneySymbol.png" alt="" style="height: 30px; float: left;" />
                            <span class="rowTitle">Price(RM)<span style="color: red;">*</span></span>
                            <asp:TextBox runat="server" ID="price" TextMode="Number" Placeholder="50.00" CssClass="rowBlank"></asp:TextBox>
                            <img src="/assets/stockSymbol.png" alt="" style="height: 30px; float: left;" />
                            <span class="rowTitle">Stock<span style="color: red;">*</span></span>
                            <asp:TextBox runat="server" ID="stock" TextMode="Number" Placeholder="500" CssClass="rowBlank"></asp:TextBox>
                            <img src="/assets/categorySymbol.png" alt="" style="height: 30px; float: left;" />
                            <span class="rowTitle">Category<span style="color: red;">*</span></span>
                            <asp:DropDownList runat="server" ID="ctgList" CssClass="rowBlank" Width="95%">
                                <asp:ListItem runat="server">Pokeman Card</asp:ListItem>
                                <asp:ListItem runat="server">K-POP Card</asp:ListItem>
                                <asp:ListItem runat="server">Sports Stars Card</asp:ListItem>
                                <asp:ListItem runat="server">Anime Cartoon Card</asp:ListItem>
                            </asp:DropDownList>
                            <img src="/assets/typeSymbol.png" alt="" style="height: 30px; float: left;" />
                            <span class="rowTitle">Type<span style="color: red;">*</span></span>
                            <asp:TextBox runat="server" ID="type" Placeholder="Aespa" CssClass="rowBlank"></asp:TextBox>
                        </div>

                        <%-- Right Part: Image Upload --%>
                        <div style="float: left; width: 45%; height: 400px; margin-left: 2%;">
                            <img src="/assets/upload_img.png" alt="" style="height: 30px; float: left; margin-left: 5%;" />
                            <span class="rowTitle">Product Image<span style="color: red;">*</span></span>
                            <center>
                                <%-- If there is an image uploaded from user, the image content will turn into the uploaded one. --%>
                                <asp:Image runat="server" ID="cardImg" ImageUrl="/assets/bg.png" cssclass="imgUpload"></asp:Image>
                                <asp:FileUpload runat="server" ID="ImageUpload" class="fileUpload"></asp:FileUpload>
                                <br />
                                <asp:Button runat="server" OnClick="UploadButton_Click" Text="UPLOAD" class="uploadButton" />
                                <asp:Button runat="server" OnClick="DeleteButton_Click" Text="DELETE" class="deleteButton" />
                            </center>

                        </div>
                    </asp:Panel>

                    <center>
                        <asp:Button runat="server" Text="Add Product" OnClick="SaveButton_Click" class="addButton" />
                    </center>

                </div>
            </center>
        </asp:Panel>
    </div>
</asp:Content>
