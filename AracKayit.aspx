<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="AracKayit.aspx.cs" Inherits="AracTakipSitesi.WebForm3" EnableSessionState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>
          <center><table>  <tr>
                            <td>
                             <asp:Label ID="Label4" runat="server" Text="FOTOGRAF :"></asp:Label> 
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" ClientIDMode="Static" AllowMultiple="true" /><br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="PLAKA NUMARASI:"></asp:Label></td>
                            <td>
                                 <asp:TextBox ID="plaka_numarasi" name="plaka_numarasi" placeholder="Araç Plaka Numarası" runat="server" CssClass="textEditor" onblur="Test()"  ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" ForeColor="red" Font-Size="12px" runat="server" ErrorMessage="*Plaka Numarası boş geçilemez" ControlToValidate="plaka_numarasi"></asp:RequiredFieldValidator>
                         </td>
                        </tr>
                      
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="BİRİM ADI:"></asp:Label></td>
                            <td>
                                 <asp:TextBox ID="birim_adi" name="birim_adi" placeholder="Araç Birim Adı"   runat="server" CssClass="textEditor" onblur="Test()"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" ForeColor="red" Font-Size="12px" runat="server" ErrorMessage="*Birim Adı boş geçilemez" ControlToValidate="birim_adi"></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="MARKA:"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="marka"  name="marka" placeholder="Araç Markası"  runat="server" CssClass="textEditor" onblur="Test()"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" ForeColor="red" Font-Size="12px" runat="server" ErrorMessage="*Araç markası boş geçilemez" ControlToValidate="marka"></asp:RequiredFieldValidator>
                           </td>
                        </tr>
                         <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="MODEL:"></asp:Label></td>
                            <td>
                                 <asp:TextBox ID="model" name="model" placeholder="Araç Modeli"  runat="server" CssClass="textEditor" onblur="Test()"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" ForeColor="red" Font-Size="12px" runat="server" ErrorMessage="*Araç modeli boş geçilemez" ControlToValidate="model"></asp:RequiredFieldValidator>
                           </td>
                        </tr>
                         <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="MODEL YILI:"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="DropDownList1"  name="DropDownList1" runat="server"> 
                                </asp:DropDownList>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Display="Dynamic" ForeColor="red" Font-Size="12px" runat="server" ErrorMessage="*Araç model yılı boş geçilemez" ControlToValidate="DropDownList1"></asp:RequiredFieldValidator>
                          </td>
                        </tr>
                         <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="ÇEŞİT:"></asp:Label></td>
                            <td>
                              
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                <asp:ListItem Value="OTOMOBIL">OTOMOBİL</asp:ListItem>
                                <asp:ListItem Value="MINIBUS">MİNİBÜS</asp:ListItem>
                                <asp:ListItem Value="OTOBUS">OTOBÜS</asp:ListItem>
                                <asp:ListItem Value="KAMYONET">KAMYONET</asp:ListItem>
                            </asp:RadioButtonList>   <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" controltovalidate="RadioButtonList1" errormessage="Lütfen bir çeşit seçiniz!"></asp:requiredfieldvalidator>
               
                              <%--  <asp:TextBox ID="cesit" TextMode="MultiLine" runat="server" CssClass="textEditor" onblur="Test()"></asp:TextBox>--%>
                            </td>
                        </tr>
                         <tr>
                            <td> 
                                <asp:Label ID="Label8" runat="server" Text="TUR:"></asp:Label></td>
                            <td>
                              
                            <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                                <asp:ListItem Value="HAVA ARACI">Hava Aracı</asp:ListItem>
                                <asp:ListItem Value="SAHA ARACI">Saha Aracı</asp:ListItem>
                            </asp:RadioButtonList>   <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" controltovalidate="RadioButtonList2" errormessage="Lütfen bir tür seçiniz!"></asp:requiredfieldvalidator>
               
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="ARAÇ DURUMU:"></asp:Label></td>
                            <td>
                                  <asp:RadioButtonList ID="RadioButtonList3" runat="server">
                                <asp:ListItem Value="AKTIF">AKTIF</asp:ListItem>
                                <asp:ListItem Value="PASIF">PASIF</asp:ListItem>
                            </asp:RadioButtonList>   <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" controltovalidate="RadioButtonList3" errormessage="Lütfen bir durum seçiniz!"></asp:requiredfieldvalidator>
               
                            </td>
                        </tr>
               <tr><td></td><td>

                    <asp:Button ID="Button6" runat="server" CssClass="button" OnClick="Button6_Click" Text="KAYDET" />

                   </td>

               </tr>
                    </table></center> </div>


</asp:Content>
