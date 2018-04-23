<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ServerModeEF" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to switch the ASPxGridView between some data sources (the LinqServerModeDataSource and the EntityServerModeSource) at Runtime</title>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxComboBox ID="navigateComboBox" runat="server" SelectedIndex="0" ValueType="System.Int32">
            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	Grid.PerformCallback();
}" />
            <Items>
                <dx:ListEditItem Text="Entity Framework DataSource" Value="0" />
                <dx:ListEditItem Text="LinqServerModeDataSource" Value="1" />
            </Items>
        </dx:ASPxComboBox>
        <dx:ASPxGridView ID="grid" runat="server" ClientInstanceName="Grid" OnCustomCallback="grid_CustomCallback" ViewStateMode="Disabled">
        </dx:ASPxGridView>
    </form>
</body>
</html>
