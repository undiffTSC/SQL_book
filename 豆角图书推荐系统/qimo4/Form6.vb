Public Class Form6
    Dim a As String  '所选的图片

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        PictureBox1.Image = Image.FromFile("D:\vsproduce\qimo4\Source\Userprotarit\1.jpg"）
        PictureBox2.Image = Image.FromFile("D:\vsproduce\qimo4\Source\Userprotarit\2.jpg"）
        PictureBox3.Image = Image.FromFile("D:\vsproduce\qimo4\Source\Userprotarit\3.jpg"）
        PictureBox4.Image = Image.FromFile("D:\vsproduce\qimo4\Source\Userprotarit\4.jpg"）
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Button2.Visible = True
        Button3.Visible = False
        Button4.Visible = False
        Button5.Visible = False
        a = 1
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        Button3.Visible = True
        Button2.Visible = False
        Button4.Visible = False
        Button5.Visible = False
        a = 2
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

        Button4.Visible = True
        Button2.Visible = False
        Button3.Visible = False
        Button5.Visible = False
        a = 3
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

        Button5.Visible = True
        Button3.Visible = False
        Button2.Visible = False
        Button4.Visible = False
        a = 4
    End Sub
    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        Form7.Show()
    End Sub
    Private Sub PictureBox2_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox2.DoubleClick
        Form8.Show()
    End Sub
    Private Sub PictureBox3_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox3.DoubleClick
        Form9.Show()
    End Sub
    Private Sub PictureBox4_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox4.DoubleClick
        Form10.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = a
        Form16.TextBox1.Text = a

        Form5.PictureBox2.Image = Image.FromFile("D:\vsproduce\qimo4\Source\Userprotarit\" + a + ".jpg")
        Form5.TextBox7.Text = a
        Me.Close()
    End Sub
End Class