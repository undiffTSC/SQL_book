Imports System.Data
Imports System.Data.SqlClient
Public Class Form14
    Dim sqlcn As SqlConnection
    Dim sqlcmd As SqlCommand

    Public Function M()
        M = TextBox1.Text
    End Function
    Public Function CNo() '评论者
        CNo = TextBox2.Text
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
        Form15.Show()
    End Sub
    Private Sub Label1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = Form12.H
    End Sub
    Private Sub Form14_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sqlcn = New SqlConnection()
        sqlcn.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=SSPI"
        sqlcn.Open()
        Dim dsDA As New SqlDataAdapter()
        dsDA.SelectCommand = New SqlCommand()
        dsDA.SelectCommand.Connection = sqlcn
        dsDA.SelectCommand.CommandText = ("Select CommentNo as 书评码,[CommentThumb-up] as 点赞数,Comments as 评论,Comment.BookNo as 图书编号,UserNumber as 用户ID
                                          from Comment join Book on Comment.BookNo=Book.BookNo where BookName = '" & Form12.H & " '")
        Dim dsSt As New DataSet
        dsDA.Fill(dsSt, "14")
        DataGridView1.DataSource = dsSt
        DataGridView1.DataMember = "14"
        sqlcn.Close()
    End Sub
    Public Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim current_row As Integer = DataGridView1.CurrentRow.Index
        Debug.Print(current_row.ToString)
        TextBox2.Text = DataGridView1(4, current_row).Value.ToString

        Form15.Show()

    End Sub
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Dim current_row As Integer = DataGridView1.CurrentRow.Index
        Debug.Print(current_row.ToString)
        TextBox1.Text = DataGridView1(0, current_row).Value.ToString
    End Sub

    Private Sub PictureBox2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PictureBox2.Image = Image.FromFile("D:\vsproduce\qimo4\Source\Userprotarit\" & Trim(Form12.Head()) & ".jpg")
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Form16.Show()

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Form17.Show()
    End Sub
    Private Sub ContextMenuStrip1_Load(sender As Object, e As EventArgs) Handles ContextMenuStrip1.Click
        sqlcn = New SqlConnection()
        sqlcn.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=SSPI"
        sqlcn.Open()
        Dim dsDA As New SqlDataAdapter()
        dsDA.SelectCommand = New SqlCommand()
        dsDA.SelectCommand.Connection = sqlcn
        dsDA.SelectCommand.CommandText = ("Select CommentNo as 书评码, [CommentThumb-up] as 点赞数,Comments as 评论,Comment.BookNo as 图书编号,UserNumber as 用户ID
                                          from Comment join Book on Comment.BookNo=Book.BookNo where BookName = '" & Form12.H & " '")
        Dim dsSt2 As New DataSet
        dsDA.Fill(dsSt2, "142")
        DataGridView1.DataSource = dsSt2
        DataGridView1.DataMember = "142"
        sqlcn.Close()
    End Sub
End Class