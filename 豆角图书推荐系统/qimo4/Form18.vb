Imports System.Data.SqlClient
Imports System.Data
Imports System.Text.RegularExpressions
Imports System.Reflection

Public Class Form18
    Public Function IDA() As String    '之后用于与第一个登陆界面链接
        IDA = Form1.TextBox1.Text
    End Function



    Dim sqll, gjci As String
    Dim sqlcn As New SqlConnection(" server=localhost;database=图书推荐系统;Integrated Security=SSPI") '这是连接数据库的bai字符串，Data Source 是数据du源，Initial Catalog是数据zhi库的名称，User ID是登录数据的dao用户名，Pwd是登录数据库的密码。
    '正常用一个点就可以代表本地数据库了，但是如果你在运行的时候还是跳出错误的话，可以将一个点改成".\SQLEXPRESS"


    Dim myadapter As SqlDataAdapter
    Dim mydataset As New DataSet()
    Public DT As DataTable

    Private Sub Form18_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadioButton1.Select()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '拆分关键词，转换为可编程的程序语言格式
        Dim max As Integer
        gjci = Trim(TextBox1.Text)
        Dim m = gjci.Split()
        If gjci = "" Then   '判断输入框非空
        Else

            sqll = ""
            max = UBound(m)

            For ii = 0 To max
                If m(ii) = "" Then
                ElseIf ii = max Then
                    sqll = sqll & "('%" & m(ii) & "%')"
                Else sqll = sqll & "('%" & m(ii) & "%'),"
                End If
            Next
            'TextBox1.Text = sqll  转换测试

            'Replace(TextBox1.Text, " ", "%'),('%")
            ' Regex.Replace(Regex.Replace(TextBox1.Text, "[^\u4E00-\u9FA5]", " ").Trim(), "[\s]{2,} ", " ")

            'Dim myconn As SqlConnection()
            ' myconn = New SqlConnection()  '法二
            sqlcn.Open()

            Dim sql As String = "Select *
               FROM Book as aa ,(values" & sqll & ") as t2(p)  
               WHERE  aa.BookName LIKE t2.p 
            or aa.BookNo LIKE t2.p 
            or aa.Auther LIKE t2.p 
            or aa.Publisher LIKE t2.p 
            or aa.BriefIntroduction LIKE t2.p  "
            'BookNo as 书籍编码,BookName as 书名,Auther as 作者,Publisher as 出版社 ,BriefIntroduction as 简介

            Dim sq2 As String = " Select aa .*, b.BookName,c.UserName
               FROM (values" & sqll & ") as t2(p),Comment as aa
             
               join Book as b on aa .BookNo =b.BookNo
               join dbo.""Users""as c on  aa.UserNumber=c.UserNumber 
                WHERE  aa .BookNo =b.BookNo and 
               aa.CommentNo LIKE t2.p 
            or aa.Comments LIKE t2.p 
            or aa.BookNo LIKE t2.p 
            or aa.UserNumber LIKE t2.p  
            or b.BookName LIKE t2.p
            or c.UserName LIKE t2.p
            or aa.UserNumber LIKE t2.p "

            Dim sq3 As String = "Select *
               FROM dbo.""Users"" as aa ,(values" & sqll & ") as t2(p) 
                WHERE  aa.UserName LIKE t2.p 
                       or aa.UserNumber LIKE t2.p 
                       or aa.UserLevel LIKE t2.p  "
            '清空输出表
            Try
                mydataset.Clear()
            Catch
            End Try
            '搜索并填充输出表
            If RadioButton1.Checked Then
                myadapter = New SqlDataAdapter(sql, sqlcn)
                myadapter.Fill(mydataset, "T1")
                DataGridView1.DataSource = mydataset.Tables("T1")

                DT = mydataset.Tables("T1")

            ElseIf RadioButton2.Checked Then
                myadapter = New SqlDataAdapter(sq2, sqlcn)
                myadapter.Fill(mydataset, "T2")
                DataGridView1.DataSource = mydataset.Tables("T2")
                ' Dim comno = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value.ToString() '获取焦点触发行的第一个值
                'DT = mydataset.Tables("T22")

            ElseIf RadioButton3.Checked Then
                myadapter = New SqlDataAdapter(sq3, sqlcn)
                myadapter.Fill(mydataset, "T3")
                DataGridView1.DataSource = mydataset.Tables("T3")
                DT = mydataset.Tables("T3")
            End If
            sqlcn.Close()
        End If

    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If RadioButton2.Checked Then
            Try
                sqlcn.Open()
                Dim strcolumn = DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).HeaderText '获取列标题
                Dim strrow = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value.ToString() '获取焦点触发行的第一个值
                Dim value = DataGridView1.CurrentCell.Value.ToString() '获取当前点击的活动单元格的值

                Dim strcomm = "update Comment  set [" & strcolumn & "] ='" & value & "' where CommentNo = " & strrow
                Dim mycmd = New SqlCommand(strcomm, sqlcn)
                mycmd.ExecuteScalar()
            Catch ex As Exception
                '  MsgBox(ex.Message)
                MsgBox("更新失败"， vbOKOnly, "提示")
            End Try
            sqlcn.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sqlcn.Open()

        Dim builder = New SqlCommandBuilder(myadapter)

        Try
            myadapter.Update(DT)
            MsgBox("更新成功"， vbOKOnly, "提示")
        Catch ex As Exception  'When isRelease '当isRelease为True时处理异常，否则把异常抛出
            MsgBox("更新失败"， vbOKOnly, "提示")
        End Try

        sqlcn.Close()

    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click


        Try
            If RadioButton2.Checked Then
                sqlcn.Open()
                Dim strrow1 = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value.ToString() '获取焦点触发行的第一个值
                Dim strcomm1 = "DELETE FROM [Comment] WHERE CommentNo = " & strrow1
                Dim mycmd = New SqlCommand(strcomm1, sqlcn)
                mycmd.ExecuteScalar()
                sqlcn.Close()
                Button1_Click(Nothing, Nothing)

            Else
                DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index)
                '数据库中进行删除
                Dim SCB = New SqlCommandBuilder(myadapter)
                myadapter.Update(DT)
                MsgBox("删除成功")

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim fo3 As New Form20
        fo3.Show()
    End Sub

    Private Sub Label3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = IDA()
    End Sub

    Private Sub Label2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sqlcn.Open()
        Dim C2 As SqlCommand
        C2 = New SqlCommand("select AdmName
                                 from Administrator 
                                 where AdmNo = '" & Trim(IDA) & " '")
        C2.Connection = sqlcn
        Label4.Text = C2.ExecuteScalar
        sqlcn.Close()
    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fo2 As New Form19
        fo2.Show()
    End Sub
End Class