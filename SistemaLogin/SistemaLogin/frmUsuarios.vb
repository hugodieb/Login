Imports System.Data.OleDb

Public Class frmUsuarios

    Private Sub frmUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        limpaCampos()

    End Sub

    Private Sub limpaCampos()
        txtCodigo.Text = "Novo"
        txtLogin.Text = ""
        txtSenha.Text = ""
        cmbPerfil.SelectedIndex = 0
        txtLogin.Focus()
    End Sub
    Private Function validaCampos() As Boolean

        If txtLogin.Text = "" Then
            MsgBox("Preencha o campo Login.", MsgBoxStyle.Information, "Sistema Login")
            txtLogin.Focus()
            Return False
            Exit Function
        End If

        If txtSenha.Text = "" Then
            MsgBox("Preencha o campo Senha.", MsgBoxStyle.Information, "Sistema Login")
            txtSenha.Focus()
            Return False
            Exit Function
        End If

        Return True
    End Function

    Private Sub Salva()

        Using con As OleDbConnection = getConnection()
            Try
                con.Open()
                Dim sql As String = "INSERT INTO usuarios (login,senha,perfil) VALUES (?,?,?)"
                Dim cmd As OleDbCommand = New OleDbCommand(sql, con)

                cmd.Parameters.Add(New OleDb.OleDbParameter("@login", txtLogin.Text))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@senha", txtSenha.Text))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@perfil", cmbPerfil.Text))

                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox("Ocorreu um erro ao tentar cadastrar um Novo Usuário." & ex.Message, MsgBoxStyle.Information)
            Finally
                con.Close()
            End Try

        End Using
    End Sub

    Private Sub Edita()

        Using con As OleDbConnection = getConnection()
            Try
                con.Open()
                Dim sql As String = "update usuarios set login=?,senha=?,perfil=? where codigo=" & txtCodigo.Text
                'Dim sql As String = "update usuario set login=?, senha=?, perfil=? where codigo=?" dessa forma certo tbm.
                Dim cmd As OleDbCommand = New OleDbCommand(sql, con)

                cmd.Parameters.Add(New OleDb.OleDbParameter("@login", txtLogin.Text))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@senha", txtSenha.Text))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@perfil", cmbPerfil.Text))
                'cmd.Parameters.Add(New OleDbParameter("@codigo", txtCodigo.Text))

                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox("Ocorreu um erro ao tentar atualizar um Novo Usuário. Erro:" & ex.Message, MsgBoxStyle.Information)
            Finally
                con.Close()
            End Try

        End Using
    End Sub

    Private Sub excluir()

        Using con As OleDbConnection = getConnection()
            Try
                con.Open()
                Dim sql As String = "delete from usuarios where codigo=" & txtCodigo.Text
                Dim cmd As OleDbCommand = New OleDbCommand(sql, con)
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox("Ocorreu um erro ao tentar deletar Usuário. Erro:" & ex.Message, MsgBoxStyle.Information)
            Finally
                con.Close()
            End Try

        End Using
    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        limpaCampos()
    End Sub

    Private Sub btnEditaSalva_Click(sender As Object, e As EventArgs) Handles btnEditaSalva.Click

        If validaCampos() = False Then Exit Sub

        If txtCodigo.Text = "Novo" Then
            Salva()
            limpaCampos()

            MsgBox("Usuario salvo com sucesso", MsgBoxStyle.Information, "Sistema Login")
        Else
            Edita()
            limpaCampos()
            MsgBox("Usuario alterado com sucesso", MsgBoxStyle.Information, "Sistema Login")
        End If

    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click

        If txtCodigo.Text = "Novo" Then
            MsgBox("Informe o usuário para ser exluído.", MsgBoxStyle.Information, "Sistema Login")
            Exit Sub
        End If

        If txtLogin.Text = "admin" Then
            MsgBox("O usuário Admin não pode ser excluído.", MsgBoxStyle.Information, "Sistema Login")
            Exit Sub
        End If
        excluir()
        limpaCampos()
        MsgBox("Usuario excluido com sucesso", MsgBoxStyle.Information, "Sistema Login")

        Exit Sub
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        limpaCampos()
    End Sub

    Private Sub leDados()
        Dim dr As OleDbDataReader = Nothing

        Using con As OleDbConnection = getConnection()
            Try
                con.Open()
                Dim sql As String = "select * from usuarios where codigo=" & txtCodigo.Text
                Dim cmd As OleDbCommand = New OleDbCommand(sql, con)

                dr = cmd.ExecuteReader

                If dr.HasRows Then
                    dr.Read()
                    txtLogin.Text = dr.Item("login")
                    txtSenha.Text = dr.Item("senha")
                    cmbPerfil.Text = dr.Item("perfil")

                Else
                    MsgBox("Informe corretamente o codigo do usuario.", MsgBoxStyle.Information)
                End If
            Catch ex As Exception
                MsgBox("Ocorreu um erro ao tentar listar Usuário. Erro:" & ex.Message, MsgBoxStyle.Information)
            Finally
                con.Close()
            End Try

        End Using
    End Sub

    Private Sub btnListaUsuario_Click(sender As Object, e As EventArgs) Handles btnListaUsuario.Click
        frmListaUsuarios.ShowDialog()
        txtCodigo.Text = intCodigoUsuario

    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        If txtCodigo.Text <> "Novo" Then
            leDados()
        End If
    End Sub
End Class