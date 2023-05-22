Imports System.Data.Odbc
Public Class Form1

    Dim odbc_connection As Odbc.OdbcConnection
    Dim odbc_adapter As Odbc.OdbcDataAdapter
    Dim odbc_reader As Odbc.OdbcDataReader
    Dim odbc_command As Odbc.OdbcCommand
    Dim data_set As New DataSet

    Function CheckConnection() As Boolean
        odbc_connection = New Odbc.OdbcConnection("DRIVER={MySQL ODBC 8.0 UNICODE Driver};DSN=host;server:127.0.0.1;uid=root;pw=;database=item_db")

        Try
            If odbc_connection.State = ConnectionState.Closed Then
                odbc_connection.Open()
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Sub PopulateTable()
        Try
            odbc_adapter = New OdbcDataAdapter("SELECT * FROM tblitems", odbc_connection)
            data_set = New DataSet()
            odbc_adapter.Fill(data_set)
            dg_view_item.DataSource = data_set.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            odbc_connection.Close()
        End Try

    End Sub

    Function ClearTxtBox()
        txt_itemname.Clear()
        txt_itemdescription.Clear()
        txt_price.Clear()
        txt_qty.Clear()

    End Function

    Private Sub frm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckConnection()
        PopulateTable()
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        CheckConnection()
        Try
            odbc_command = New OdbcCommand("INSERT INTO tblitems(ITEMNAME,ITEMDESCRIPTION,QTY,PRICE) VALUES ('" & txt_itemname.Text & "',   '" & txt_itemdescription.Text & "', '" & txt_qty.Text & "', '" & txt_price.Text & "')", odbc_connection)
            odbc_command.ExecuteNonQuery()

            PopulateTable()
            ClearTxtBox()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            odbc_connection.Close()
        End Try
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        CheckConnection()
        Try
            odbc_command = New OdbcCommand("UPDATE tblitems set ITEMNAME='" & txt_itemname.Text & "',ITEMDESCRIPTION='" & txt_itemdescription.Text & "',QTY='" & txt_qty.Text & "',PRICE='" & txt_price.Text & "'  WHERE ID='" & Me.Text & "'", odbc_connection)
            odbc_command.ExecuteNonQuery()

            PopulateTable()
            ClearTxtBox()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            odbc_connection.Close()
        End Try
    End Sub

    Private Sub dg_view_item_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_view_item.CellClick

        Me.Text = dg_view_item.CurrentRow.Cells(0).Value
        txt_itemname.Text = dg_view_item.CurrentRow.Cells(1).Value
        txt_itemdescription.Text = dg_view_item.CurrentRow.Cells(2).Value
        txt_qty.Text = dg_view_item.CurrentRow.Cells(3).Value
        txt_price.Text = dg_view_item.CurrentRow.Cells(4).Value

    End Sub

    Private Sub dg_view_item_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_view_item.CellContentClick

        Me.Text = dg_view_item.CurrentRow.Cells(0).Value
        txt_itemname.Text = dg_view_item.CurrentRow.Cells(1).Value
        txt_itemdescription.Text = dg_view_item.CurrentRow.Cells(2).Value
        txt_qty.Text = dg_view_item.CurrentRow.Cells(3).Value
        txt_price.Text = dg_view_item.CurrentRow.Cells(4).Value

    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        CheckConnection()
        Try
            odbc_command = New OdbcCommand("DELETE FROM tblitems WHERE ID='" & Me.Text & "'", odbc_connection)
            odbc_command.ExecuteNonQuery()

            PopulateTable()
            ClearTxtBox()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            odbc_connection.Close()
        End Try
    End Sub
End Class
