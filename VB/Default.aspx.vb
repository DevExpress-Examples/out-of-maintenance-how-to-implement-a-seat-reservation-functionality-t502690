Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Private Const rows As Integer = 5
    Private Const seatsInRow As Integer = 12

    Protected Overrides Sub OnInit(ByVal e As EventArgs)
        MyBase.OnInit(e)
        Me.CreateDynamicTable()
        ASPxCallbackPanel1.Controls.Add(table)
    End Sub
    Public ReadOnly Property ListOfSeats() As List(Of Seat)
        Get
            If Session("ListOfSeats") Is Nothing Then
                Session("ListOfSeats") = (New DataSource()).PopulateSeats(rows,seatsInRow)
            End If
            Return TryCast(Session("ListOfSeats"), List(Of Seat))

        End Get
    End Property

    Private table As Table
    Private Sub CreateDynamicTable()
        table = New Table()
        For i As Integer = 0 To rows - 1
            Dim tr As New TableRow()
            Dim rowHeader As New TableCell()
            rowHeader.CssClass = "label"
            rowHeader.Text = "row " & (i+1).ToString()
            tr.Cells.Add(rowHeader)
            For j As Integer = 0 To seatsInRow - 1
                Dim tc As New TableCell()
                Dim index As Integer = i * seatsInRow + j
                Dim txt As New Label()
                txt.ID = "seat|" & index
                txt.CssClass = "label " & Me.GetClassName(ListOfSeats(index).IsFree)
                txt.Text = ListOfSeats(index).Text.ToString()
                AddHandler txt.Init, AddressOf Txt_Init
                tc.Controls.Add(txt)
                tr.Cells.Add(tc)
            Next j
            table.Rows.Add(tr)
        Next i
    End Sub

    Private Sub Txt_Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim txt As Label = TryCast(sender, Label)
        txt.Attributes.Add("onclick", String.Format("labelClick('{0}');", txt.ClientID))
    End Sub

    Public Function GetClassName(ByVal isFree As Boolean) As String
        If isFree Then
            Return "free"
        End If
        Return "reserved"
    End Function


    Protected Sub ASPxCallbackPanel1_Callback(ByVal sender As Object, ByVal e As CallbackEventArgsBase)
        Dim values() As String = e.Parameter.Split(","c)
        For Each value As String In values
            Dim seat As Integer = Integer.Parse(value.Split("|"c)(1))
            ListOfSeats(seat).IsFree = False
            ASPxCallbackPanel1.Controls.Remove(table)
            Me.CreateDynamicTable()
            ASPxCallbackPanel1.Controls.Add(table)
        Next value
    End Sub

End Class