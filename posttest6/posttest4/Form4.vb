Imports MySql.Data.MySqlClient
Public Class Form4
    Dim connectionString As String = "server=localhost;userid=root;password=;database=dbtokomusik"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = TextBox1.Text
        Dim password As String = TextBox2.Text

        If ValidateLogin(username, password) Then
            MessageBox.Show("Login berhasil!")
            Dim Form3 As New FMenu
            Form3.Show()
            Me.Hide()
        Else
            MessageBox.Show("Username atau password salah!")
        End If
    End Sub

    Private Function ValidateLogin(username As String, password As String) As Boolean
        Using connection As New MySqlConnection(connectionString)
            connection.Open()
            Dim query As String = "SELECT COUNT(*) FROM account WHERE username = @username AND password = @password"
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@username", username)
                command.Parameters.AddWithValue("@password", password)
                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function
End Class