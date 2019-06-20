<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yenisifrebelirle.aspx.cs" Inherits="AracTakipSitesi.yenisifrebelirle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/password.css">
    <title>Araç Takip Sistemi</title>
</head>
<body>
        <div id="sifrebelirle" runat="server">
        <form class="box" runat="server">
            <p>
                <label for="password1">Yeni Şifre </label>
                <asp:TextBox ID="password" name="password" runat="server" type="password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="white" Font-Size="14px" runat="server" ErrorMessage="Şifrenizi giriniz" ControlToValidate="password"></asp:RequiredFieldValidator>
            </p>
            <p>
                <label for="confirm_password1">Şifre Onay</label>
                <asp:TextBox ID="confirm_password" runat="server" name="confirm_password" type="password"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="white" Font-Size="14px" runat="server" ErrorMessage="Şifrenizi giriniz" ControlToValidate="confirm_password"></asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:CompareValidator ID="comSifreKontrol" runat="server" ForeColor="white" Font-Size="16px" ControlToValidate="confirm_password" Display="Dynamic" ControlToCompare="password" ErrorMessage="Şifreleriniz eşleşmiyor"></asp:CompareValidator></p>
            <p>
                <input type="submit" class="sing_up" id="submit" value="KAYDET" runat="server" onserverclick="Submit_Click" />
            </p>
        </form>

    </div>

    <center><div runat="server" visible="false"  style="font-size:20px; color:white;" id="guncel">Kullanıcı Adınız= <asp:Literal ID="Literal1" runat="server"></asp:Literal><br />Şifreniz Güncellenmiştir.<a href="login.aspx" style="font-size:20px; color:white;">Giriş ekranına gitmak için tıklayınız!</a></center>
    </div>
    <center><div runat="server" visible="false"  style="font-size:20px; color:white;" id="yanlis">Zaman aşımına uğramıştır.<br />Lütfen yeni şifre almayı tekrar deneyiniz.</center>
    </div>
</body>
</html>
