<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="grp_assignment.Store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!DOCTYPE html>

    <title>Buy now</title>
    <link rel="stylesheet" href="MasterFooterStyle.css" />
    <link rel="stylesheet" href="storepage-styles.css" />
    <style>
        .mybt1, .mybt2 {
            width: 150px !important;
            margin: 20px 0 20px 0 !important;
            padding: 10px 20px !important;
            background-color: #AC81B6 !important;
            color: white !important;
            border: none !important;
            border-radius: 5px !important;
            font-size: 16px !important;
            cursor: pointer !important;
            text-align: center !important;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.3) !important;
            transition: background-color 0.2s ease !important;
        }

            .mybt1:hover {
                background-color: #4D4249 !important;
            }

            .mybt2:hover {
                background-color: #FFEE99 !important;
            }

        .mybt1 {
            background-color: #231E21 !important;
            color: #FFE35D !important;
        }

        .mybt2 {
            background-color: #FFE770 !important;
            color: #231E21 !important;
        }

        .buy-now-wrapper .button {
            display: block;
            text-decoration: none;
            background-color: #FFE770;
            color: #231E21;
            border-radius: 0 0 10px 10px;
            font-size: 16px;
            text-align: center;
            padding: 10px;
            transition: background-color 0.2s ease;
            width: 240px;
            margin: -20px;
            margin-bottom: 0px;
            margin-top: 0px;
        }

            .buy-now-wrapper .button:hover {
                background-color: #FFF5C2;
                font-weight: bold;
            }
    </style>
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="content1" runat="server">

    <div class="storepage">
        <%-- title section --%>
        <div class="storepage-title">
            <h1>CardCraze</h1>
            <h2>Join the Craze. Find Your Aces.</h2>
            <div class="button-container">
                <asp:Button ID="Button1" CssClass="mybt1" runat="server" Text="Explore" OnClick="Button1_Click" />
                <asp:Button ID="Button2" CssClass="mybt2" runat="server" Text="Sell Card" OnClick="Button2_Click" />
            </div>
        </div>

        <%--  benefits --%>
        <div class="benefits-row">
            <div class="benefit">
                <img src="assets/authentic.png" alt="100% Authentic" />
                <p>100% Authentic</p>
            </div>
            <div class="benefit">
                <img src="assets/return.png" alt="10 Days Return" />
                <p>10 Days Return</p>
            </div>
            <div class="benefit">
                <img src="assets/shipping.png" alt="Free Shipping" />
                <p>Free Shipping</p>
            </div>
        </div>

        <%-- Cards --%>
        <a id="new-collection"></a>
        <section class="new-collection">
            <h1>Shop New Collection</h1>

            <%-- Category --%>
            <asp:Panel ID="CategoryButtonsPanel" runat="server" HorizontalAlign="Left">
                <asp:Button ID="AllButton" runat="server" Text="All" CssClass="category-button active" OnClick="AllButton_Click" CommandArgument="all" />
                <asp:Button ID="KpopButton" runat="server" Text="Kpop" CssClass="category-button" OnClick="AllButton_Click" CommandArgument="kpop" />
                <asp:Button ID="NbaButton" runat="server" Text="NBA" CssClass="category-button" OnClick="AllButton_Click" CommandArgument="nba" />
                <asp:Button ID="Button4" runat="server" Text="Pokemon" CssClass="category-button" OnClick="AllButton_Click" CommandArgument="pokemon" />

            </asp:Panel>

            <div class="product-cards">
                <%--  display card dynamically from the DB --%>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="product-card">
                            <%-- image --%>
                            <div class="image-container">
                                <img src="data:image/png;base64,<%# Convert.ToBase64String((byte[])Eval("ImageCont")) %>" alt="Product Image" />
                                <%--                                    <img src='<%# Eval("ProdImageUrl") %>' alt='<%# Eval("ProdName") %>' />--%>
                            </div>
                            <div class="product-details">
                                <h3><%# Eval("prodName") %></h3>
                                <p class="product-price"><%# Eval("Price", "{0:RM #,##0.00}") %></p>
                                <p><%# Eval("Type") %></p>
                                <p>Stock: <%# Eval("Stock") %></p>
                            </div>
                            <%-- Product Details --%>
                            <%--  <div class="product-details">
                                    <h3><%# Eval("ProdName") %></h3>
                                    <p class="product-price"><%# Eval("ProdPrice", "{0:RM #,##0.00}") %></p>
                                    <p><%# Eval("ProdType") %></p>
                                </div>   
                            --%>
                            <div class="buy-now-wrapper">
                                <asp:Button ID="Button3" runat="server" CssClass="button" Text="Buy Now"
                                    CommandArgument='<%# Eval("prodID") %>' OnClick="Button3_Click" />
                            </div>

                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>
        <asp:Panel runat="server" Height="50px"></asp:Panel>
    </div>

</asp:Content>
