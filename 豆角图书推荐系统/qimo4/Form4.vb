Imports System.Data
Imports System.Data.SqlClient
Public Class Form4

    Dim sqlcn As SqlConnection
    Dim sqlcnd As SqlCommand
    Dim sqlcnd2 As SqlCommand
    Dim account
    Dim names
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a
        account = TextBox1.Text
        names = TextBox2.Text
        sqlcn = New SqlConnection()
        sqlcn.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=True"
        sqlcn.Open()
        Try

            sqlcnd = New SqlCommand("select count(*)
                                     from Users
                                     where UserNumber = " & account & " and UserName = '" & names & "'")
            '将检索表赋给sqlcnd
            sqlcnd.Connection = sqlcn
            a = sqlcnd.ExecuteScalar  '将sqcnd中第一行一列的值赋给a，即有几条匹配记录
            If a <> 0 Then
                sqlcnd2 = New SqlCommand("select Password
                                     from Users
                                     where UserNumber = " & account)
                sqlcnd2.Connection = sqlcn
                Dim Password
                Password = sqlcnd2.ExecuteScalar

                MsgBox("您的密码为：" + Password, vbOKOnly, "提示")
            ElseIf a = 0 Then
                MsgBox("账号和姓名不匹配", vbOKOnly, "提示")
            End If


            sqlcn.Close()
        Catch
            MsgBox("请输入正确格式的账号姓名", vbOKOnly, "提示")
        End Try
    End Sub


End Class