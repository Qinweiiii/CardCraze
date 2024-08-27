<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="OrderPage.aspx.cs" Inherits="grp_assignment.OrderPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <title>Buy now</title>
    <link rel="stylesheet" href="OrderPageStyle.css"/>
    <form id="form1" runat="server">
        <div class="entire-screen">
            <%-- Floating main section --%>
            <div class="main-card">
                <%-- Left section of the floating card (Section for inputs and textfields) --%>
                <div class="left-container">
                    <%-- Back button to home page --%>
                    <div class="backbtn-container">
                        <asp:LinkButton CssClass="backBtn" runat="server" Text="Check Result" Font-Bold="True" Font-Size="Large" OnClick="click_Home">
                            <span>Back</span>
                        </asp:LinkButton>
                    </div>
                    <%-- Payment details --%>
                    <div class="details-container">
                        <h3 class="details-header">Payment Details</h3>
                        <div class="main-textfield-container">
                            <%-- Name --%>
                            <div class="tf-group">
                                <asp:Label ID="lbl_r_name" runat="server" Text="Recipient Name" CssClass="label"></asp:Label>
                                <asp:TextBox ID="r_name" runat="server" CssClass="inputfield"></asp:TextBox>
                            </div>

                            <%-- Shipping address --%>
                            <div class="tf-group">
                                <asp:Label ID="lbl_r_addr" runat="server" Text="Shipping address" CssClass="label"></asp:Label>
                                <asp:TextBox ID="r_addr" runat="server" CssClass="inputfield"></asp:TextBox>
                            </div>

                            <%-- Contact and Postal Code --%>
                            <div class="two-col-container">
                                <%-- Contact --%>
                                <div class="tf-group2">
                                    <asp:Label ID="lbl_r_c" runat="server" Text="Contact" CssClass="label"></asp:Label>
                                    <asp:TextBox ID="r_c" runat="server" CssClass="inputfield"></asp:TextBox>
                                </div>
                                <%-- Postal code --%>
                                <div class="tf-group2">
                                    <asp:Label ID="lbl_r_pc" runat="server" Text="Postal code" CssClass="label"></asp:Label>
                                    <asp:TextBox ID="r_pc" runat="server" CssClass="inputfield"></asp:TextBox>
                                </div>
                            </div>

                            <%-- Card Type --%>
                            <div class="two-col-container">
                                <div class="bankcontainer" id="bankcontainer" runat="server">
                                    <asp:RadioButton ID="bank" Text="Credit/Debit Card" runat="server" OnCheckedChanged="click_rb" CssClass="rb" GroupName="payment" AutoPostBack="true"/>
                                    <asp:Image ID="bankimg" Width="90px" Height="30px" runat="server" ImageUrl="https://www.confer.co.nz/wp-content/uploads/2018/09/visa-and-mastercard-logos-logo-visa-png-logo-visa-mastercard-png-visa-logo-white-png-awesome-logos.png"/>
                                </div>
                                <div class="tngcontainer" id="tngcontainer" runat="server">
                                    <asp:RadioButton ID="tng" Text="Touch n Go" runat="server" OnCheckedChanged="click_rb" CssClass="rb" GroupName="payment" AutoPostBack="true"/>
                                    <asp:Image ID="tngimg" Width="100px" Height="30px" runat="server" ImageUrl="https://emenu.com.my/_nuxt/img/tng-wallet-background.c72b798.jpg"/>
                                </div>
                            </div>
                            <%-- Card Number --%>
                            <div id="cardno" runat="server" class="tf-group">
                                <asp:Label ID="lbl_r_cnumber" runat="server" Text="Card Number" CssClass="label"></asp:Label>
                                <asp:TextBox ID="r_cnumber" runat="server" CssClass="inputfield" Placeholder="XXXX XXXX XXXX XXXX"></asp:TextBox>
                            </div>

                            <%-- Ex date and CVV number --%>
                            <div class="two-col-container">
                                <%-- Ex date --%>
                                <div id="cardex" runat="server" class="tf-group2">
                                    <asp:Label ID="lbl_r_exdate" runat="server" Text="Expiry Date" CssClass="label"></asp:Label>
                                    <asp:TextBox ID="r_exdate" runat="server" CssClass="inputfield" Placeholder="MM/YY"></asp:TextBox>   
                                </div>
                                <%-- CVV --%>
                                <div id="cardcvv" runat="server" class="tf-group2">
                                    <asp:Label ID="lbl_r_cvv" runat="server" Text="CVV" CssClass="label"></asp:Label>
                                    <asp:TextBox ID="r_cvv" runat="server" CssClass="inputfield" Placeholder="XXX"></asp:TextBox>
                                </div>
                                <%-- Phone no --%>
                                <div id="phone" runat="server" class="tf-group2">
                                    <asp:Label ID="lbl_r_phone" runat="server" Text="Account Phone Number" CssClass="label"></asp:Label>
                                    <asp:TextBox ID="r_phone" runat="server" CssClass="inputfield" Placeholder="(+60)-1X-XXX-XXXX"></asp:TextBox>
                                </div>
                                <%-- Password --%>
                                <div id="pw" runat="server" class="tf-group2">
                                    <asp:Label ID="lbl_r_pw" runat="server" Text="Password" CssClass="label"></asp:Label>
                                    <asp:TextBox ID="r_pw" runat="server" CssClass="inputfield" ></asp:TextBox>
                                </div>
                            </div>
                            <%-- Pay Now Button --%>
                            <div class="pay-container">
                                <asp:LinkButton CssClass="payBtn" runat="server" Text="Pay Now" Font-Bold="True" Font-Size="Large" OnClick="click_Pay">
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- Right section of the floating card --%>
                <div class="right-container">
                    <%-- Floating card (Order Summary) --%>
                    <div class="floating-card">
                        <%-- Contents --%>
                        <div class="summary-contents">
                            <%-- Order Summary Header --%>
                            <div class="os-container">
                                <h2 class="os-text">Order Summary</h2>
                            </div>
                        </div>
                        <%-- Card text header --%>
                        <div class="c-container">
                            <h4 class="c-text">Card</h4>
                        </div>
                        <%-- Row --%>
                        <div class="row-container">
                            <%-- Card pic --%>
                            <div class="card-pic-container">
                                <asp:Image ID="cardpic" Width="150px" runat="server" ImageUrl="https://www.panini.co.uk/media/wysiwyg/HPCTC_2_SP_1200x1200_copy_2_1.png" />
                            </div>
                            <%-- Card name --%>
                            <div class="card-name-container">
                                <h3 class="card-name-text">Hahah</h3>
                            </div>
                            <%-- Card quantity --%>
                            <div class="card-qt-container">
                                <h3 class="card-qt-text">x1</h3>
                            </div>
                            <%-- Card price --%>
                            <div class="card-price-container">
                                <h3 class="card-price-text">RM 100</h3>
                            </div>
                        </div>
                        <hr class="divider"/>
                        <%-- Costs --%>
                        <div class="cost-container">
                            <%-- card-cost --%>
                            <div class="cost-row">
                                <h4 class="feename">Card total:</h4>
                                <h4 class="cost">RM100</h4>
                            </div>
                            <%-- shipping-cost --%>
                            <div class="cost-row">
                                <h4 class="feename">Delivery charge:</h4>
                                <h4 class="cost">RM5</h4>
                            </div>
                            <%-- Service charge --%>
                            <div class="cost-row">
                                <h4 class="feename">Service tax:</h4>
                                <h4 class="cost">RM5</h4>
                            </div>
                        </div>
                        <hr class="divider2"/>
                        <%-- Final Cost --%>
                        <div class="final-cost-container">
                            <div class="cost-row">
                                <h4 class="feename2">Total Amount:</h4>
                                <h4 class="cost2">RM110</h4>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
