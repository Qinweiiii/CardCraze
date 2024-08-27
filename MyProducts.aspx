<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyProducts.aspx.cs" Inherits="grp_assignment.MyProducts" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Display</title>
    <style>
        .title {
            font-size: 64px; 
            line-height: 60px; 
            float: left; 
            font-weight: 400; 
            font-family: Algerian; 
            line-height: 120px;
            margin-left: 20px;
            text-shadow: 1.5px 1.5px 3px black;
        }
        
        .product-container {
            display: flex;
            flex-wrap: wrap;
            /*border: 1px solid red;*/
            justify-content: center;
            margin-left: 5%;
            margin-right: 5%;
            margin-top: 30px;
            object-fit: cover;
        }
        .product-box {
            width: 20%;
            height: 500px;
            margin: 1%;
            padding: 15px;
            border: 1px solid #ccc;
            box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.1);
            position: relative;
            overflow: hidden;
        }
        .product-box img {
            width: 100%;
            height: auto;
            object-fit: cover;
        }
        .product-info {
            position: absolute;
            bottom: 0;
            width: 100%;
            background: rgba(255, 255, 255, 0.9);
            padding: 10px;
            transition: transform 0.3s ease-in-out;
            font-size: 18px;
            font-weight: 600;
        }
        .product-description {
            display: none;
            margin-right: 20px;
            padding-right: 10px;
            font-weight: 400;
        }
        .product-box:hover .product-info {
            transform: translateY(0);
        }
        .product-box:hover .product-description {
            display: block;
            transition: transform 0.3s ease-in-out;
        }
        .addButton {
            margin-top: 50px;
            background-color: #FFFACA;
            border: 0px solid #FCEC92;
            border-radius: 15px;
            box-shadow: rgba(0,0,0,0.2) -3px -2px inset;
            width: 200px;
            height: 100px;
            font-size: 24px;
            font-weight: 600;
            font-family: Algerian; 
            color: black;
        }
        .addButton:hover {
            background-color: #967B5C;
            color: white;
            text-shadow: 1.5px 1.5px 3px black;
            transition: background-color linear 0.5s;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="margin-bottom: 80px;">
        <center>
            <%-- Title for My Products page --%>
            <div style="border: 0px solid red; height: 120px; width: fit-content; margin-top: 30px;">
                <img src="/assets/poker-cards.png" alt="" style="height: 110px; float: left;"/>
                <span class="title">My Products</span>
            </div>
        </center>
        <div class="product-container">
            <%-- Keep making product container for each row in the table --%>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="product-box">
                        <img src="data:image/png;base64,<%# Convert.ToBase64String((byte[])Eval("ImageCont")) %>" alt="Product Image" />
                        <div class="product-info">
                            <h3><%# Eval("prodName") %></h3>
                            <p>Stock: <%# Eval("Stock") %></p>
                            <p>RM <%# Eval("Price") %>.00</p>
                            <div class="product-description">
                                <p><%# Eval("Description") %></p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <center>
            <asp:Button runat="server" ID="addButton" OnClick="addButton_Click" Text="Add Product" CssClass="addButton" />
        </center>
    </form>
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            var productBoxes = document.querySelectorAll(".product-box");

            // calculate the movement distance if the description needs to be shown
            productBoxes.forEach(function (box) {
                box.addEventListener("mouseenter", function () {
                    var productInfo = box.querySelector(".product-info");
                    var productDescription = box.querySelector(".product-description");
                    var descriptionHeight = productDescription.scrollHeight;
                    var gap = -15;  // Gap between price and description

                    //productDescription.style.transform = `translateY(-${descriptionHeight + gap}px)`;
                    productInfo.style.transform = `translateY(-${descriptionHeight + gap - 20}px)`;
                });

                box.addEventListener("mouseleave", function () {
                    var productInfo = box.querySelector(".product-info");
                    var productDescription = box.querySelector(".product-description");

                    productDescription.style.transform = `translateY(0)`;
                    productInfo.style.transform = `translateY(0)`;
                });
            });
        });
    </script>
</body>
</html>