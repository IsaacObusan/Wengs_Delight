Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports System.Diagnostics
Imports System.IO
Imports System.Threading.Tasks
Imports Google.Protobuf.WellKnownTypes

Public Class Form2
    Private ReadOnly dataRefreshTimer As System.Windows.Forms.Timer
    Private conn As MySqlConnection



    ' Constructor for Form2
    Public Sub New()
        ' Initialize the MySqlConnection object
        conn = New MySqlConnection("server=localhost;username=root;password=;database=wengs_delights2024")
        InitializeComponent()

        LoadData()
    End Sub




    Private Function LoadData()

        ' Clear ComboBoxes before loading new data
        ComboBox2224.Items.Clear()
        Combobox00.Items.Clear()
        employeeid.Items.Clear()
        ComboBox199.Items.Clear()
        ingredientid.Items.Clear()

        Try
            ' Open the database connection
            conn.Open()

            ' Query to retrieve data from the category table
            Dim categoryQuery As String = "SELECT category_id FROM category"

            ' Create a command to execute the category query
            Using categoryCommand As New MySqlCommand(categoryQuery, conn)
                ' Create a reader to read the results
                Using categoryReader As MySqlDataReader = categoryCommand.ExecuteReader()
                    ' Loop through the results and add them to ComboBox222
                    While categoryReader.Read()
                        ComboBox2224.Items.Add(categoryReader("category_id").ToString())
                    End While
                End Using
            End Using

            ' Query to retrieve data from the category table
            Dim ComboBox00Query As String = "SELECT category_id FROM category"

            ' Create a command to execute the ComboBox00 query
            Using ComboBox00Command As New MySqlCommand(ComboBox00Query, conn)
                ' Create a reader to read the results
                Using ComboBox00Reader As MySqlDataReader = ComboBox00Command.ExecuteReader()
                    ' Loop through the results and add them to ComboBox00
                    While ComboBox00Reader.Read()
                        Combobox00.Items.Add(ComboBox00Reader("category_id").ToString())
                    End While
                End Using
            End Using

            ' Query to retrieve data from the employee table
            Dim employeeQuery As String = "SELECT employee_id FROM employee"

            ' Create a command to execute the employee query
            Using employeeCommand As New MySqlCommand(employeeQuery, conn)
                ' Create a reader to read the results
                Using employeeReader As MySqlDataReader = employeeCommand.ExecuteReader()
                    ' Loop through the results and add them to employeeid ComboBox
                    While employeeReader.Read()
                        employeeid.Items.Add(employeeReader("employee_id").ToString())
                    End While
                End Using
            End Using

            ' Query to retrieve data from the ingredient table
            Dim ingredientQuery As String = "SELECT ingredient_id FROM ingredient"

            ' Create a command to execute the ingredient query
            Using ingredientCommand As New MySqlCommand(ingredientQuery, conn)
                ' Create a reader to read the results
                Using ingredientReader As MySqlDataReader = ingredientCommand.ExecuteReader()
                    ' Clear existing items in ComboBox199 and ingredientid ComboBox
                    ComboBox199.Items.Clear()
                    ingredientid.Items.Clear()

                    ' Loop through the results and add them to both ComboBoxes
                    While ingredientReader.Read()
                        ComboBox199.Items.Add(ingredientReader("ingredient_id").ToString())
                        ingredientid.Items.Add(ingredientReader("ingredient_id").ToString())
                    End While
                End Using
            End Using


        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error loading data: " & ex.Message)
        Finally
            ' Close the database connection
            conn.Close()
        End Try
    End Function





















    Private Sub ADD_Click(sender As Object, e As EventArgs) Handles ADD.Click
        Try
            ' Open the database connection
            conn.Open()

            ' Retrieve data from TextBoxes
            Dim employeeID As String = TextBox2.Text
            Dim data2 As String = TextBox3.Text
            Dim data3 As String = TextBox4.Text
            Dim data4 As String = TextBox5.Text
            Dim data5 As String = TextBox6.Text
            Dim data6 As String = TextBox7.Text
            Dim data7 As String = TextBox8.Text

            ' Construct the SQL INSERT query
            Dim query As String = "INSERT INTO `employee` (`employee_id`, `lname`, `fname`, `mname`, `position`, `address`, `contact_no`) " &
             "VALUES (@employee_id, @data2, @data3, @data4, @data5, @data6, @data7)"

            ' Create a new MySqlCommand object with the query and connection
            Dim command As New MySqlCommand(query, conn)

            ' Add parameters to the command
            command.Parameters.AddWithValue("@employee_id", employeeID)
            command.Parameters.AddWithValue("@data2", data2)
            command.Parameters.AddWithValue("@data3", data3)
            command.Parameters.AddWithValue("@data4", data4)
            command.Parameters.AddWithValue("@data5", data5)
            command.Parameters.AddWithValue("@data6", data6)
            command.Parameters.AddWithValue("@data7", data7)

            ' Execute the query to insert the data into the database table
            command.ExecuteNonQuery()

            ' Display a success message
            MessageBox.Show("Data added successfully!")

            ' Clear TextBoxes 2 to 8
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""



            ' Refresh the data displayed in DataGridView1
            RefreshDataGridView()
        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Close the database connection
            conn.Close()
        End Try
        LoadData()
    End Sub

    Private Sub RefreshDataGridView()
        Try
            ' Clear the existing data in the DataGridView
            DataGridView1.DataSource = Nothing

            ' Re-fetch data from the database
            Dim dataTable As New DataTable()
            Using adapter As New MySqlDataAdapter("SELECT * FROM employee", conn)
                adapter.Fill(dataTable)
            End Using

            ' Re-bind the DataTable to the DataGridView
            DataGridView1.DataSource = dataTable
        Catch ex As Exception
            MessageBox.Show("Error refreshing DataGridView: " & ex.Message)
        End Try
    End Sub

    Private Sub DELETE_Click(sender As Object, e As EventArgs) Handles DELETE.Click
        ' Check if exactly one row is selected in the DataGridView
        If DataGridView1.SelectedRows.Count = 1 Then
            ' Get the selected row
            Dim selectedRow = DataGridView1.SelectedRows(0)
            ' Get the value of the employeeID from the selected row
            Dim employeeID = selectedRow.Cells("employee_id").Value.ToString
            ' Construct the SQL DELETE query
            Dim query = "DELETE FROM `employee` WHERE `employee_id` = @employee_id"
            ' Create a new MySqlCommand object with the query and connection
            Dim command As New MySqlCommand(query, conn)
            ' Add parameter to the command
            command.Parameters.AddWithValue("@employee_id", employeeID)
            Try
                ' Open the database connection
                conn.Open()
                ' Execute the query to delete the selected row
                command.ExecuteNonQuery()
                ' Display a success message
                MessageBox.Show("Row deleted successfully!")
                ' Refresh the data displayed in DataGridView1
                RefreshDataGridView()
                ' Remove the deleted employee from ComboBox4 items
                Me.employeeid.Items.Remove(employeeID)
            Catch ex As Exception
                ' Handle any exceptions that occur
                MessageBox.Show("Error: " & ex.Message)
            Finally
                ' Close the database connection
                conn.Close()
            End Try
        ElseIf DataGridView1.SelectedRows.Count = 0 Then
            ' If no row is selected, display a message
            MessageBox.Show("Please select a row to delete.")
        Else
            ' If more than one row is selected, display a message
            MessageBox.Show("Please select only one row to delete.")
        End If
    End Sub



    Private Sub SAVE_Click(sender As Object, e As EventArgs) Handles SAVE.Click
        Try
            ' Construct the SQL SELECT query
            Dim query As String = "SELECT * FROM employee"
            conn.Open()

            ' Create MySqlCommand
            Dim command As New MySqlCommand(query, conn)

            ' Execute the query
            Dim reader As MySqlDataReader = command.ExecuteReader()

            ' Create a new SQL file
            Dim filePath As String = "C:\Users\John Isaac C. Obusan\Downloads\employee_data.sql"
            Dim writer As New StreamWriter(filePath)

            ' Write INSERT statements to SQL file
            While reader.Read()
                Dim insertStatement As String = $"INSERT INTO employee (employee_id, employee_name, employee_role, employee_salary) VALUES ('{reader("employee_id")}', '{reader("employee_name")}', '{reader("employee_role")}', {reader("employee_salary")});"
                writer.WriteLine(insertStatement)
            End While

            ' Close the StreamWriter
            writer.Close()

            MessageBox.Show("SQL file generated successfully!")

        Catch ex As Exception
            MessageBox.Show("Error generating SQL file: " & ex.Message)
        Finally
            ' Close the database connection
            conn.Close()
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub UPDATE_Click(sender As Object, e As EventArgs) Handles UPDATE.Click
        Try
            ' Open the database connection
            conn.Open()

            ' Retrieve data from TextBoxes
            Dim employeeID As String = TextBox2.Text
            Dim lastName As String = TextBox3.Text
            Dim firstName As String = TextBox4.Text
            Dim middleName As String = TextBox5.Text
            Dim position As String = TextBox6.Text
            Dim address As String = TextBox7.Text
            Dim contactNo As String = TextBox8.Text ' Assuming TextBox8 contains contact number

            ' Check for null or empty values
            If String.IsNullOrEmpty(employeeID) OrElse String.IsNullOrEmpty(lastName) OrElse String.IsNullOrEmpty(firstName) Then
                MessageBox.Show("Please fill in all required fields (Employee ID, Last Name, First Name).")
                Return
            End If

            ' Construct the SQL UPDATE query
            Dim query As String = "UPDATE `employee` SET `lname` = @lname, `fname` = @fname, `mname` = @mname, `position` = @position, `address` = @address, `contact_no` = @contact_no WHERE `employee_id` = @employee_id"

            ' Create a new MySqlCommand object with the query and connection
            Dim command As New MySqlCommand(query, conn)

            ' Add parameters to the command
            command.Parameters.AddWithValue("@employee_id", employeeID)
            command.Parameters.AddWithValue("@lname", lastName)
            command.Parameters.AddWithValue("@fname", firstName)
            command.Parameters.AddWithValue("@mname", middleName)
            command.Parameters.AddWithValue("@position", position)
            command.Parameters.AddWithValue("@address", address)
            command.Parameters.AddWithValue("@contact_no", contactNo)

            ' Execute the query to update the data in the database table
            Dim rowsAffected As Integer = command.ExecuteNonQuery()

            If rowsAffected > 0 Then
                ' Display a success message
                MessageBox.Show("Data updated successfully!")
                ' Clear TextBoxes
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
                ' Refresh the data displayed in DataGridView1
                RefreshDataGridView()
            Else
                MessageBox.Show("No records updated.")
            End If
        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Close the database connection
            conn.Close()
        End Try
    End Sub


    Private Sub Search_TextChanged(sender As Object, e As EventArgs) Handles Search.TextChanged
        ' Get the text from the SEARCH TextBox
        Dim searchText As String = Search.Text.Trim()

        ' If the search text is empty, refresh the DataGridView to show all data
        If String.IsNullOrEmpty(searchText) Then
            RefreshDataGridView()
            Return
        End If

        ' Query to filter data based on the search text
        ' Query to filter data based on the search text across all columns
        ' Query to filter data based on the search text across all columns
        Dim query As String = "SELECT * FROM `employee` WHERE `lname` LIKE @searchText OR `fname` LIKE @searchText OR `mname` LIKE @searchText OR `position` LIKE @searchText OR `address` LIKE @searchText OR `contact_no` LIKE @searchText OR `employee_id` LIKE @searchText"



        ' Create a new MySqlCommand object with the query and connection
        Dim command As New MySqlCommand(query, conn)

        ' Add parameter to the command
        command.Parameters.AddWithValue("@searchText", "%" & searchText & "%")


        ' Create a new DataTable to store the filtered results
        Dim dataTable As New DataTable()

        Try
            ' Create a new MySqlDataAdapter to fill the DataTable with the results of the query
            Dim dataAdapter As New MySqlDataAdapter(command)

            ' Fill the DataTable with the filtered results
            dataAdapter.Fill(dataTable)

            ' Bind the DataTable to the DataGridView1
            DataGridView1.DataSource = dataTable
        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub TextBox20_TextChanged(sender As Object, e As EventArgs) Handles searchcat.TextChanged
        ' Get the search keyword from TextBox20
        Dim searchKeyword As String = searchcat.Text.Trim()

        ' If searchKeyword is empty, show all rows
        If String.IsNullOrWhiteSpace(searchKeyword) Then
            RefreshDataGridView4() ' Call the method to refresh DataGridView4 to show all rows
        Else
            Try
                ' Construct the SQL query to filter the data based on the search keyword
                Dim query As String = "SELECT * FROM category WHERE category_id LIKE @searchKeyword OR category_name LIKE @searchKeyword OR description LIKE @searchKeyword"

                ' Create a new MySqlCommand object with the query and connection
                Dim command As New MySqlCommand(query, conn)

                ' Add parameter to the command
                command.Parameters.AddWithValue("@searchKeyword", "%" & searchKeyword & "%")

                ' Open the database connection
                conn.Open()

                ' Execute the query and fill the results into a DataTable
                Dim dataTable As New DataTable()
                Using adapter As New MySqlDataAdapter(command)
                    adapter.Fill(dataTable)
                End Using

                ' Bind the filtered data to DataGridView4
                DataGridView4.DataSource = dataTable
            Catch ex As Exception
                MessageBox.Show("Error searching categories: " & ex.Message)
            Finally
                ' Close the database connection
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub RefreshDataGridView4()
        ' Clear the data source of DataGridView4
        DataGridView4.DataSource = Nothing
    End Sub


    Private Sub DataGridView4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView4.CellContentClick

    End Sub

    Private Sub TextBox21_TextChanged(sender As Object, e As EventArgs) Handles TextBox21.TextChanged

    End Sub

    Private Sub TextBox22_TextChanged(sender As Object, e As EventArgs) Handles TextBox22.TextChanged

    End Sub

    Private Sub TextBox23_TextChanged(sender As Object, e As EventArgs) Handles TextBox23.TextChanged

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            ' Open the database connection
            conn.Open()

            ' Retrieve data from TextBoxes
            Dim categoryID As String = TextBox21.Text
            Dim categoryName As String = TextBox22.Text
            Dim description As String = TextBox23.Text

            ' Construct the SQL INSERT query
            Dim query As String = "INSERT INTO `category` (`category_id`, `category_name`, `description`) " &
        "VALUES (@category_id, @category_name, @description)"

            ' Create a new MySqlCommand object with the query and connection
            Dim command As New MySqlCommand(query, conn)

            ' Add parameters to the command
            command.Parameters.AddWithValue("@category_id", categoryID)
            command.Parameters.AddWithValue("@category_name", categoryName)
            command.Parameters.AddWithValue("@description", description)

            ' Execute the query to insert the data into the database table
            command.ExecuteNonQuery()

            ' Display a success message
            MessageBox.Show("Data added successfully!")

            ' Clear TextBoxes 21 to 23
            TextBox21.Text = ""
            TextBox22.Text = ""
            TextBox23.Text = ""



            ' Refresh DataGridView4 to display all data
            RefreshDataGridView5()

        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Close the database connection
            conn.Close()
        End Try
        LoadData()
    End Sub


    Private Sub RefreshDataGridView5()
        Try
            ' Clear the existing data in the DataGridView
            DataGridView4.DataSource = Nothing

            ' Re-fetch data from the database
            Dim dataTable As New DataTable()
            Using adapter As New MySqlDataAdapter("SELECT * FROM category", conn)
                adapter.Fill(dataTable)
            End Using

            ' Bind the DataTable to DataGridView4
            DataGridView4.DataSource = dataTable
        Catch ex As Exception
            MessageBox.Show("Error refreshing DataGridView: " & ex.Message)
        End Try
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        ' Check if exactly one row is selected in the DataGridView
        If DataGridView4.SelectedRows.Count = 1 Then
            ' Get the selected row
            Dim selectedRow = DataGridView4.SelectedRows(0)
            ' Get the value of the category ID from the selected row
            Dim categoryID = selectedRow.Cells("category_id").Value.ToString()
            ' Construct the SQL DELETE query
            Dim query = "DELETE FROM `category` WHERE `category_id` = @category_id"
            ' Create a new MySqlCommand object with the query and connection
            Dim command As New MySqlCommand(query, conn)
            ' Add parameter to the command
            command.Parameters.AddWithValue("@category_id", categoryID)
            Try
                ' Open the database connection
                conn.Open()
                ' Execute the query to delete the selected row
                command.ExecuteNonQuery()
                ' Display a success message
                MessageBox.Show("Row deleted successfully!")

                ' Remove the selected row from DataGridView4
                DataGridView4.Rows.Remove(selectedRow)

                ' Remove the deleted category from ComboBox2 items
                ComboBox2224.Items.Remove(categoryID)

                ' Remove the deleted category from ComboBox0 items
                Combobox00.Items.Remove(categoryID)

            Catch ex As Exception
                ' Handle any exceptions that occur
                MessageBox.Show("Error: " & ex.Message)
            Finally
                ' Close the database connection
                conn.Close()
            End Try
        ElseIf DataGridView4.SelectedRows.Count = 0 Then
            ' If no row is selected, display a message
            MessageBox.Show("Please select a row to delete.")
        Else
            ' If more than one row is selected, display a message
            MessageBox.Show("Please select only one row to delete.")
        End If
    End Sub


    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        ' Check if a row is selected in DataGridView4
        If DataGridView4.SelectedRows.Count = 1 Then
            Dim selectedRow = DataGridView4.SelectedRows(0)

            ' Get the values from TextBoxes
            Dim categoryID As String = TextBox21.Text
            Dim categoryName As String = TextBox22.Text
            Dim description As String = TextBox23.Text

            ' Get the index of the selected row
            Dim rowIndex As Integer = selectedRow.Index

            ' Update the values in the DataGridView
            selectedRow.Cells("category_id").Value = categoryID
            selectedRow.Cells("category_name").Value = categoryName
            selectedRow.Cells("description").Value = description

            ' Display a success message
            MessageBox.Show("Row updated successfully!")

            ' Clear TextBoxes
            TextBox21.Text = ""
            TextBox22.Text = ""
            TextBox23.Text = ""
        ElseIf DataGridView4.SelectedRows.Count = 0 Then
            ' If no row is selected, display a message
            MessageBox.Show("Please select a row to update.")
        Else
            ' If more than one row is selected, display a message
            MessageBox.Show("Please select only one row to update.")
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2224.SelectedIndexChanged

    End Sub

    Private Sub Catid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combobox00.SelectedIndexChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            ' Open the database connection
            conn.Open()

            ' Check if a category is selected in ComboBox2224
            If ComboBox2224.SelectedItem IsNot Nothing Then
                ' Retrieve data from TextBoxes
                Dim ingredient_id As String = TextBox14.Text
                Dim category_id As String = ComboBox2224.SelectedItem.ToString()
                Dim ingredient_name As String = TextBox15.Text
                Dim unit As String = TextBox16.Text
                Dim quantity As String = TextBox17.Text
                Dim price As String = TextBox18.Text
                Dim description As String = TextBox19.Text

                ' Construct the SQL INSERT query
                Dim query As String = "INSERT INTO `ingredient` (`ingredient_id`, `category_id`, `ingredient_name`, `unit`, `quantity`, `price`, `description`) " &
            "VALUES (@ingredient_id, @category_id, @ingredient_name, @unit, @quantity, @price, @description)"

                ' Create a new MySqlCommand object with the query and connection
                Dim command As New MySqlCommand(query, conn)

                ' Add parameters to the command
                command.Parameters.AddWithValue("@ingredient_id", ingredient_id)
                command.Parameters.AddWithValue("@category_id", category_id)
                command.Parameters.AddWithValue("@ingredient_name", ingredient_name)
                command.Parameters.AddWithValue("@unit", unit)
                command.Parameters.AddWithValue("@quantity", quantity)
                command.Parameters.AddWithValue("@price", price)
                command.Parameters.AddWithValue("@description", description)

                ' Execute the query to insert the data into the database table
                command.ExecuteNonQuery()

                ' Display a success message
                MessageBox.Show("Data added successfully!")

                ' Clear TextBoxes 14 to 19
                TextBox14.Text = ""
                ComboBox2224.SelectedIndex = -1
                TextBox15.Text = ""
                TextBox16.Text = ""
                TextBox17.Text = ""
                TextBox18.Text = ""
                TextBox19.Text = ""



                ' Refresh the data displayed in DataGridView3
                RefreshDataGridView3()
            Else
                MessageBox.Show("Please select a category from ComboBox2224.")
            End If
        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Close the database connection
            conn.Close()
        End Try
        LoadData()
    End Sub


    Private Sub RefreshDataGridView3()
        Try
            ' Clear the existing data in the DataGridView
            DataGridView3.DataSource = Nothing

            ' Re-fetch data from the database
            Dim dataTable As New DataTable()
            Using adapter As New MySqlDataAdapter("SELECT * FROM ingredient", conn)
                adapter.Fill(dataTable)
            End Using

            ' Bind the DataTable to DataGridView3
            DataGridView3.DataSource = dataTable
        Catch ex As Exception
            MessageBox.Show("Error refreshing DataGridView3: " & ex.Message)
        End Try
    End Sub






    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged

    End Sub

    Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs) Handles TextBox15.TextChanged

    End Sub

    Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs) Handles TextBox16.TextChanged

    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles TextBox17.TextChanged

    End Sub

    Private Sub TextBox18_TextChanged(sender As Object, e As EventArgs) Handles TextBox18.TextChanged

    End Sub

    Private Sub TextBox19_TextChanged(sender As Object, e As EventArgs) Handles TextBox19.TextChanged

    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ' Check if exactly one row is selected in the DataGridView
        If DataGridView3.SelectedRows.Count = 1 Then
            ' Get the selected row
            Dim selectedRow = DataGridView3.SelectedRows(0)
            ' Get the value of the ingredient_id from the selected row
            Dim ingredientID = selectedRow.Cells("ingredient_id").Value.ToString
            ' Construct the SQL DELETE query
            Dim query = "DELETE FROM `ingredient` WHERE `ingredient_id` = @ingredient_id"
            ' Create a new MySqlCommand object with the query and connection
            Dim command As New MySqlCommand(query, conn)
            ' Add parameter to the command
            command.Parameters.AddWithValue("@ingredient_id", ingredientID)
            Try
                ' Open the database connection
                conn.Open()
                ' Execute the query to delete the selected row
                command.ExecuteNonQuery()
                ' Display a success message
                MessageBox.Show("Row deleted successfully!")
                ' Refresh the data displayed in DataGridView3
                RefreshDataGridView3()
                ' Remove the deleted ingredient from ComboBox3 items
                Me.ingredientid.Items.Remove(ingredientID)
            Catch ex As Exception
                ' Handle any exceptions that occur
                MessageBox.Show("Error: " & ex.Message)
            Finally
                ' Close the database connection
                conn.Close()
            End Try
        ElseIf DataGridView3.SelectedRows.Count = 0 Then
            ' If no row is selected, display a message
            MessageBox.Show("Please select a row to delete.")
        Else
            ' If more than one row is selected, display a message
            MessageBox.Show("Please select only one row to delete.")
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
    End Sub


    Private Sub searching_TextChanged(sender As Object, e As EventArgs) Handles searching.TextChanged
        Try
            ' Open the database connection
            conn.Open()

            ' Construct the SQL SELECT query for live search
            Dim query As String = "SELECT * FROM `ingredient` WHERE `ingredient_id` LIKE @search OR `category_id` LIKE @search OR `ingredient_name` LIKE @search OR `unit` LIKE @search OR `quantity` LIKE @search OR `price` LIKE @search OR `description` LIKE @search"

            ' Create a new MySqlCommand object with the query and connection
            Dim command As New MySqlCommand(query, conn)

            ' Add parameter to the command for live search
            command.Parameters.AddWithValue("@search", "%" & searching.Text & "%")

            ' Create a new DataTable to store the search results
            Dim dataTable As New DataTable()

            ' Create a new MySqlDataAdapter object with the command
            Dim adapter As New MySqlDataAdapter(command)

            ' Fill the DataTable with the search results
            adapter.Fill(dataTable)

            ' Bind the DataTable to DataGridView3 to display the search results
            DataGridView3.DataSource = dataTable
        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Close the database connection
            conn.Close()
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox199.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' Check if all textboxes are filled and both comboboxes have selections
            If Not String.IsNullOrWhiteSpace(TextBox9.Text) AndAlso
           Not String.IsNullOrWhiteSpace(TextBox10.Text) AndAlso
           Not String.IsNullOrWhiteSpace(TextBox11.Text) AndAlso
           Not String.IsNullOrWhiteSpace(TextBox12.Text) AndAlso
           Not String.IsNullOrWhiteSpace(TextBox100.Text) AndAlso
           ComboBox199.SelectedItem IsNot Nothing AndAlso
           Combobox00.SelectedItem IsNot Nothing Then

                ' Open the database connection
                conn.Open()

                ' Construct the SQL INSERT query
                Dim query As String = "INSERT INTO `product` (`product_id`, `ingredient_ids`, `category_id`, `product_name`, `price`, `description`, `stock`) " &
                                  "VALUES (@product_id, @ingredient_ids, @category_id, @product_name, @price, @description, @stock)"

                ' Create a new MySqlCommand object with the query and connection
                Dim command As New MySqlCommand(query, conn)

                ' Add parameters to the command
                command.Parameters.AddWithValue("@product_id", TextBox9.Text)
                command.Parameters.AddWithValue("@product_name", TextBox10.Text)
                command.Parameters.AddWithValue("@description", TextBox11.Text)
                command.Parameters.AddWithValue("@price", TextBox12.Text)
                command.Parameters.AddWithValue("@stock", TextBox100.Text)
                command.Parameters.AddWithValue("@ingredient_ids", ComboBox199.SelectedItem.ToString())
                command.Parameters.AddWithValue("@category_id", Combobox00.SelectedItem.ToString())

                ' Execute the query to insert the data into the database table
                command.ExecuteNonQuery()

                ' Display a success message
                MessageBox.Show("Data added successfully!")

                ' Clear TextBoxes and ComboBoxes
                TextBox9.Clear()
                TextBox10.Clear()
                TextBox11.Clear()
                TextBox12.Clear()
                TextBox100.Clear()

                ComboBox199.SelectedIndex = -1
                Combobox00.SelectedIndex = -1

                ' Refresh DataGridView2
                RefreshDataGridView2()

            Else
                ' Display a message if any required field is empty
                MessageBox.Show("Please fill in all textboxes and select values from both comboboxes.")
            End If
        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Close the database connection
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
        LoadData()
    End Sub

    Private Sub RefreshDataGridView2()
        Try
            ' Clear the existing data in the DataGridView
            DataGridView2.DataSource = Nothing

            ' Re-fetch data from the database
            Dim dataTable As New DataTable()
            Using adapter As New MySqlDataAdapter("SELECT * FROM product", conn)
                adapter.Fill(dataTable)
            End Using

            ' Bind the DataTable to DataGridView2
            DataGridView2.DataSource = dataTable
        Catch ex As Exception
            MessageBox.Show("Error refreshing DataGridView2: " & ex.Message)
        End Try
    End Sub




    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged

    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged

    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged

    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Check if a row is selected
        If DataGridView2.SelectedRows.Count > 0 Then
            Try
                ' Open the database connection
                conn.Open()

                ' Construct the SQL UPDATE query
                Dim query As String = "UPDATE product SET product_name = @product_name, description = @description, price = @price, ingredient_ids = @ingredient_ids, category_id = @category_id, stock = @stock WHERE product_id = @product_id"

                ' Create a new MySqlCommand object with the query and connection
                Dim command As New MySqlCommand(query, conn)

                ' Add parameters for update
                command.Parameters.AddWithValue("@product_id", DataGridView2.SelectedRows(0).Cells("product_id").Value.ToString())
                command.Parameters.AddWithValue("@product_name", TextBox10.Text)
                command.Parameters.AddWithValue("@description", TextBox11.Text)
                command.Parameters.AddWithValue("@price", TextBox12.Text)
                command.Parameters.AddWithValue("@ingredient_ids", ComboBox199.SelectedItem.ToString())
                command.Parameters.AddWithValue("@category_id", Combobox00.SelectedItem.ToString())
                command.Parameters.AddWithValue("@stock", TextBox100.Text)

                ' Execute the query to update the row in the database table
                command.ExecuteNonQuery()

                ' Display a success message
                MessageBox.Show("Row updated successfully!")

                ' Refresh DataGridView2
                RefreshDataGridView2()
            Catch ex As Exception
                ' Handle any exceptions that occur
                MessageBox.Show("Error: " & ex.Message)
            Finally
                ' Close the database connection
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try
        Else
            ' If no row is selected, show a message
            MessageBox.Show("Please select a row to update.")
        End If
    End Sub






    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Check if exactly one row is selected in the DataGridView
        If DataGridView2.SelectedRows.Count = 1 Then
            ' Get the selected row
            Dim selectedRow = DataGridView2.SelectedRows(0)
            ' Get the value of the product_id from the selected row
            Dim productID = selectedRow.Cells("product_id").Value.ToString
            ' Construct the SQL DELETE query
            Dim query = "DELETE FROM `product` WHERE `product_id` = @product_id"
            ' Create a new MySqlCommand object with the query and connection
            Dim command As New MySqlCommand(query, conn)
            ' Add parameter to the command
            command.Parameters.AddWithValue("@product_id", productID)
            Try
                ' Open the database connection
                conn.Open()
                ' Execute the query to delete the selected row
                command.ExecuteNonQuery()
                ' Display a success message
                MessageBox.Show("Row deleted successfully!")
                ' Refresh the data displayed in DataGridView3
                RefreshDataGridView2()
            Catch ex As Exception
                ' Handle any exceptions that occur
                MessageBox.Show("Error: " & ex.Message)
            Finally
                ' Close the database connection
                conn.Close()
            End Try
        ElseIf DataGridView2.SelectedRows.Count = 0 Then
            ' If no row is selected, display a message
            MessageBox.Show("Please select a row to delete.")
        Else
            ' If more than one row is selected, display a message
            MessageBox.Show("Please select only one row to delete.")
        End If
    End Sub





    Private Sub l2search_TextChanged(sender As Object, e As EventArgs) Handles l2search.TextChanged
        Try
            ' Open the database connection
            conn.Open()

            ' Construct the SQL SELECT query with a WHERE clause for live search
            Dim query As String = "SELECT * FROM `product` WHERE " &
                              "`product_id` LIKE @search OR " &
                              "`ingredient_ids` LIKE @search OR " &
                              "`category_id` LIKE @search OR " &
                              "`product_name` LIKE @search OR " &
                              "`price` LIKE @search OR " &
                              "`description` LIKE @search OR " &
                              "`stock` LIKE @search" ' Added `stock` to the search criteria

            ' Create a new MySqlCommand object with the query and connection
            Dim command As New MySqlCommand(query, conn)

            ' Add parameter to the command
            command.Parameters.AddWithValue("@search", "%" & l2search.Text & "%")

            ' Execute the query and fill the results into a DataTable
            Dim dataTable As New DataTable()
            Dim adapter As New MySqlDataAdapter(command)
            adapter.Fill(dataTable)

            ' Bind the DataTable to DataGridView2
            DataGridView2.DataSource = dataTable
        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Close the database connection
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub


    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub hjj_Click(sender As Object, e As EventArgs) Handles hjj.Click

    End Sub



    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ingredientid.SelectedIndexChanged

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles employeeid.SelectedIndexChanged

    End Sub



    Private Sub procurementid_TextChanged(sender As Object, e As EventArgs) Handles procurementid.TextChanged

    End Sub

    Private Sub dateprepared_ValueChanged(sender As Object, e As EventArgs) Handles dateprocured.ValueChanged

    End Sub
























    Private Sub spro_TextChanged(sender As Object, e As EventArgs) Handles spro.TextChanged
        Try
            ' Open the database connection if it's closed
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            ' Construct the SQL SELECT query for live search
            Dim query As String = "SELECT * FROM procure WHERE "

            ' Add conditions for each column
            query &= "procurement_id LIKE @search OR "
            query &= "ingredient_id LIKE @search OR "
            query &= "employee_id LIKE @search OR "
            query &= "date_procured LIKE @search"

            ' Create a new MySqlCommand object with the query and connection
            Dim command As New MySqlCommand(query, conn)

            ' Add parameter to the command for live search
            command.Parameters.AddWithValue("@search", "%" & spro.Text & "%")

            ' Create a new DataTable to store the search results
            Dim dataTable As New DataTable()

            ' Create a new MySqlDataAdapter object with the command
            Dim adapter As New MySqlDataAdapter(command)

            ' Fill the DataTable with the search results
            adapter.Fill(dataTable)

            ' Bind the DataTable to DataGridView70 to display the search results
            DataGridView70.DataSource = dataTable
        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Close the database connection if it's open
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub


    Private Sub DataGridView70_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView70.CellContentClick

    End Sub


    Private Sub addpr_Click(sender As Object, e As EventArgs) Handles addpr.Click
        Try
            ' Open the database connection if it's closed
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            If Not String.IsNullOrEmpty(procurementid.Text) AndAlso
           ingredientid.SelectedItem IsNot Nothing AndAlso
          employeeid.SelectedItem IsNot Nothing Then

                ' Add the data to the database
                Dim query As String = "INSERT INTO procure (procurement_id, ingredient_id, employee_id, date_procured) VALUES (@procurement_id, @ingredient_id, @employee_id, @date_procured)"
                Dim command As New MySqlCommand(query, conn)

                ' Add parameters for insertion
                command.Parameters.AddWithValue("@procurement_id", procurementid.Text)
                command.Parameters.AddWithValue("@ingredient_id", ingredientid.SelectedItem.ToString())
                command.Parameters.AddWithValue("@employee_id", employeeid.SelectedItem.ToString())
                command.Parameters.AddWithValue("@date_procured", dateprocured.Value.ToString("yyyy-MM-dd"))

                ' Execute the query
                command.ExecuteNonQuery()

                ' Display a success message
                MessageBox.Show("Data added successfully!")

                ' Refresh DataGridView70 to display all data
                RefreshDataGridView70()
            Else
                MessageBox.Show("Please fill in all required fields.")
            End If

        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error: " & ex.Message)

        Finally
            ' Close the database connection if it's open
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
        LoadData()
    End Sub

    Private Sub RefreshDataGridView70()
        Try
            ' Open the database connection if it's closed
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            ' Construct the SQL SELECT query to retrieve all data from the procure table
            Dim query As String = "SELECT * FROM procure"

            ' Create a new MySqlCommand object with the query and connection
            Dim command As New MySqlCommand(query, conn)

            ' Create a new DataTable to store the retrieved data
            Dim dataTable As New DataTable()

            ' Create a new MySqlDataAdapter object with the command
            Dim adapter As New MySqlDataAdapter(command)

            ' Fill the DataTable with the retrieved data
            adapter.Fill(dataTable)

            ' Bind the DataTable to DataGridView70 to display the updated data
            DataGridView70.DataSource = dataTable
        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Close the database connection if it's open
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub



    Private Sub updatepr_Click(sender As Object, e As EventArgs) Handles updatepr.Click
        Try
            ' Open the database connection if it's closed
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            ' Check if a row is selected in DataGridView70
            If DataGridView70.SelectedRows.Count > 0 Then
                ' Get the selected row
                Dim selectedRow As DataGridViewRow = DataGridView70.SelectedRows(0)

                ' Retrieve the values from the selected row
                Dim procurementId As String = selectedRow.Cells("procurement_id").Value.ToString()
                Dim ingredientId As String = selectedRow.Cells("ingredient_id").Value.ToString()
                Dim employeeId As String = selectedRow.Cells("employee_id").Value.ToString()
                Dim dateProcured As Date = DateTime.Parse(selectedRow.Cells("date_procured").Value.ToString())

                ' Update the data in the database
                Dim query As String = "UPDATE procure SET ingredient_id = @ingredient_id, employee_id = @employee_id, date_procured = @date_procured WHERE procurement_id = @procurement_id"
                Dim command As New MySqlCommand(query, conn)

                ' Add parameters for update
                command.Parameters.AddWithValue("@ingredient_id", ingredientId)
                command.Parameters.AddWithValue("@employee_id", employeeId)
                command.Parameters.AddWithValue("@date_procured", dateProcured.ToString("yyyy-MM-dd"))
                command.Parameters.AddWithValue("@procurement_id", procurementId)

                ' Execute the query
                command.ExecuteNonQuery()

                ' Refresh DataGridView70 to display updated data
                RefreshDataGridView70()
            Else
                MessageBox.Show("Please select a row to update.")
            End If

        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error: " & ex.Message)

        Finally
            ' Close the database connection if it's open
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub deletepr_Click(sender As Object, e As EventArgs) Handles deletepr.Click

        Try
            ' Open the database connection if it's closed
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            ' Check if a row is selected in DataGridView70
            If DataGridView70.SelectedRows.Count > 0 Then
                ' Get the selected row
                Dim selectedRow As DataGridViewRow = DataGridView70.SelectedRows(0)

                ' Retrieve the procurement_id from the selected row
                Dim procurementId As String = selectedRow.Cells("procurement_id").Value.ToString()

                ' Delete the row from the database
                Dim query As String = "DELETE FROM procure WHERE procurement_id = @procurement_id"
                Dim command As New MySqlCommand(query, conn)

                ' Add parameter for deletion
                command.Parameters.AddWithValue("@procurement_id", procurementId)

                ' Execute the query
                command.ExecuteNonQuery()

                ' Display a success message
                MessageBox.Show("Row deleted successfully!")

                ' Refresh DataGridView70 to display updated data
                RefreshDataGridView70()
            Else
                MessageBox.Show("Please select a row to delete.")
            End If

        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error: " & ex.Message)

        Finally
            ' Close the database connection if it's open
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub



    Private Sub dpr_Click(sender As Object, e As EventArgs) Handles dpr.Click
        Try
            ' Construct the SQL SELECT query
            Dim query As String = "SELECT * FROM procure"
            conn.Open()

            ' Create MySqlCommand
            Dim command As New MySqlCommand(query, conn)

            ' Execute the query
            Dim reader As MySqlDataReader = command.ExecuteReader()

            ' Create a new SQL file
            Dim filePath As String = "C:\Users\John Isaac C. Obusan\Downloads\procure_data.sql"
            Dim writer As New StreamWriter(filePath)

            ' Write INSERT statements to SQL file
            While reader.Read()
                Dim insertStatement As String = $"INSERT INTO procure (procure_id, ingredient_id, quantity, procure_date) VALUES ('{reader("procure_id")}', '{reader("ingredient_id")}', {reader("quantity")}, '{reader("procure_date")}');"
                writer.WriteLine(insertStatement)
            End While

            ' Close the StreamWriter
            writer.Close()

            MessageBox.Show("SQL file generated successfully!")

        Catch ex As Exception
            MessageBox.Show("Error generating SQL file: " & ex.Message)
        Finally
            ' Close the database connection
            conn.Close()
        End Try
    End Sub

    Private Sub bbc_Click(sender As Object, e As EventArgs) Handles bbc.Click
        ' Set the path where you want to save the database dump file
        Dim dumpFilePath As String = "C:\Users\John Isaac C. Obusan\Downloads\backup\wengs_delights2024.sql"

        ' Set the XAMPP MySQL bin directory path
        Dim mysqlBinPath As String = "C:\xampp\mysql\bin\"

        ' Set the database connection parameters
        Dim server As String = "localhost"
        Dim username As String = "root"
        Dim password As String = ""
        Dim database As String = "wengs_delights2024"

        Try
            ' Create a process start info for running the mysqldump command
            Dim psi As New ProcessStartInfo()
            psi.FileName = "cmd.exe"
            psi.RedirectStandardInput = True
            psi.RedirectStandardOutput = False
            psi.RedirectStandardError = False
            psi.UseShellExecute = False
            psi.CreateNoWindow = True

            ' Start the process
            Dim p As Process = Process.Start(psi)

            ' Write the mysqldump command to the standard input of the process
            Dim command As String = $"{mysqlBinPath}mysqldump.exe --user={username} --password={password} --host={server} {database} > ""{dumpFilePath}"""
            p.StandardInput.WriteLine(command)
            p.StandardInput.Flush()
            p.StandardInput.Close()

            ' Wait for the process to exit
            p.WaitForExit()

            ' Show success message
            MessageBox.Show("Database downloaded successfully.")

        Catch ex As Exception
            ' Show error message
            MessageBox.Show("Error downloading database: " & ex.Message)
        End Try
    End Sub



    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            ' Construct the SQL SELECT query
            Dim query As String = "SELECT * FROM product"
            conn.Open()

            ' Create MySqlCommand
            Dim command As New MySqlCommand(query, conn)

            ' Execute the query
            Dim reader As MySqlDataReader = command.ExecuteReader()

            ' Create a new SQL file
            Dim filePath As String = "C:\Users\John Isaac C. Obusan\Downloads\product_data.sql"
            Dim writer As New StreamWriter(filePath)

            ' Write INSERT statements to SQL file
            While reader.Read()
                Dim insertStatement As String = $"INSERT INTO product (product_id, product_name, stock, price) VALUES ('{reader("product_id")}', '{reader("product_name")}', {reader("stock")}, {reader("price")});"
                writer.WriteLine(insertStatement)
            End While

            ' Close the StreamWriter
            writer.Close()

            MessageBox.Show("SQL file generated successfully!")

        Catch ex As Exception
            MessageBox.Show("Error generating SQL file: " & ex.Message)
        Finally
            ' Close the database connection
            conn.Close()
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            ' Construct the SQL SELECT query
            Dim query As String = "SELECT * FROM ingredient"
            conn.Open()

            ' Create MySqlCommand
            Dim command As New MySqlCommand(query, conn)

            ' Execute the query
            Dim reader As MySqlDataReader = command.ExecuteReader()

            ' Create a new SQL file
            Dim filePath As String = "C:\Users\John Isaac C. Obusan\Downloads\ingredient_data.sql"
            Dim writer As New StreamWriter(filePath)

            ' Write INSERT statements to SQL file
            While reader.Read()
                Dim insertStatement As String = $"INSERT INTO ingredient (ingredient_id, ingredient_name, quantity) VALUES ('{reader("ingredient_id")}', '{reader("ingredient_name")}', {reader("quantity")});"
                writer.WriteLine(insertStatement)
            End While

            ' Close the StreamWriter
            writer.Close()

            MessageBox.Show("SQL file generated successfully!")

        Catch ex As Exception
            MessageBox.Show("Error generating SQL file: " & ex.Message)
        Finally
            ' Close the database connection
            conn.Close()
        End Try
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Try
            ' Construct the SQL SELECT query
            Dim query As String = "SELECT * FROM category"
            conn.Open()

            ' Create MySqlCommand
            Dim command As New MySqlCommand(query, conn)

            ' Execute the query
            Dim reader As MySqlDataReader = command.ExecuteReader()

            ' Create a new SQL file
            Dim filePath As String = "C:\Users\John Isaac C. Obusan\Downloads\category_data.sql"
            Dim writer As New StreamWriter(filePath)

            ' Write INSERT statements to SQL file
            While reader.Read()
                Dim insertStatement As String = $"INSERT INTO category (category_id, category_name) VALUES ('{reader("category_id")}', '{reader("category_name")}');"
                writer.WriteLine(insertStatement)
            End While

            ' Close the StreamWriter
            writer.Close()

            MessageBox.Show("SQL file generated successfully!")

        Catch ex As Exception
            MessageBox.Show("Error generating SQL file: " & ex.Message)
        Finally
            ' Close the database connection
            conn.Close()
        End Try
    End Sub

    Private Sub log_out_Click(sender As Object, e As EventArgs) Handles log_out.Click
        ' Create an instance of Form1
        Dim form1 As New Form1()

        ' Show Form1
        form1.Show()

        ' Optionally, close the current form (assuming it's not Form1)
        Me.Close()
    End Sub
End Class
