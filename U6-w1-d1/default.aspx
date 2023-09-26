<%@ Page Title="" Language="C#" MasterPageFile="~/gestionale.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="U6_w1_d1._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" ItemType="U6_w1_d1.Dipendente">
        <ItemTemplate>
        <div> 
            <p><%# Item.Nome %> <%# Item.Cognome %>  mansione <%# Item.Mansione %> 
                ha <%# Item.NumeroDiFigli%> figli/o  il suo codice fiscale è <%# Item.CodiceFiscale %>
                <%# Item.Coniugatostring %>

            </p> 

        </div>

        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
