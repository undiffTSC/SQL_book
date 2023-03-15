Imports System.Data
Imports System.Data.SqlClient
Public Class Form19

    Dim A1 As SqlConnection

    Dim C2 As SqlCommand   '昵称
    Dim C3 As SqlCommand   '性别
    Dim C4 As SqlCommand   '地址
    Dim C7 As SqlCommand   '联系方式
    Dim C5 As SqlCommand   '修改昵称,性别
    Dim C6 As SqlCommand   '密码

    Private Sub Form19_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label6.Text = Trim(Form18.IDA)

        A1 = New SqlConnection()
        A1.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=True"
        A1.Open()

        C2 = New SqlCommand("select AdmName
                            from Administrator 
                             where AdmNo = '" & Trim(Form18.IDA) & " '")
        C2.Connection = A1
        Label7.Text = C2.ExecuteScalar

        C3 = New SqlCommand("select AdmSex
                            from Administrator
                             where AdmNo = '" & Trim(Form18.IDA) & " '")
        C3.Connection = A1
        Label12.Text = C3.ExecuteScalar

        C4 = New SqlCommand("select AdmAddress
                            from Administrator
                             where AdmNo = '" & Trim(Form18.IDA) & " '")
        C4.Connection = A1
        Label9.Text = C4.ExecuteScalar

        C6 = New SqlCommand("select Password
                            from Administrator
                            where AdmNo = '" & Trim(Form18.IDA) & " '")
        C6.Connection = A1
        Label8.Text = C6.ExecuteScalar


        C7 = New SqlCommand("select AdmTelephone
                            from Administrator
                            where AdmNo = '" & Trim(Form18.IDA) & " '")
        C7.Connection = A1
        Label10.Text = C7.ExecuteScalar

        A1.Close()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = Label8.Text
        TextBox2.Text = Label7.Text
        TextBox4.Text = Label9.Text
        TextBox5.Text = Label10.Text
        ComboBox1.Text = Label12.Text

        TextBox1.Visible = True
        TextBox2.Visible = True
        TextBox4.Visible = True
        TextBox5.Visible = True
        ComboBox1.Visible = True
        Button2.Visible = True
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        A1 = New SqlConnection()
        A1.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=True"
        A1.Open()
        C5 = New SqlCommand("Update Administrator
                              Set  AdmName = '" & Trim(TextBox2.Text) & "'
                              ,Password = '" & Trim(TextBox1.Text) & "'    
                              , AdmSex = '" & Trim(ComboBox1.Text) & "'   
                              , AdmAddress = '" & Trim(TextBox5.Text) & "'
                              Where  AdmNo ='" & Trim(Form18.IDA) & " '")
        C5.Connection = A1
        Try
            C5.ExecuteNonQuery()
            MsgBox("信息修改成功", vbOKOnly, "提示")
        Catch
            MsgBox("请按正确格式修改", vbOKOnly, "提示"）
        End Try
        A1.Close()
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox4.Visible = False
        TextBox5.Visible = False
        ComboBox1.Visible = False
        Button2.Visible = False
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form18.Close()

        Form20.Close()
        Me.Close()
        Form1.Show()
    End Sub


End Class