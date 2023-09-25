<%@ Page Title="" Language="C#" MasterPageFile="~/gestionale.Master" AutoEventWireup="true" CodeBehind="faiUnpagamento.aspx.cs" Inherits="U6_w1_d1.faiUnpagamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>inserisci codice fiscale del dipendente a cui fare l'acredito </p>
    <asp:TextBox ID="CodiceFiscale" runat="server" placeholder="Inserisci codice fiscale"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="codice fiscale richiesto" ControlToValidate="CodiceFiscale"></asp:RequiredFieldValidator>
    <p>inserisci la somma dell'acredito </p>
    <asp:TextBox ID="soldi" runat="server" placeholder="Inserisci acredito"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="campo richiesto" ControlToValidate="soldi"></asp:RequiredFieldValidator>
        <p id ="errore1" runat="server"> </p>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Value="stipendio" Text="stipendio"></asp:ListItem>
        <asp:ListItem Value="acconto" Text="acconto"></asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="Button1" runat="server" Text="Button"  OnClick="Button1_Click"/>

</asp:Content>
