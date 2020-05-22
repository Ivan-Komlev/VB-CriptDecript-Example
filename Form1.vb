Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim j As String
        j = MyCript("Shamarova", "123")
        TextBox1.Text = j
        Me.Text = MyDeCript(j, "123")
    End Sub
    Function MyCript(ByVal Content As String, ByVal Pass As String) As String
        Dim i As Integer, d As Integer
        Dim q As Integer = Content.Length
        Dim c As String = Nothing, pl As Integer = Pass.Length
        Dim cArr2(0 To 1000) As Integer ' Password
 
        For f As Integer = 0 To pl - 1
            cArr2(f) = Asc(Mid(Pass, f + 1, 1))
        Next

        i = 0
        For f As Integer = 0 To q - 1
            d = Asc(Mid(Content, f + 1, 1)) + cArr2(i)
            If d > 255 Then d = d - 255 - 1
            If d <= 15 Then c &= "0" & Hex(d) Else c &= Hex(d)

            i += 1
            If i >= pl Then i = 0
        Next
        Return c
    End Function

    Function MyDeCript(ByVal Content As String, ByVal Pass As String) As String
        Dim i As Integer, d As Integer
        Dim c As String = Nothing, pl As Integer = Pass.Length
        Dim q As Integer = Content.Length
        Dim cArr2(0 To 1000) As Integer ' Password
        For f As Integer = 0 To pl - 1
            cArr2(f) = Asc(Mid(Pass, f + 1, 1))
        Next
        i = 0
        For f As Integer = 0 To q \ 2 - 1
            d = Val("&h" & Mid(Content, f * 2 + 1, 2)) - cArr2(i)
            i += 1
            If i >= pl Then i = 0
            If d < 0 Then d += 255 + 1
            c &= ChrW(d)
        Next
        Return c
    End Function
End Class
