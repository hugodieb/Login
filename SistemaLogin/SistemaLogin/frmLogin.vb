Imports System.Data.OleDb

Public Class frmLogin

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If validaCampos() = False Then Exit Sub

        logarSistema()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        intPergunta = MsgBox("Têm certeza que deseja sair do sistemal.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Sistema Login")

        If intPergunta <> vbYes Then Exit Sub
        End

    End Sub

    Public Sub logarSistema()

        Dim dr As OleDbDataReader = Nothing

        Using con As OleDbConnection = getConnection()
            Try
                con.Open()

                Dim sql As String = "select * from usuarios where login=? and senha=?"
                Dim cmd As OleDbCommand = New OleDbCommand(sql, con)

                cmd.Parameters.Add(New OleDbParameter("@login", txtLogin.Text))
                cmd.Parameters.Add(New OleDbParameter("@senha", txtSenha.Text))

                dr = cmd.ExecuteReader

                If dr.HasRows Then
                    dr.Read()

                    strLogin = dr.Item("login")
                    strPerfil = dr.Item("perfil")

                    Me.Hide()
                    frmMdiPrincipal.Show()


                Else
                    MsgBox("Erro ao tentar login, tente novamente", MsgBoxStyle.Information, "Sistema Login")

                End If

            Catch ex As Exception

            Finally
                con.Close()

            End Try
        End Using

    End Sub

    Public Function validaCampos() As Boolean

        If txtLogin.Text = "" Or txtSenha.Text = "" Then
            MsgBox("Preencher o campo login e senha..", MsgBoxStyle.Information, "Sistema Login")

            Return False
        End If

        Return True
    End Function

End Class
