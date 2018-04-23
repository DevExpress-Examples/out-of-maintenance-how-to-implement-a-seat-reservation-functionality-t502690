Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

''' <summary>
''' Summary description for DataSource
''' </summary>
Public Class DataSource
    Public Function PopulateSeats(ByVal rows As Integer, ByVal seatsInRow As Integer) As List(Of Seat)
        Dim list As New List(Of Seat)()
        For i As Integer = 0 To rows - 1
            For j As Integer = 0 To seatsInRow - 1
                list.Add(New Seat() With {.IsFree = True, .Text = i * seatsInRow + j + 1})
            Next j
        Next i
        Return list
    End Function

End Class