Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles customerlogin.Click
        ' Check if the customer username and password are correct
        If TextBox3.Text = "Customer" AndAlso customerpass.Text = "customer" Then
            ' If correct, navigate to Form3
            Dim form3 As New Form3()
            form3.Show()
            Me.Hide() ' Hide the current form
        Else
            MessageBox.Show("Invalid customer username or password. Please try again.")
            ' Clear the text boxes for the user to try again
            TextBox3.Text = ""
            customerpass.Text = ""
            ' Set focus back to the username textbox
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles Adminname.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged_1(sender As Object, e As EventArgs) Handles adminpass.TextChanged
        ' Set the password character to hide the text
        adminpass.UseSystemPasswordChar = True
    End Sub


    Private Sub adminlogin_Click(sender As Object, e As EventArgs) Handles adminlogin.Click
        ' Check if the admin username and password are correct
        If Adminname.Text = "Admin" AndAlso adminpass.Text = "admin" Then
            ' If correct, navigate to Form2
            Dim form2 As New Form2()
            form2.Show()
            Me.Hide() ' Hide the current form
        Else
            MessageBox.Show("Invalid admin username or password. Please try again.")
            ' Clear the text boxes for the user to try again
            Adminname.Text = ""
            adminpass.Text = ""
            ' Set focus back to the username textbox
            Adminname.Focus()
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub customerpass_TextChanged(sender As Object, e As EventArgs) Handles customerpass.TextChanged
        ' Set the password character to hide the text
        customerpass.UseSystemPasswordChar = True
    End Sub

    Private Sub empuser_TextChanged(sender As Object, e As EventArgs) Handles empuser.TextChanged

    End Sub

    Private Sub emppass_TextChanged(sender As Object, e As EventArgs) Handles emppass.TextChanged
        ' Set the password character to hide the text
        emppass.UseSystemPasswordChar = True
    End Sub


    Private Sub emplogin_Click(sender As Object, e As EventArgs) Handles emplogin.Click
        ' Check if the employee username and password are correct
        If empuser.Text = "Employee" AndAlso emppass.Text = "employee" Then
            ' If correct, navigate to Form4
            Dim form4 As New Form4()
            form4.Show()
            Me.Hide() ' Hide the current form
        Else
            MessageBox.Show("Invalid employee username or password. Please try again.")
            ' Clear the text boxes for the user to try again
            empuser.Text = ""
            emppass.Text = ""
            ' Set focus back to the username textbox
            empuser.Focus()
        End If
    End Sub

End Class

