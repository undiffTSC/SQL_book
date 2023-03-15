Imports System.Data
Imports System.Data.SqlClient
Public Class Form13
    Dim A1 As SqlConnection
    Dim B1 As SqlCommand   '书的编码
    Dim B2 As SqlCommand   '出版社
    Dim B3 As SqlCommand   '书的种类
    Dim B4 As SqlCommand   '书的作者
    Dim B5 As SqlCommand   '书的定价
    Dim B6 As SqlCommand   '书的出版年
    Dim B7 As SqlCommand   '书的字数
    Dim B8 As SqlCommand   '书的点赞数
    Dim B9 As SqlCommand   '书的简介
    Dim B10 As SqlCommand   '执行点赞加1

    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: 这行代码将数据加载到表“图书推荐系统DataSet1.Book”中。您可以根据需要移动或删除它。
        SetStyle(ControlStyles.DoubleBuffer, True)
        UpdateStyles()
        Label11.Text = Form12.H
        A1 = New SqlConnection()
        A1.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=True"
        A1.Open()

        B1 = New SqlCommand("select BookNo
                             from Book 
                             where BookName = '" & Form12.H & " '")
        B1.Connection = A1
        Label13.Text = B1.ExecuteScalar

        B2 = New SqlCommand("select Publisher
                             from Book 
                             where BookName = '" & Form12.H & " '")
        B2.Connection = A1
        Label14.Text = B2.ExecuteScalar

        B3 = New SqlCommand("select Variety
                             from Book 
                             where BookName = '" & Form12.H & " '")
        B3.Connection = A1
        Label15.Text = B3.ExecuteScalar

        B4 = New SqlCommand("select Auther
                             from Book 
                             where BookName = '" & Form12.H & " '")
        B4.Connection = A1
        Label17.Text = B4.ExecuteScalar

        B5 = New SqlCommand("select Price
                             from Book 
                             where BookName = '" & Form12.H & " '")
        B5.Connection = A1
        Label18.Text = B5.ExecuteScalar

        B6 = New SqlCommand("select PublishYear
                             from Book 
                             where BookName = '" & Form12.H & " '")
        B6.Connection = A1
        Label19.Text = B6.ExecuteScalar

        B7 = New SqlCommand("select WordNumber
                             from Book 
                             where BookName = '" & Form12.H & " '")
        B7.Connection = A1
        Label20.Text = B7.ExecuteScalar

        B8 = New SqlCommand("select [BookThumb-up]
                             from Book 
                             where BookName = '" & Form12.H & " '")
        B8.Connection = A1
        Label12.Text = B8.ExecuteScalar

        B9 = New SqlCommand("select BriefIntroduction
                             from Book 
                             where BookName = '" & Form12.H & " '")
        B9.Connection = A1
        TextBox10.Text = B9.ExecuteScalar
        A1.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        A1 = New SqlConnection()
        A1.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=True"
        A1.Open()
        B10 = New SqlCommand("Update Book
                              Set  [BookThumb-up] = [BookThumb-up] + 1                    
                              Where BookName =  '" & Form12.H & " '")
        B10.Connection = A1
        B10.ExecuteNonQuery()
        Label12.Text = Int(Label12.Text) + 1
        Button1.Enabled = False
        Button1.Visible = False
        Button2.Visible = True
        A1.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("一名用户只能点赞一次", vbOKOnly, "提示")
    End Sub
    Private Sub PictureBox1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = Image.FromFile("D:\vsproduce\qimo4\Source\BookPic\" & Trim(Form12.H) & ".jpg")
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form14.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Form2.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MsgBox("您已收藏", vbOKOnly, "提示")


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form3.Show()
        Button5.Enabled = False
        Button5.Visible = False
        Button6.Visible = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
    End Sub
End Class