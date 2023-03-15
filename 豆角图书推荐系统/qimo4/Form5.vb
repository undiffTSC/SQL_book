Public Class Form5

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.UsersBindingSource.EndEdit()
        Me.UsersBindingSource.AddNew()
    End Sub

    Private Sub TextBox1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TextBox1.DataBindings.Add("text", UsersBindingSource, "UserNumber")
        Label9.Text = "账号不能为空"
    End Sub
    Private Sub TextBox2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.DataBindings.Add("text", UsersBindingSource, "Password")

        Label10.Text = "密码不能为空"
    End Sub
    Private Sub TextBox3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox3.DataBindings.Add("text", UsersBindingSource, "UserName")
        Label12.Text = "姓名不能为空"
    End Sub
    Private Sub TextBox5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox5.DataBindings.Add("text", UsersBindingSource, "Sex")
    End Sub
    Private Sub TextBox6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox6.DataBindings.Add("text", UsersBindingSource, "UserLevel")
    End Sub

    Private Sub TextBox7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox7.DataBindings.Add("text", UsersBindingSource, "HeadPortrait")
    End Sub
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If TextBox2.Text <> TextBox4.Text Then
            Label7.Text = "确认密码错误"
            Button1.Enabled = False
            Button2.Enabled = True
        Else
            Label7.Text = ""
            Button1.Enabled = True
            Button2.Enabled = False
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            Label9.Text = ""
            Label5.Text = "（请输入六位数字）"
            Button1.Enabled = True
            Button2.Enabled = False
        Else
            Button1.Enabled = False
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("请按规范注册", vbOKOnly, "提示")
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text <> "" Then
            Label10.Text = ""
            Label6.Text = "（请输入字母或数字）"
            Button1.Enabled = True
            Button2.Enabled = False
        Else
            Button1.Enabled = False
            Button2.Enabled = True
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text <> "" Then
            Label12.Text = ""
            Button1.Enabled = True
            Button2.Enabled = False
        Else
            Button1.Enabled = False
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        TextBox6.Text = "1"
        ' TextBox7.Text = Form6.Pic
        If RadioButton1.Checked = True Then
            TextBox5.Text = "男"

        ElseIf RadioButton2.Checked = True Then
            TextBox5.Text = "女"
        Else
            MsgBox("性别不能为空"， vbOKOnly, "提示")
        End If
        Try


            Me.UsersBindingSource.EndEdit()
            Me.UsersTableAdapter.Update(Me.图书推荐系统DataSet1.Users)

            MsgBox("注册成功", vbOKOnly, "提示")
            Me.Close()

        Catch
            MsgBox("账号以被注册", vbOKOnly, "提示")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form6.Show()

    End Sub


End Class
