Imports System.Data
Imports System.Data.SqlClient
Public Class Form15
    Dim A1 As SqlConnection
    Dim B1 As SqlCommand   '点赞数
    Dim B2 As SqlCommand   '评论
    Dim B3 As SqlCommand   '图书编号
    Dim B4 As SqlCommand   '评论者用户ID
    Dim B41 As SqlCommand   '评论者用户头像
    Dim CHP  '头像
    Dim B5 As SqlCommand   '书名
    Dim B6 As SqlCommand   '执行点赞加1
    Dim B7 As SqlCommand

    Private Sub Form15_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = Form14.M
        A1 = New SqlConnection()
        A1.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=True"
        A1.Open()

        B1 = New SqlCommand("select [CommentThumb-up]
                             from Comment 
                             where CommentNo = '" & Form14.M & " '")
        B1.Connection = A1
        Label7.Text = B1.ExecuteScalar

        B2 = New SqlCommand("select Comments
                             from Comment 
                             where CommentNo = '" & Form14.M & " '")
        B2.Connection = A1
        TextBox1.Text = B2.ExecuteScalar

        B3 = New SqlCommand("select BookNo
                             from Comment 
                             where CommentNo = '" & Form14.M & " '")
        B3.Connection = A1
        Label10.Text = B3.ExecuteScalar

        B4 = New SqlCommand("select UserName
                             from Comment join Book on Comment.BookNo=Book.BookNo join Users on Comment.UserNumber=Users.UserNumber
                             where CommentNo = '" & Form14.M & " '")
        B4.Connection = A1
        Label6.Text = B4.ExecuteScalar

        B41 = New SqlCommand("select HeadPortrait
                             from Comment join Book on Comment.BookNo=Book.BookNo join Users on Comment.UserNumber=Users.UserNumber
                             where CommentNo = '" & Form14.M & " '")
        B41.Connection = A1
        CHP = B41.ExecuteScalar
        B5 = New SqlCommand("select BookName
                             from Comment join Book on Comment.BookNo=Book.BookNo
                             where CommentNo = '" & Form14.M & " '")
        B5.Connection = A1
        Label4.Text = B5.ExecuteScalar
        A1.Close()
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        A1 = New SqlConnection()
        A1.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=True"
        A1.Open()
        B6 = New SqlCommand("update Comment
                             set   [CommentThumb-up] = [CommentThumb-up] + 1
                             where CommentNo = '" + Label2.Text + "'")
        Label7.Text = Label7.Text + 1
        B6.Connection = A1
        B6.ExecuteNonQuery()
        Button1.Enabled = False
        Button1.Visible = False
        Button2.Visible = True
        A1.Close()
    End Sub
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("一名用户只能点赞一次", vbOKOnly, "提示")
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form17.Show()
    End Sub
    Private Sub PictureBox2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PictureBox2.Image = Image.FromFile("D:\vsproduce\qimo4\Source\Userprotarit\" & Trim(Form12.Head()) & ".jpg")
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Form16.Show()
    End Sub

    Private Sub PictureBox1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = Image.FromFile("D:\vsproduce\qimo4\Source\Userprotarit\" & Trim(CHP) & ".jpg")
    End Sub


End Class