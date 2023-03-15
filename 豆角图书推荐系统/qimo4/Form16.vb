Imports System.Data
Imports System.Data.SqlClient
Public Class Form16

    Dim A1 As SqlConnection
    Dim dsSt As New DataSet '书架
    Dim C2 As SqlCommand   '昵称
    Dim C3 As SqlCommand   '性别
    Dim C4 As SqlCommand   '权限等级
    Dim C5 As SqlCommand   '修改昵称,性别
    Dim C6 As SqlCommand   '密码


    Public Sub Form16_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        A1 = New SqlConnection()
        A1.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=True"
        A1.Open()

        Label5.Text = Form12.ID
        C2 = New SqlCommand("select UserName
                            from Users 
                             where UserNumber = '" & Trim(Form12.ID) & " '")
        C2.Connection = A1
        Label6.Text = C2.ExecuteScalar

        C3 = New SqlCommand("select Sex
                            from Users
                             where UserNumber = '" & Trim(Form12.ID) & " '")
        C3.Connection = A1
        Label7.Text = C3.ExecuteScalar

        C4 = New SqlCommand("select UserLevel
                            from Users 
                            where UserNumber = '" & Trim(Form12.ID) & " '")
        C4.Connection = A1
        Label8.Text = C4.ExecuteScalar

        C6 = New SqlCommand("select Password
                            from Users 
                            where UserNumber = '" & Trim(Form12.ID) & " '")
        C6.Connection = A1
        Label9.Text = C6.ExecuteScalar

        Dim dsDA As New SqlDataAdapter()
        dsDA.SelectCommand = New SqlCommand()
        dsDA.SelectCommand.Connection = A1
        dsDA.SelectCommand.CommandText = ("select BookShelfNo as 书单码 ,BookShelfName as 我的书单
                                           from BookShelf
                                           where UserNumber = '" & Form12.ID & "' ")


        dsDA.Fill(dsSt, "161")
        DataGridView1.DataSource = dsSt
        DataGridView1.DataMember = "161"
        A1.Close()
        TextBox1.Text = Form12.TextBox4.Text
    End Sub
    Private Sub 刷新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 刷新ToolStripMenuItem.Click
        Dim dsDA As New SqlDataAdapter()
        dsDA.SelectCommand = New SqlCommand()
        dsDA.SelectCommand.Connection = A1
        dsDA.SelectCommand.CommandText = ("select BookShelfNo as 书单码 ,BookShelfName as 我的书单
                                           from BookShelf
                                           where UserNumber = '" & Form12.ID & "' ")


        dsDA.Fill(dsSt, "161")
        DataGridView1.DataSource = dsSt
        DataGridView1.DataMember = "161"
        A1.Close()
    End Sub

    Private Sub PictureBox1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PictureBox1.Image = Image.FromFile("D:\vsproduce\qimo4\Source\Userprotarit\" & Trim(Form12.Head()) & ".jpg")

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Text = Label6.Text
        TextBox3.Text = Label9.Text
        ComboBox1.Text = Label7.Text
        LinkLabel1.Visible = True
        TextBox2.Visible = True
        TextBox3.Visible = True
        ComboBox1.Visible = True
        Button2.Visible = True

    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        A1 = New SqlConnection()
        A1.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=True"
        A1.Open()
        C5 = New SqlCommand("Update Users
                              Set  UserName = '" & Trim(TextBox2.Text) & "'
                              ,Password = '" & Trim(TextBox3.Text) & "'    
                              , Sex = '" & Trim(ComboBox1.Text) & "'   
                              , HeadPortrait = '" & Trim(TextBox1.Text) & "'
                              Where UserNumber ='" & Trim(Form12.ID) & " '")
        C5.Connection = A1
        Try
            C5.ExecuteNonQuery()
            MsgBox("修改成功", vbOKOnly, "提示")
        Catch
            MsgBox("请按正确格式修改", vbOKOnly, "提示")
        End Try
        A1.Close()

        LinkLabel1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
        ComboBox1.Visible = False
        Button2.Visible = False
        Form12.TextBox4.Text = TextBox1.Text


        PictureBox1.Image = Image.FromFile("D:\vsproduce\qimo4\Source\Userprotarit\" & Trim(Form12.Head()) & ".jpg")
        Form12.PictureBox2.Image = Image.FromFile("D:\vsproduce\qimo4\Source\Userprotarit\" & Trim(Form12.Head()) & ".jpg")
        Form14.PictureBox2.Image = Image.FromFile("D:\vsproduce\qimo4\Source\Userprotarit\" & Trim(Form12.Head()) & ".jpg")
        Form15.PictureBox2.Image = Image.FromFile("D:\vsproduce\qimo4\Source\Userprotarit\" & Trim(Form12.Head()) & ".jpg")
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form6.Show()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Form12.Close()
        Form13.Close()
        Form14.Close()
        Form15.Close()
        Me.Close()
        Form1.Show()
    End Sub
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Dim current_row As Integer = DataGridView1.CurrentRow.Index
        Debug.Print(current_row.ToString)
        TextBox4.Text = DataGridView1(0, current_row).Value.ToString   '书单码

    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        A1 = New SqlConnection()
        A1.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=True"
        A1.Open()
        Dim dsDA2 As New SqlDataAdapter()
        dsDA2.SelectCommand = New SqlCommand()
        dsDA2.SelectCommand.Connection = A1
        dsDA2.SelectCommand.CommandText = ("select BookName as 书名,BookShelfContent.BookNo as 图书编码
                             From BookshelfContent
	                         Join Book On BookShelfContent.BookNo = Book.BookNo
	                       
                             Where BookShelfNo = '" & TextBox4.Text & "'")         '查询书单内容

        Dim dsSt2 As New DataSet
        dsDA2.Fill(dsSt2, "162")
        DataGridView1.DataSource = dsSt2
        DataGridView1.DataMember = "162"
        A1.Close()
        Button3.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button3.Visible = False
        DataGridView1.DataSource = dsSt
        DataGridView1.DataMember = "161"
        Button3.Visible = False
    End Sub


End Class