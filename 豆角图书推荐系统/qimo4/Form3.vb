Imports System.Data
Imports System.Data.SqlClient
Public Class Form3
    Dim A1 As SqlConnection
    Dim E1 As Double         '书架码
    Dim F1 As SqlCommand
    Dim F2 As SqlCommand
    Dim F3 As SqlCommand
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        A1 = New SqlConnection()
        A1.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=True"
        A1.Open()
        Dim dsDA As New SqlDataAdapter()
        dsDA.SelectCommand = New SqlCommand()
        dsDA.SelectCommand.Connection = A1
        dsDA.SelectCommand.CommandText = ("select BookShelfNo as 书单码 ,BookShelfName as 我的书单
                                           from BookShelf
                                           where UserNumber = '" & Form12.ID & "' or UserNumber ='999999'")

        Dim dsSt As New DataSet
        dsDA.Fill(dsSt, "1")
        DataGridView1.DataSource = dsSt
        DataGridView1.DataMember = "1"

        F1 = New SqlCommand("select max(BookShelfNo)
                             from  BookShelf
                             where BookShelfNo <> '...'")
        F1.Connection = A1
        E1 = F1.ExecuteScalar   '生成书单码
        E1 = E1 + 1
        A1.Close()
    End Sub
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Dim current_row As Integer = DataGridView1.CurrentRow.Index
        Debug.Print(current_row.ToString)
        TextBox2.Text = DataGridView1(0, current_row).Value.ToString
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = "..." Then
            GroupBox1.Visible = True
            TextBox1.Visible = True
            Button2.Visible = True
            DataGridView1.Visible = False
            Button1.Visible = False
        Else
            A1 = New SqlConnection()
            A1.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=True"
            A1.Open()

            F2 = New SqlCommand("Insert Into BookShelfContent (BookShelfNo,BookNo)
                                  Values('" & TextBox2.Text & "','" & Form13.Label13.Text & "')")
            F2.Connection = A1
            Try
                F2.ExecuteNonQuery()
                MsgBox("收藏成功"， vbOKOnly, "提示")
            Catch
                MsgBox("您的" & TextBox2.Text & "号书单已收藏此书"， vbOKOnly, "提示")
            End Try
            Me.Close()
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        A1 = New SqlConnection()
        A1.ConnectionString = "server=localhost;database=图书推荐系统;Integrated Security=True"
        A1.Open()

        F3 = New SqlCommand("Insert Into BookShelf (BookShelfNo,BookShelfName,UserNumber)
                             Values('" & E1 & "','" & TextBox1.Text & "','" & Form12.ID & "')")

        F3.Connection = A1
        F3.ExecuteNonQuery()

        F2 = New SqlCommand("Insert Into BookShelfContent (BookShelfNo,BookNo)
                                  Values('" & E1 & "','" & Trim(Form12.NU) & "')")
        F2.Connection = A1
        F2.ExecuteNonQuery()
        MsgBox("收藏成功"， vbOKOnly, "提示")
        Me.Close()
    End Sub


End Class