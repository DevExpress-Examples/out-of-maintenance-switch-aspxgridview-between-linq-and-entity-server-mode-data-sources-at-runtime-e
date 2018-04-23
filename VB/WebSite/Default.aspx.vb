Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.Data.Linq
Imports DevExpress.Web.ASPxGridView
Imports NorthwindModel


Partial Public Class ServerModeEF
	Inherits System.Web.UI.Page
   Private Const compaundkey As String = "CustomerName,Salesperson,OrderID,ShipperName,ProductID,ProductName,UnitPrice,Quantity,Discount"

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		If (Not IsPostBack) Then
			Session.Clear()
		End If
		SetGridProperties()
	End Sub

	Protected Sub lnsource_Selecting(ByVal sender As Object, ByVal e As LinqServerModeDataSourceSelectEventArgs)
		e.KeyExpression = compaundkey
	End Sub

	Private Sub SetGridProperties()
		grid.Columns.Clear()
		grid.AutoGenerateColumns = True
		grid.KeyFieldName = GetKeyName()
		grid.DataSource = GetDataSource()
		grid.DataBind()
	End Sub

	Protected Function GetKeyName() As String
	   Dim i As Integer
	   If (Session("DataSource") IsNot Nothing) Then
		   i = CInt(Fix(Session("DataSource")))
	   Else
		   i = 0
	   End If
		Select Case i
			Case 1
				Return compaundkey
			Case Else
				Return "OrderID"
		End Select
	End Function
	Protected Sub grid_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
		Session("DataSource") = navigateComboBox.Value
		SetGridProperties()
	End Sub
	Protected Function GetDataSource() As Object
		Dim i As Integer
		If (Session("DataSource") IsNot Nothing) Then
			i = CInt(Fix(Session("DataSource")))
		Else
			i = 0
		End If
		Select Case i
			Case 1
					Dim lnsource As LinqServerModeDataSource = New LinqServerModeDataSource With {.ContextTypeName = "NorthwindModel.NorthwindEntities", .TableName = "Invoices"}
					AddHandler lnsource.Selecting, AddressOf lnsource_Selecting
					Return lnsource
			Case Else
				Return New EntityServerModeSource With {.QueryableSource = New NorthwindEntities().Orders, .KeyExpression = "OrderID"}
		End Select
	End Function
End Class
