<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sifreyenile.aspx.cs" Inherits="AracTakipSitesi.sifreyenile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" href="css/sign.css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/> 
       <script src="https://code.jquery.com/jquery-2.1.0.min.js"></script>
    <title></title>
</head>
<body>
    <div class="logo-space"></div>
    <div class="authForm">
        <div class="member-list-singin">
            <div class="form-title">
                <h1>Mail Adresinizi Giriniz</h1>
            </div>
            <form id="loginForm" class="sidebar-login" method="post" runat="server">
                <input type="text" ng-model="email" id="email" name="email" value="" runat="server" placeholder="email" /> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ErrorMessage="lütfen E-postanızı giriniz." ForeColor="red" Font-Size="10px" ControlToValidate="email"></asp:RequiredFieldValidator>
               
                <asp:Label ID="Label1" runat="server" Text="Aktivasyon maili alabilmek için mail adresinizi giriniz."></asp:Label>
                <input type="submit" value="Gönder" class="singIn-button" runat="server" onserverclick="Submit_Click" />
                <%--   <button class="singIn-button" type="submit" name="signin" onserverclick="Submit_Click">Oturum Aç</button>--%>
                <div id="hata" runat="server" visible="False">
                    <img src="image/yonetici/hata.png" alt="" />
                    <a>Hata :</a> lütfen E-postanızı kontol ediniz.
                </div>
             
            </form>
        </div>

    </div>
</body>
</html>
