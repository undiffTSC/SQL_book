Imports System.Data
Imports System.Data.SqlClient
Public Class Form17
    Dim A1 As SqlConnection
    Dim C1 As SqlCommand  '昵称
    Dim C2 As SqlCommand  '插入数据
    Dim C3 As SqlCommand  '查询最大的书评码，以便后面生成书评时，给定一个系生成的书评码
    Dim D3 As Double      '得到的最大书评码
    Dim C4 As String

    Dim C5 As SqlCommand  '
    Dim D5 As Int16
    Public Sub Form17_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label4.Text = Form12.H
        A1 = New SqlConnection()
        A1.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=True"
        A1.Open()
        C1 = New SqlCommand("select UserName
                             from Users 
                             where UserNumber = '" & Form12.ID & " '")
        C1.Connection = A1
        Label2.Text = C1.ExecuteScalar

        C3 = New SqlCommand("select max(CommentNo)
                             from Comment ")
        C3.Connection = A1

        If IsDBNull(C3.ExecuteScalar) Then
            D3 = 0
        Else
            D3 = C3.ExecuteScalar
        End If


        C5 = New SqlCommand("select UserLevel
                             from Users
                             where UserNumber = '" & Form12.ID & " '")
        C5.Connection = A1
        D5 = C5.ExecuteScalar
        A1.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If D5 >= 2 Then
            D3 = D3 + 1
            C4 = TextBox1.Text '输入插入编写评论
            '  Dim i
            A1 = New SqlConnection()
            A1.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=True"
            A1.Open()
            C2 = New SqlCommand("Insert Into Comment (CommentNo,[CommentThumb-up],Comments,BookNo,UserNumber)
                             Values(" & D3 & ",'0','" & C4 & "','" & Trim(Form12.TextBox3.Text) & "','" & Form12.ID & "')")
            C2.Connection = A1
            C2.ExecuteNonQuery()
            '   i = C2.ExecuteNonQuery
            '   If i = 1 Then
            '  MsgBox("发表成功")
            'Else
            '  MsgBox("发表失败")
            'End If
            A1.Close()
            Me.Close()
        Else
            MsgBox("用户等级达到2后才能发表评论")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles MyBase.Load

        If D5 < 2 Then
            TextBox1.Text = "用户需要达到二级才能评论"
            TextBox1.Enabled = False
        Else TextBox1.Enabled = True
        End If
    End Sub

    Private Sub PictureBox1_load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = Image.FromFile("D:\vsproduce\qimo4\Source\Userprotarit\" & Trim(Form12.Head()) & ".jpg")
    End Sub

End Class