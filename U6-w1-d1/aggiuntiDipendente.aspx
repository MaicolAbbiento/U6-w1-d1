<%@ Page Title="" Language="C#" MasterPageFile="~/gestionale.Master" AutoEventWireup="true" CodeBehind="aggiuntiDipendente.aspx.cs" Inherits="U6_w1_d1.aggiuntiDipendente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>Nome</p>
    <asp:TextBox ID="Nome" runat="server" placeholder="Inserisci nome" ></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nome richiesto" ControlToValidate="Nome"></asp:RequiredFieldValidator>
    <p>Cognome</p>
    <asp:TextBox ID="Cognome" runat="server" placeholder="Inserisci Cognome"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Cognome richiesto" ControlToValidate="Cognome"></asp:RequiredFieldValidator>
    <p>Indirizzo</p>
    <asp:TextBox ID="Indirizzo" runat="server" placeholder="Inserisci Indirizzo"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Indirizzo richiesto" ControlToValidate="Indirizzo"></asp:RequiredFieldValidator>
    <p>Codice Fiscale</p>
    <asp:TextBox ID="CodiceFiscale" runat="server" placeholder="Inserisci Codice Fiscale"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="CodiceFiscale richiesto" ControlToValidate="CodiceFiscale"></asp:RequiredFieldValidator>
    <p> è cognugato?</p>
    <asp:CheckBox ID="coniugato" runat="server" />
    <p>Numero di figli</p>
    <asp:TextBox ID="NumeroFigli" TextMode="Number" runat="server" placeholder="Numero di figli"></asp:TextBox>

    <p>mansione</p>
    <asp:TextBox ID="mansione" runat="server" placeholder="Inserisci mansione"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="mansione richiesto" ControlToValidate="mansione"></asp:RequiredFieldValidator>
    <asp:Button ID="Button1" runat="server" Text="Button"  OnClick="Button1_Click"/>
    <p id="controll" runat="server"></p>

</asp:Content>
