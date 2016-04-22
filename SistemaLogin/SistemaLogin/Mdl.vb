Imports System.Data.OleDb

Module Mdl

    Public strLogin As String
    Public strPerfil As String
    Public intPergunta As Integer
    Public intCodigoUsuario As Integer

    Public Function getConnection() As OleDbConnection
        'Dim strconection As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\Mara-pc\d\projetos_vb\SistemaLogin\sistemaLogin.accdb"
        Dim strconection As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\projetos_vb\SistemaLogin\sistemaLogin.accdb"

        Return New OleDbConnection(strconection)
    End Function

End Module
