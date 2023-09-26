<%@ Page Title="" Language="C#" MasterPageFile="~/gestionale.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="U6_w1_d1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Repeater ID="Repeater1" runat="server" ItemType="U6_w1_d1.Pagamento">
     <ItemTemplate>
     <div class=" container m-2 border border-1"> 

         <p><%# Item.Pagamenti.ToString("C2") %> a <%# Item.Id %>  mansione effetuato il <%#  Item.PeriodoPagamento.Remove(10) %>
             è uno stipendio?  <%# Item.Stipendio%> 

         </p> 

     </div>

     </ItemTemplate>
 </asp:Repeater>
</asp:Content>
