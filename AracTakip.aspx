<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="AracTakip.aspx.cs" Inherits="AracTakipSitesi.WebForm2" enableSessionState = "true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="css/grid.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>

            <asp:MultiView ID="MultiView1" runat="server">

                <asp:View ID="View1" runat="server">
                    <asp:GridView ID="GridView1" runat="server"
                        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataMember="ID" DataKeyNames="ID"
                        AutoGenerateSelectButton="true" AutoGenerateColumns="false" nActiveViewChanged="MultiView1_ActiveViewChanged"
                        CssClass="mydatagrid" PagerStyle-CssClass="pager" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging"
                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="true">
                        <Columns>
                            <asp:TemplateField HeaderText="FOTOGRAF">
                                <ItemTemplate>
                                    <asp:Image ID="foto" runat="server" ImageUrl='<%# Eval("FOTO") %>' Height="80px" Width="80px" />                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PLAKA NUMARASI">
                                <ItemTemplate>
                                    <asp:Literal ID="id" runat="server" Text='<%# Eval("PLAKA_NUMARASI") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BIRIM ADI">
                                <ItemTemplate>
                                    <asp:Literal ID="urun_adi" runat="server" Text='<%# Eval("BIRIM_ADI") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MARKA">
                                <ItemTemplate>
                                    <asp:Literal ID="urun_adi" runat="server" Text='<%# Eval("MARKA") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MODEL">
                                <ItemTemplate>
                                    <asp:Literal ID="urun_adi" runat="server" Text='<%# Eval("MODEL") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MODEL YILI">
                                <ItemTemplate>
                                    <asp:Literal ID="urun_adi" runat="server" Text='<%# Eval("MODEL_YILI") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CESIT">
                                <ItemTemplate>
                                    <asp:Literal ID="urun_adi" runat="server" Text='<%# Eval("CESIT") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TUR">
                                <ItemTemplate>
                                    <asp:Literal ID="urun_adi" runat="server" Text='<%# Eval("TUR") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ARAC DURUMU">
                                <ItemTemplate>
                                    <asp:Literal ID="urun_adi" runat="server" Text='<%# Eval("ARAC_DURUMU") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>
                     <%-- <div>
                        <asp:Button ID="Button5" runat="server" CssClass="button" Style="width: 100px;" OnClick="Button1_Click" Text="YENİ" />
                    </div>--%>
                </asp:View>
                <asp:View ID="View2" runat="server">
                   <center><table>  
                          <tr>
                            <td>
                            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>  <asp:Image ID="fotograf" runat="server"  Height="150px" Width="150px" /> 
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" /><br />
                                  <asp:Button ID="Button2" runat="server" Text="FOTOGRAF GUNCELLE" OnClick="Foto_Guncelle" />
                            </td>
                         
                        </tr>
<%--                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="FOTOGRAF :"></asp:Label></td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" /><br />
                            </td>
                            <td>
                                <asp:Button ID="Button2" runat="server" Text="GUNCELLE" OnClick="Foto_Guncelle"></asp:Button>
                            </td>
                        </tr>--%>
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
                                <asp:DropDownList ID="DropDownList1" name="DropDownList1" runat="server"> </asp:DropDownList>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Display="Dynamic" ForeColor="red" Font-Size="12px" runat="server" ErrorMessage="*Araç model yılı boş geçilemez" ControlToValidate="DropDownList1"></asp:RequiredFieldValidator>
                          </td>
                        </tr>
                         <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="ÇEŞİT:"></asp:Label></td>
                            <td>
                              
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                <asp:ListItem Value="OTOMOBIL">OTOMOBIL</asp:ListItem>
                                <asp:ListItem Value="MINIBUS">MINIBUS</asp:ListItem>
                                <asp:ListItem Value="OTOBUS">OTOBÜS</asp:ListItem>
                                <asp:ListItem Value="KAMYONET">KAMYONET</asp:ListItem>
                            </asp:RadioButtonList>   <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" controltovalidate="RadioButtonList1" errormessage="Lütfen bir çeşit seçiniz!"></asp:requiredfieldvalidator>
                 </td>
                        </tr>
                         <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="TUR:"></asp:Label></td>
                            <td>
                                 <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                                <asp:ListItem Value="HAVA ARACI">HAVA ARACI</asp:ListItem>
                                <asp:ListItem Value="SAHA ARACI">SAHA ARACI</asp:ListItem>
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
                        <tr><td colspan="2" >
                            <table>
                                <tr>
                             <td><asp:Button ID="Button7" runat="server" CssClass="button" OnClick="Button7_Click" Text="SİL" /></td>
                          <td><asp:Button ID="Button8" runat="server" CssClass="button" OnClick="Button8_Click" Text="GÜNCELLE" /></td>
                           <td> <asp:Button ID="Button9" runat="server" CssClass="button" OnClick="Button9_Click" Text="GERİ" /></td>
                          </tr> </table>
                    </td></tr>
                    </table></center> 
                </asp:View>
            </asp:MultiView>
    </center>

</asp:Content>
