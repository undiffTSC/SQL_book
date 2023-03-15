Public Class Form20
    Private Sub Form20_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: 这行代码将数据加载到表“图书推荐系统DataSet.Administrator”中。您可以根据需要移动或删除它。
        Me.AdministratorTableAdapter.Fill(Me.图书推荐系统DataSet.Administrator)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.AdministratorBindingSource.AddNew()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.AdministratorBindingSource.RemoveCurrent()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.AdministratorBindingSource.EndEdit()
        'Me.T_BookOrderTableAdapter.Update(Me.Book1DataSet.T_BookOrder)

        Try
            Me.AdministratorTableAdapter.Update(Me.图书推荐系统DataSet.Administrator)
            MsgBox("管理员表更新成功", vbOKOnly, "提示")

        Catch ex As Exception
            MsgBox("管理员表更新失败", vbOKOnly, "提示")
        End Try
    End Sub


End Class