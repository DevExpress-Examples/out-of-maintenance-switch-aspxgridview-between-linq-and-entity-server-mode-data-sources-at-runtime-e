using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Data.Linq;
using DevExpress.Web.ASPxGridView;
using NorthwindModel;


public partial class ServerModeEF : System.Web.UI.Page
{
   const string compaundkey = "CustomerName,Salesperson,OrderID,ShipperName,ProductID,ProductName,UnitPrice,Quantity,Discount";
 
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Session.Clear();
        SetGridProperties();
    }

    protected void lnsource_Selecting(object sender, LinqServerModeDataSourceSelectEventArgs e)
    {
        e.KeyExpression = compaundkey;
    }

    private void SetGridProperties()
    {
        grid.Columns.Clear();
        grid.AutoGenerateColumns = true;
        grid.KeyFieldName = GetKeyName();
        grid.DataSource = GetDataSource();
        grid.DataBind();
    }

    protected string GetKeyName()
    {
       int i = (Session["DataSource"] != null) ? (int)Session["DataSource"] : 0;
        switch(i)
        {
            case 1:
                return compaundkey;
            default:
                return "OrderID";
        }
    }
    protected void grid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        Session["DataSource"] = navigateComboBox.Value;
        SetGridProperties();
    }
    protected object GetDataSource()
    {
        int i = (Session["DataSource"] != null) ? (int)Session["DataSource"] : 0;
        switch (i)
        {
            case 1:
                {
                    LinqServerModeDataSource lnsource = new LinqServerModeDataSource { ContextTypeName = "NorthwindModel.NorthwindEntities", TableName = "Invoices" };
                    lnsource.Selecting += lnsource_Selecting;
                    return lnsource;
                }
            default:
                return new EntityServerModeSource { QueryableSource = new NorthwindEntities().Orders, KeyExpression = "OrderID" };
        }
    }
}
