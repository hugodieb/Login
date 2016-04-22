Public Class frmMdiPrincipal

    Private Sub frmMdiPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        intPergunta = MsgBox("Têm certeza que deseja sair do sistema.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Sistema Login")

        If intPergunta <> vbYes Then Exit Sub
        End
    End Sub

    Private Sub frmMdiPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblLogin.Text = strLogin
        lblPerfil.Text = strPerfil
    End Sub

    Private Sub NewToolStripButton_Click(sender As Object, e As EventArgs) Handles NewToolStripButton.Click
        'admin
        If strPerfil.Equals("Operador") Then
            MsgBox("Usuário sem permissão de acesso.", MsgBoxStyle.Information, "Sistema Login")

        Else
            frmUsuarios.Show()

        End If
    End Sub

    Private Sub OpenToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click
        'admin
        If strPerfil.Equals("Operador") Then
            MsgBox("Usuário sem permissão de acesso.", MsgBoxStyle.Information, "Sistema Login")

        Else
            Explorer1.Show()

        End If

    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        'admin
        'operador
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        'admin
        'operador
    End Sub
End Class