<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="grp_assignment.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CardCraze</title>
    <script src="https://cdn.tailwindcss.com?plugins=forms,typography,aspect-ratio,line-clamp,container-queries"></script>
    <style>
        .background-image {
            background-image: url("/assets/bg.png");
            background-size: cover;
            background-position: center;
        }

        body {
            font-family: "Poppins";
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="w-screen min-h-screen">
            <div class="flex">
                <div class="w-[100%] md:block md:w-[40%] min-h-screen">
                    <div class="w-full">
                        <div class="flex justify-start">
                            <div class="w-28 h-28">
                                <img src="/assets/logo.png" alt="" />
                            </div>
                        </div>
                        <div class="mx-auto w-[80%] rounded-md px-10">
                            <h2 class="text-black text-3xl text-center mb-3">Create your Free Account
                            </h2>
                            <div>
                                <label class="block text-gray-700 mb-2" for="email">
                                    Email</label>
                                <asp:TextBox class="w-full px-4 py-2 text-gray-700 bg-white border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
                                    ID="EmailTextBox" runat="server" placeholder="Enter your email"></asp:TextBox>
                            </div>
                            <div class="mt-3">
                                <label class="block text-gray-700 mb-2" for="email">
                                    Full Name</label>
                                <asp:TextBox class="w-full px-4 py-2 text-gray-700 bg-white border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
                                    ID="NameTextBox" runat="server" placeholder="Enter your name"></asp:TextBox>
                            </div>
                            <div class="mt-3">
                                <label class="block text-gray-700 mb-2" for="email">
                                    Password</label>
                                <asp:TextBox class="w-full px-4 py-2 text-gray-700 bg-white border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
                                    ID="PasswordTextBox" type="password" runat="server" placeholder="Enter your password"></asp:TextBox>
                            </div>
                            <div class="mt-3">
                                <label class="block text-gray-700 mb-2" for="email">
                                    Confirm Password</label>
                                <asp:TextBox type="password" class="w-full px-4 py-2 text-gray-700 bg-white border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
                                    ID="ConfirmPasswordTextBox" runat="server" placeholder="Confirm your password"></asp:TextBox>
                            </div>

                            <div class="mt-3">
                                <asp:Button ID="SignUp" OnClick="On_Register" runat="server" Text="Sign Up" class="cursor-pointer w-full py-3 bg-yellow-500 text-white rounded-xl shadow-md hover:bg-yellow-600 transition duration-300" />
                                <p class="text-center">
                                    <asp:Label ID="ErrorMessage" runat="server" Text="" CssClass="text-red-500"></asp:Label>
                                </p>
                                <p class="text-gray-700 text-center">
                                    Already have an account?
                                <asp:Button ID="Login" runat="server" OnClick="Go_Login" Text="Sign in here" CssClass="underline cursor-pointer" />
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="hidden md:flex md:w-[60%] background-image mx-auto flex justify-center">
                    <div class="px-10 w-full flex flex-col justify-center items-start">
                        <h2 class="text-4xl text-white">Unleash the Power of Trading Cards
                        </h2>
                        <p class="text-white text-xl mt-5">
                            Join thousands of enthusiasts on CardCraze, the ultimate platform
              for trading cards. Buy, sell, and trade cards, participate in
              exciting gacha draws, and earn points for exclusive rewards.
              Experience a gamified environment where your card trading dreams
              come true.
                        </p>
                        <div class="flex items-center">
                            <div class="mt-3 flex -space-x-4 rtl:space-x-reverse">
                                <img
                                    class="w-10 h-10 border-2 border-white rounded-full"
                                    src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR16FJJT82hjODrw-YFbXwv0pbAFCixsJLzqA&s"
                                    alt="" />
                                <img
                                    class="w-10 h-10 border-2 border-white rounded-full"
                                    src="https://www.sfsimplified.com/content/images/2023/05/IMG_9044.jpg"
                                    alt="" />
                                <img
                                    class="w-10 h-10 border-2 border-white rounded-full"
                                    src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTYlBuXLPbMYMIKzJYkJmIjuJhlSZnSF06mZA&s"
                                    alt="" />
                                <img
                                    class="w-10 h-10 border-2 border-white rounded-full"
                                    src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRBDb_ScK-_Z45lyFXgEiYPUFnrP3MQAphxtg&s"
                                    alt="" />
                            </div>
                            <div class="ml-5 w-0.5 h-6 mt-1 bg-white"></div>
                            <div class="mt-1 text-white ml-3">
                                Over <b>25.5k</b> happy customers
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
