<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AracTakipSitesi.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link rel="shortcut icon" href="./image/car.ico" />
    <link rel="stylesheet" href="css/sign.css" />
    <script src="https://code.jquery.com/jquery-2.1.0.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>Araç Takip Sistemi</title>
</head>
<body>
    <div class="logo-space"></div>
    <div class="authForm">
        <div class="member-list-singin">
            <div class="form-title">
                <h1>Üye Girişi</h1>
            </div>
            <form id="loginForm" class="sidebar-login" method="post" runat="server">
                <input type="text" ng-model="loginUsername" id="username" name="username" value="" runat="server" placeholder="KullanıcıAdı" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="red" Display="Dynamic" Font-Size="12px" runat="server" ErrorMessage="*Kullanıcı adı boş geçilemez" ControlToValidate="username"></asp:RequiredFieldValidator>

                <input type="password" ng-model="loginPassword" id="password" value="" runat="server" placeholder="Şifre" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="red" Display="Dynamic" Font-Size="12px" runat="server" ErrorMessage="*Şifre boş geçilemez" ControlToValidate="password"></asp:RequiredFieldValidator>

                <div class="forgotpass"><a href="uyekayit.aspx">Üye Ol</a></div>
                <div class="forgotpass"><a href="sifreyenile.aspx">Şifrenizi mi unuttunuz?</a></div>
                <input type="submit" value="Oturum Aç" class="singIn-button" runat="server" onserverclick="Submit_Click" />
                <%--   <button class="singIn-button" type="submit" name="signin" onserverclick="Submit_Click">Oturum Aç</button>--%>
                <div id="hata" runat="server">
                    <img src="image/yonetici/hata.png" alt="" />
                    <a>Hata :</a> lütfen kullanıcı adı ve şifrenizi kontol edin
                </div>
            </form>
        </div>

    </div>
</body>
</html>
