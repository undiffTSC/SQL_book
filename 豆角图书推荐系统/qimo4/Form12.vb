Imports System.Data
Imports System.Data.SqlClient
Public Class Form12
    Dim sqlcn As SqlConnection
    Dim sqlcmd As SqlCommand
    Dim He
    Public Function ID() As String    '之后用于与第一个登陆界面链接
        ID = Form1.TextBox1.Text
    End Function

    Public Function H() '选中的图书
        H = TextBox2.Text
    End Function
    Public Function NU()  '书号
        NU = TextBox3.Text

    End Function

    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        sqlcn = New SqlConnection()
        sqlcn.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=SSPI"
        sqlcn.Open()
        Dim dsDA As New SqlDataAdapter()
        dsDA.SelectCommand = New SqlCommand()
        dsDA.SelectCommand.Connection = sqlcn
        dsDA.SelectCommand.CommandText = ("Select BookName as 书名,BookNo As 图书编号,Price As 价格,Auther As 作者,Publisher As 出版社,Variety As 种类,WordNumber As 字数,PublishYear As 出版年,[BookThumb-up] As 点赞数
                                          from Book
                                          order by [BookThumb-up] desc ")
        sqlcmd = New SqlCommand("Select HeadPortrait                         
                                 from Users
                                 where UserNumber='" + ID() + "'")     '获取用户头像参数
        sqlcmd.Connection = sqlcn
        TextBox4.Text = sqlcmd.ExecuteScalar
        Dim dsSt As New DataSet
        dsDA.Fill(dsSt, "121")
        DataGridView1.DataSource = dsSt
        DataGridView1.DataMember = "121"
        sqlcn.Close()
    End Sub
    Public Function Head() As String    '用户头像代号
        Head = TextBox4.Text
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sqlcn = New SqlConnection()
        sqlcn.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=SSPI"
        sqlcn.Open()
        Dim 搜索
        搜索 = TextBox1.Text
        Dim dsDA As New SqlDataAdapter()
        dsDA.SelectCommand = New SqlCommand()
        dsDA.SelectCommand.Connection = sqlcn
        dsDA.SelectCommand.CommandText = ("Select BookName As 书名,BookNo As 图书编号,Price As 价格,Auther As 作者,Publisher As 出版社,Variety As 种类,WordNumber As 字数,PublishYear As 出版年,[BookThumb-up] As 点赞数
                                          from Book  
                                          where BookName like '%" & 搜索 & "%'  or  BookNo = '" & 搜索 & "' or Auther = '" & 搜索 & "'")
        Dim dsSt As New DataSet
        dsDA.Fill(dsSt, "1")
        DataGridView1.DataSource = dsSt
        DataGridView1.DataMember = "1"
        sqlcn.Close()
    End Sub
    Public Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Form13.Show()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Form16.Show()
    End Sub
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Dim current_row As Integer = DataGridView1.CurrentRow.Index
        Debug.Print(current_row.ToString)
        TextBox2.Text = DataGridView1(0, current_row).Value.ToString   '书名
        TextBox3.Text = DataGridView1(1, current_row).Value.ToString  '书号
    End Sub

    Private Sub PictureBox2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PictureBox2.Image = Image.FromFile("D:\vsproduce\qimo4\Source\Userprotarit\" & Trim(TextBox4.Text) & ".jpg")
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)
        Form16.Show()

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        sqlcn = New SqlConnection()
        sqlcn.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=SSPI"
        sqlcn.Open()

        Dim G1 As New SqlDataAdapter()
        G1.SelectCommand = New SqlCommand()
        G1.SelectCommand.Connection = sqlcn
        G1.SelectCommand.CommandText = (" exec form12sousuo @TextBox like  '%" & TextBox1.Text & "%' ")


        Dim dsSt As New DataSet
        G1.Fill(dsSt, "122")
        DataGridView1.DataSource = dsSt
        DataGridView1.DataMember = "122"
        sqlcn.Close()

    End Sub

    Private Sub PictureBox2_Click_1(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Form16.Show()
    End Sub


End Class
