Imports System.Data
Imports System.Data.SqlClient


Public Class Form1
    Dim account
    Dim password
    Dim sqlcn As SqlConnection
    Dim sqlcnd As SqlCommand

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        account = TextBox1.Text
        password = TextBox2.Text

        sqlcn = New SqlConnection()
        sqlcn.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=True"
        sqlcn.Open()

        Dim a '及多少条用户信息
        Try
            If RadioButton1.Checked = True Then '用户登录
                sqlcnd = New SqlCommand("exec form1denglu  @UserNumber='" & account & " ',@Password='" & password & "'")

                '将检索表赋给sqlcnd
                sqlcnd.Connection = sqlcn
                a = sqlcnd.ExecuteScalar  '将sqcnd中第一行一列的值赋给a，即有几条匹配记录
                If a <> 0 Then
                    Form12.Show()
                ElseIf a = 0 Then
                    MsgBox("账号或密码错误", vbOKOnly, "提示")
                End If

            ElseIf RadioButton2.Checked = True Then '管理员登录
                sqlcnd = New SqlCommand("exec form1denglu2  @account='" & account & " ',@password='" & password & "'")
                sqlcnd.Connection = sqlcn
                a = sqlcnd.ExecuteScalar  '将sqcnd中第一行一列的值赋给a，即有几条匹配记录

                If a <> 0 Then
                    Form18.Show()
                ElseIf a = 0 Then
                    MsgBox("账号或密码错误", vbOKOnly, "提示")
                End If
            Else  '未选择
                MsgBox("请选择身份"， vbOKOnly, "提示")

            End If
            sqlcn.Close()
        Catch
            MsgBox("请输入正确格式的账号密码", vbOKOnly, "提示")
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form4.Show()  '找回密码

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Form5.Show()  '注册账户

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class