Imports MySql.Data.MySqlClient

Public Class DBConnection
    Public conn As New MySqlConnection("server=localhost;username=root;password=;database=wengs_delights2024")

    Public Sub UpdateLabels(label As Label, message As String)
        label.Text = message
    End Sub

    Public Function OpenDB() As MySqlConnection
        Try
            conn.Open()
            UpdateLabels(Form2.Label1, "Database is Connected")
            UpdateLabels(Form2.Label2, "Database is Connected")

            UpdateLabels(Form2.Label4, "Database is Connected")

            UpdateLabels(Form2.Label55, "Database is Connected")
            UpdateLabels(Form2.Label6, "Database is Connected")

            UpdateLabels(Form2.Label8, "Database is Connected")
        Catch ex As Exception
            UpdateLabels(Form2.Label1, "Database is not Connected")
            UpdateLabels(Form2.Label2, "Database is not Connected")

            UpdateLabels(Form2.Label4, "Database is not Connected")

            UpdateLabels(Form2.Label55, "Database is not Connected")

            UpdateLabels(Form2.Label6, "Database is not Connected")

            UpdateLabels(Form2.Label8, "Database is not Connected")
            MsgBox(ex.Message)
        End Try
        Return conn
    End Function

    Public Function CloseDB() As MySqlConnection
        Try
            conn.Close()
            UpdateLabels(Form2.Label1, "Database is Closed")
            UpdateLabels(Form2.Label2, "Database is Closed")

            UpdateLabels(Form2.Label4, "Database is Closed")
            UpdateLabels(Form2.Label55, "Database is Closed")

            UpdateLabels(Form2.Label6, "Database is Closed")

            UpdateLabels(Form2.Label8, "Database is Closed")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return conn
    End Function
End Class
