Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackgroundImage = Image.FromFile("D:\vsproduce\qimo4\Source\BookPic\" & Trim(Form12.H) & ".jpg")
    End Sub
End Class