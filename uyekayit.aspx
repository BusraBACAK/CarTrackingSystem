<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uyekayit.aspx.cs" Inherits="AracTakipSitesi.uyekayit" %>

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
        <div class="member-list-newAccount">
            <div class="form-title">
                <h1>Üye Kayıt</h1>
            </div>
            <form id="registerForm" class="newAccount" layout="column" runat="server" >
                <input placeholder="Ad Soyad" name="fullName" id="fullName" runat="server" value="" type="text" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ErrorMessage="Ad Soyad boş geçilemez" ForeColor="red" Font-Size="10px" ControlToValidate="fullName"></asp:RequiredFieldValidator>
               
                <input placeholder="E-Posta" name="email" id="email" runat="server" value="" type="text" />
                <asp:RegularExpressionValidator Font-Size="10px" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Hatalı E-Posta" ForeColor="red" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ControlToValidate="email" EnableClientScript="true"></asp:RegularExpressionValidator >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ForeColor="red" runat="server" Font-Size="10px" ErrorMessage="E-Posta boş geçilemez" ControlToValidate="email"></asp:RequiredFieldValidator>
               
                <input placeholder="Telefon" name="tel" id="tel" runat="server" value="" type="text" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Font-Size="10px" runat="server" ErrorMessage="Telefon Numarası Hatalı" ForeColor="red" ValidationExpression="(([\+]90?)|([0]?))([ ]?)((\([0-9]{3}\))|([0-9]{3}))([ ]?)([0-9]{3})(\s*[\-]?)([0-9]{2})(\s*[\-]?)([0-9]{2})" ControlToValidate="tel"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ForeColor="red" runat="server" Font-Size="10px" ErrorMessage="Telefon numaranız boş geçilemez" ControlToValidate="tel"></asp:RequiredFieldValidator>
          
                <div class="inputContainer">
                    <input class="userName-input" placeholder="KullanıcıAdı" id="username" runat="server" name="username" value="" type="text" />
                    <input class="password-input" placeholder="Şifre" id="password" runat="server" name="password" value="" type="password" />
                  </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" runat="server" ForeColor="red" Font-Size="10px" ErrorMessage="Kullanıcı adı boş geçilemez" ControlToValidate="username"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="red" Font-Size="10px" Display="Dynamic" runat="server" ErrorMessage="Şifrenizi giriniz" ControlToValidate="password"></asp:RequiredFieldValidator>

                <input type="submit" class="sing_up" value="Kaydol" runat="server" onserverclick="Submit_Click" />
                <div id="hata" visible="false" runat="server">
                    <img src="image/yonetici/hata.png" alt="" />
                    <a>Hata :</a> Kaydınız mevcuttur.</div>

            </form>
        </div>
    </div>
</body>
</html>
