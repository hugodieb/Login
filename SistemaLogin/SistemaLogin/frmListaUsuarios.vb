Imports System.Data
Imports System.Data.OleDb

Public Class frmListaUsuarios

    Private Sub frmListaUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carregaDados()

    End Sub

    Private Sub carregaDados()

        Using con As OleDbConnection = getConnection()
            Try
                con.Open()
                Dim sql As String = "select * from usuarios"
                Dim cmd As OleDbCommand = New OleDbCommand(sql, con)
                Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim dt As DataTable = New DataTable
                da.Fill(dt)

                dgvListaUsuarios.DataSource = dt

            Catch ex As Exception
                MsgBox("Ocorreu um erro ao tentar carregar a lista de usuarios.", MsgBoxStyle.Information, "Sistema Login")
            Finally
                con.Close()
            End Try
        End Using

    End Sub

    Private Sub selecionaUsuarios()

        intCodigoUsuario = dgvListaUsuarios.CurrentRow.Cells("codigo").Value

        Me.Dispose()
    End Sub

    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
        selecionaUsuarios()
    End Sub
End Class