Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports OfficeOpenXml
Imports iText.Kernel.Pdf
Imports iText.Layout
Imports iText.Layout.Element
Imports iTextSharp.text.pdf

Public Class Form4
    Private conn As MySqlConnection

    ' Constructor for Form4
    Public Sub New()
        ' Initialize the MySqlConnection object
        conn = New MySqlConnection("server=localhost;username=root;password=;database=wengs_delights2024")
        InitializeComponent()


        LoadData()

    End Sub





    Private Sub LoadData()
        Try
            ' Open the database connection if it's closed
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            ' Query to retrieve data from the employee table
            Dim employeeQuery As String = "SELECT employee_id FROM employee"

            ' Clear existing items in employeeidd ComboBox
            employeeidd.Items.Clear()
            empemp.Items.Clear()

            ' Create a command to execute the employee query
            Using employeeCommand As New MySqlCommand(employeeQuery, conn)
                ' Create a reader to read the results
                Using employeeReader As MySqlDataReader = employeeCommand.ExecuteReader()
                    ' Loop through the results and add them to employeeidd and empemp ComboBoxes
                    While employeeReader.Read()
                        employeeidd.Items.Add(employeeReader("employee_id").ToString())
                        empemp.Items.Add(employeeReader("employee_id").ToString())
                    End While
                End Using
            End Using

            ' Query to retrieve data from the product table
            Dim productQuery As String = "SELECT product_id FROM product"

            ' Clear existing items in productprepareidd ComboBox
            productprepareidd.Items.Clear()

            ' Create a command to execute the product query
            Using productCommand As New MySqlCommand(productQuery, conn)
                ' Create a reader to read the results
                Using productReader As MySqlDataReader = productCommand.ExecuteReader()
                    ' Loop through the results and add them to productprepareidd ComboBox
                    While productReader.Read()
                        productprepareidd.Items.Add(productReader("product_id").ToString())
                    End While
                End Using
            End Using

            ' Query to retrieve data from the costumer table
            Dim costumerQuery As String = "SELECT costumer_id FROM costumer"

            ' Clear existing items in ComboBox133
            ComboBox133.Items.Clear()

            ' Create a command to execute the costumer query
            Using costumerCommand As New MySqlCommand(costumerQuery, conn)
                ' Create a reader to read the results
                Using costumerReader As MySqlDataReader = costumerCommand.ExecuteReader()
                    ' Loop through the results and add them to ComboBox133
                    While costumerReader.Read()
                        ComboBox133.Items.Add(costumerReader("costumer_id").ToString())
                    End While
                End Using
            End Using

            ' Query to calculate the total data of the total_amount column
            Dim totalAmountQuery As String = "SELECT SUM(total_amount) AS total FROM `order`"

            ' Create a command to execute the total amount query
            Using totalAmountCommand As New MySqlCommand(totalAmountQuery, conn)
                ' Execute the query and get the result
                Dim totalAmount As Decimal = CDec(totalAmountCommand.ExecuteScalar())

                ' Update the text of the daily textbox to display the total amount
                daily.Text = totalAmount.ToString()
            End Using

            ' Query to count the rows in the "order" table
            Dim orderCountQuery As String = "SELECT COUNT(*) FROM `order`"

            ' Create a command to execute the order count query
            Using orderCountCommand As New MySqlCommand(orderCountQuery, conn)
                ' Execute the query and get the result
                Dim orderRowCount As Integer = CInt(orderCountCommand.ExecuteScalar())

                ' Update the text of the ordersno textbox to display the row count
                ordersno.Text = orderRowCount.ToString()
            End Using

        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error loading data: " & ex.Message)
        Finally
            ' Close the database connection if it's open
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub










    Private Sub PREADD_Click(sender As Object, e As EventArgs) Handles addpree.Click
        Try
            ' Ensure the database connection is open
            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If

            ' Check if all required fields are filled
            If Not String.IsNullOrWhiteSpace(unitprepare.Text) AndAlso
           Not String.IsNullOrWhiteSpace(quantityy.Text) AndAlso
           Not String.IsNullOrWhiteSpace(prepareproid.Text) AndAlso
           Not String.IsNullOrWhiteSpace(Dateandtimedelivery.Text) AndAlso
           Not String.IsNullOrEmpty(productprepareidd.SelectedItem?.ToString()) AndAlso
           Not String.IsNullOrEmpty(employeeidd.SelectedItem?.ToString()) Then

                ' Construct the SQL INSERT query
                Dim query As String = "INSERT INTO `prepare` " &
                                  "(`prepared_product_id`, `product_id`, `employee_id`, `date_prepared`, `unit`, `quantity`, `date_and_time_of_delivery`) " &
                                  "VALUES (@prepared_product_id, @product_id, @employee_id, @date_prepared, @unit, @quantity, @date_and_time_of_delivery)"

                Dim command As New MySqlCommand(query, conn)

                ' Add parameters to the command
                command.Parameters.AddWithValue("@prepared_product_id", prepareproid.Text)
                command.Parameters.AddWithValue("@product_id", productprepareidd.SelectedItem.ToString())
                command.Parameters.AddWithValue("@employee_id", employeeidd.SelectedItem.ToString())
                command.Parameters.AddWithValue("@date_prepared", dateprepareddd.Value.ToString("yyyy-MM-dd"))
                command.Parameters.AddWithValue("@unit", unitprepare.Text)
                command.Parameters.AddWithValue("@quantity", quantityy.Text)
                command.Parameters.AddWithValue("@date_and_time_of_delivery", Dateandtimedelivery.Text)

                ' Execute the query to insert the data into the database table
                command.ExecuteNonQuery()

                ' Display a success message
                MessageBox.Show("Data added successfully!")

                ' Refresh DataGridView190
                RefreshDataGridView190()
            Else
                ' Display a message if any required field is empty
                MessageBox.Show("Please fill in all textboxes and select values from both comboboxes.")
            End If
        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Close the database connection if open
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
        LoadData()
    End Sub

    Private Sub RefreshDataGridView190()
        Throw New NotImplementedException()
    End Sub

    Private Sub productprepareidd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles productprepareidd.SelectedIndexChanged
        ' Add your logic here for when the product prepare ID ComboBox selection changes
    End Sub

    Private Sub dateprepareddd_ValueChanged(sender As Object, e As EventArgs) Handles dateprepareddd.ValueChanged
        ' Add your logic here for when the date prepare DDD value changes
    End Sub

    Private Sub unitprepare_TextChanged(sender As Object, e As EventArgs) Handles unitprepare.TextChanged
        ' Add your logic here for when the unit prepare TextBox text changes
    End Sub

    Private Sub quantityy_TextChanged(sender As Object, e As EventArgs) Handles quantityy.TextChanged
        ' Add your logic here for when the quantity TextBox text changes
    End Sub

    Private Sub DataGridView190_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView190.CellContentClick
        ' Add your logic here for when the DataGridView cell content is clicked
    End Sub

    Private Sub employeeidd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles employeeidd.SelectedIndexChanged

    End Sub

    Private Sub searchpre_TextChanged(sender As Object, e As EventArgs) Handles searchpre.TextChanged
        ' Assuming DataGridView190 is the name of your DataGridView
        DataGridView190.DataSource = Nothing ' Clear the existing data source

        ' Construct the SQL query to fetch data from the database
        Dim query As String = "SELECT * FROM prepare"

        ' If searchText is provided, add WHERE clause to filter based on search text
        If Not String.IsNullOrEmpty(searchpre.Text) Then
            query &= " WHERE prepared_product_id LIKE @searchText OR product_id LIKE @searchText OR employee_id LIKE @searchText OR date_prepared LIKE @searchText OR unit LIKE @searchText OR quantity LIKE @searchText"
        End If

        ' Create a DataTable to hold the data
        Dim dt As New DataTable()

        Try
            ' Open the database connection
            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If

            ' Create a MySqlCommand object with the query and connection
            Dim command As New MySqlCommand(query, conn)

            ' If searchText is provided, set parameters for search text
            If Not String.IsNullOrEmpty(searchpre.Text) Then
                command.Parameters.AddWithValue("@searchText", "%" & searchpre.Text & "%")
            End If

            ' Create a MySqlDataAdapter to execute the query and fill the DataTable
            Dim adapter As New MySqlDataAdapter(command)

            ' Fill the DataTable with the data from the database
            adapter.Fill(dt)

            ' Bind the DataTable to the DataGridView
            DataGridView190.DataSource = dt
        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error refreshing DataGridView190: " & ex.Message)
        Finally
            ' Close the database connection if open
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub PREUPDATE_Click(sender As Object, e As EventArgs) Handles PREUPDATE.Click
        ' Check if a row is selected
        If DataGridView190.SelectedRows.Count > 0 Then
            ' Get the selected row
            Dim selectedRow As DataGridViewRow = DataGridView190.SelectedRows(0)

            ' Get the data from the selected row
            Dim preparedProductId As String = selectedRow.Cells("prepared_product_id").Value.ToString()
            Dim productId As String = selectedRow.Cells("product_id").Value.ToString()
            Dim employeeId As String = selectedRow.Cells("employee_id").Value.ToString()
            Dim datePrepared As String = selectedRow.Cells("date_prepared").Value.ToString()
            Dim unit As String = selectedRow.Cells("unit").Value.ToString()
            Dim quantity As String = selectedRow.Cells("quantity").Value.ToString()

            ' Display the data in input controls for editing
            prepareproid.Text = preparedProductId
            ' Assuming productprepareidd is a ComboBox
            productprepareidd.SelectedItem = productId
            ' Assuming employeeidd is a ComboBox
            employeeidd.SelectedItem = employeeId
            ' Assuming dateprepareddd is a DateTimePicker
            dateprepareddd.Value = DateTime.ParseExact(datePrepared, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            unitprepare.Text = unit
            quantityy.Text = quantity

            ' You can enable/disable controls as needed or provide visual indication that the row is being edited

            ' Optionally, you can also disable the UpdateButton until the user finishes editing

            ' After the user edits the data and clicks "Update":
            Try
                ' Construct the SQL UPDATE query
                Dim query As String = "UPDATE `prepare` SET `prepared_product_id` = @prepared_product_id, " &
                                  "`product_id` = @product_id, `employee_id` = @employee_id, " &
                                  "`date_prepared` = @date_prepared, `unit` = @unit, `quantity` = @quantity " &
                                  "WHERE `prepared_product_id` = @original_prepared_product_id"

                Dim command As New MySqlCommand(query, conn)

                ' Add parameters to the command
                command.Parameters.AddWithValue("@prepared_product_id", prepareproid.Text)
                command.Parameters.AddWithValue("@product_id", productprepareidd.SelectedItem.ToString())
                command.Parameters.AddWithValue("@employee_id", employeeidd.SelectedItem.ToString())
                command.Parameters.AddWithValue("@date_prepared", dateprepareddd.Value.ToString("yyyy-MM-dd"))
                command.Parameters.AddWithValue("@unit", unitprepare.Text)
                command.Parameters.AddWithValue("@quantity", quantityy.Text)
                command.Parameters.AddWithValue("@original_prepared_product_id", preparedProductId)

                ' Execute the query to update the row in the database
                command.ExecuteNonQuery()

                ' Display a success message
                MessageBox.Show("Data updated successfully!")

                ' Refresh DataGridView190
                RefreshDataGridView190()
            Catch ex As Exception
                ' Handle any exceptions that occur
                MessageBox.Show("Error updating data: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Please select a row to update.")
        End If
    End Sub

    Private Sub DELETEPRE_Click(sender As Object, e As EventArgs) Handles DELETEPRE.Click
        Try
            ' Check if a row is selected in the DataGridView
            If DataGridView190.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = DataGridView190.SelectedRows(0)
                Dim prepareID As Integer = Convert.ToInt32(selectedRow.Cells("prepared_product_id").Value)

                ' Ensure the database connection is open
                If conn.State <> ConnectionState.Open Then
                    conn.Open()
                End If

                ' Construct the SQL DELETE query
                Dim query As String = "DELETE FROM `prepare` WHERE `prepare_id` = @prepare_id"
                Dim command As New MySqlCommand(query, conn)

                ' Add parameter to the command
                command.Parameters.AddWithValue("@prepare_id", prepareID)

                ' Execute the query to delete the row
                command.ExecuteNonQuery()

                ' Display a success message
                MessageBox.Show("Row deleted successfully!")

                ' Refresh DataGridView190
                RefreshDataGridView190()
            Else
                ' Display a message if no row is selected
                MessageBox.Show("Please select a row to delete.")
            End If
        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error deleting row: " & ex.Message)
        Finally
            ' Close the database connection if open
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub




    Private Sub ComboBox133_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox133.SelectedIndexChanged

    End Sub

    Private Sub prepareproid_TextChanged(sender As Object, e As EventArgs) Handles prepareproid.TextChanged

    End Sub

    Private Sub DELDEL_TextChanged(sender As Object, e As EventArgs) Handles DELDEL.TextChanged

    End Sub

    Private Sub empemp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles empemp.SelectedIndexChanged

    End Sub

    Private Sub oror_TextChanged(sender As Object, e As EventArgs) Handles oror.TextChanged

    End Sub

    Private Sub statsta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles statstatus.SelectedIndexChanged

    End Sub

    Private Sub ADDDEL_Click(sender As Object, e As EventArgs) Handles ADDDEL.Click

        Try
            ' Check if all required fields are filled
            If Not String.IsNullOrWhiteSpace(DELDEL.Text) AndAlso
           Not String.IsNullOrWhiteSpace(oror.Text) AndAlso
           Not String.IsNullOrEmpty(empemp.SelectedItem?.ToString()) AndAlso
           Not String.IsNullOrEmpty(statstatus.SelectedItem?.ToString()) AndAlso
           Not String.IsNullOrEmpty(ComboBox133.SelectedItem?.ToString()) Then

                ' Ensure the database connection is open
                If conn.State <> ConnectionState.Open Then
                    conn.Open()
                End If

                ' Construct the SQL INSERT query
                Dim query As String = "INSERT INTO `deliver` (`delivery_id`, `order_id`, `employee_id`, `status`, `customer_id`) " &
                                  "VALUES (@delivery_id, @order_id, @employee_id, @status, @customer_id)"

                Dim command As New MySqlCommand(query, conn)

                ' Add parameters to the command
                command.Parameters.AddWithValue("@delivery_id", DELDEL.Text)
                command.Parameters.AddWithValue("@order_id", oror.Text)
                command.Parameters.AddWithValue("@employee_id", empemp.SelectedItem.ToString())
                command.Parameters.AddWithValue("@status", statstatus.SelectedItem.ToString())
                command.Parameters.AddWithValue("@customer_id", ComboBox133.SelectedItem.ToString())

                ' Execute the query to insert the data into the database table
                command.ExecuteNonQuery()

                ' Display a success message
                MessageBox.Show("Data added successfully!")

                ' Clear TextBoxes and ComboBoxes
                DELDEL.Clear()
                oror.Clear()
                empemp.SelectedIndex = -1
                statstatus.SelectedIndex = -1
                ComboBox133.SelectedIndex = -1

                ' Refresh DataGridViewmos
                ' RefreshDataGridViewmos() ' Call your refresh method here if implemented

            Else
                ' Display a message if any required field is empty
                MessageBox.Show("Please fill in all textboxes and select values from both comboboxes.")
            End If
        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Close the database connection if open
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
        LoadData()
    End Sub



    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridviewmos.CellContentClick

    End Sub

    Private Sub SEARCHDEL_TextChanged(sender As Object, e As EventArgs) Handles SEARCHDEL.TextChanged
        ' Get the search criteria from the textboxes or comboboxes
        Dim deliveryId As String = DELDEL.Text.Trim()

        ' Perform the search query using the search criteria
        Dim searchQuery As String = "SELECT * FROM deliver WHERE delivery_id LIKE @deliveryId"

        Try
            ' Open the database connection
            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If

            ' Create a command to execute the search query
            Using command As New MySqlCommand(searchQuery, conn)
                ' Add parameters to the command
                command.Parameters.AddWithValue("@deliveryId", $"%{deliveryId}%")

                ' Create a DataTable to hold the search results
                Dim dt As New DataTable()

                ' Create a MySqlDataAdapter to fill the DataTable with the search results
                Dim adapter As New MySqlDataAdapter(command)

                ' Fill the DataTable with the search results
                adapter.Fill(dt)

                ' Bind the DataTable to your DataGridView (DataGridviewmos)
                DataGridviewmos.DataSource = dt
            End Using
        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error performing live search: " & ex.Message)
        Finally
            ' Close the database connection if open
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub UPDATEDEL_Click(sender As Object, e As EventArgs) Handles UPDATEDEL.Click
        Try
            ' Check if a row is selected
            If DataGridviewmos.SelectedRows.Count > 0 Then
                ' Get the selected row
                Dim selectedRow As DataGridViewRow = DataGridviewmos.SelectedRows(0)

                ' Get the delivery ID from the selected row
                Dim deliveryID As String = selectedRow.Cells("delivery_id").Value.ToString()

                ' Ensure the database connection is open
                If conn.State <> ConnectionState.Open Then
                    conn.Open()
                End If

                ' Construct the SQL UPDATE query
                Dim query As String = "UPDATE deliver SET order_id = @orderID, employee_id = @employeeID, status = @status, customer_id = @customerID WHERE delivery_id = @deliveryID"

                Dim command As New MySqlCommand(query, conn)

                ' Add parameters to the command
                command.Parameters.AddWithValue("@orderID", oror.Text)
                command.Parameters.AddWithValue("@employeeID", empemp.SelectedItem.ToString())
                command.Parameters.AddWithValue("@status", statstatus.SelectedItem.ToString())
                command.Parameters.AddWithValue("@customerID", ComboBox133.SelectedItem.ToString())
                command.Parameters.AddWithValue("@deliveryID", deliveryID)

                ' Execute the query to update the row
                command.ExecuteNonQuery()

                ' Display a success message
                MessageBox.Show("Row updated successfully!")

                ' Refresh DataGridviewmos
                RefreshDataGridview()
            Else
                ' If no row is selected, display an error message
                MessageBox.Show("Please select a row to update.")
            End If
        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error updating row: " & ex.Message)
        Finally
            ' Close the database connection if open
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub RefreshDataGridview()
        Throw New NotImplementedException()
    End Sub

    Private Sub DELETEDEL_Click(sender As Object, e As EventArgs) Handles DELETEDEL.Click
        Try
            ' Check if a row is selected
            If DataGridviewmos.SelectedRows.Count > 0 Then
                ' Get the selected row
                Dim selectedRow As DataGridViewRow = DataGridviewmos.SelectedRows(0)

                ' Get the delivery ID from the selected row
                Dim deliveryID As String = selectedRow.Cells("delivery_id").Value.ToString()

                ' Open the database connection
                If conn.State <> ConnectionState.Open Then
                    conn.Open()
                End If

                ' Construct the SQL DELETE query
                Dim query As String = "DELETE FROM deliver WHERE delivery_id = @deliveryID"

                Dim command As New MySqlCommand(query, conn)

                ' Add parameter to the command
                command.Parameters.AddWithValue("@deliveryID", deliveryID)

                ' Execute the query to delete the row
                command.ExecuteNonQuery()

                ' Display a success message
                MessageBox.Show("Row deleted successfully!")

                ' Refresh DataGridviewmos
                RefreshDataGridviewmos()
            Else
                ' If no row is selected, display an error message
                MessageBox.Show("Please select a row to delete.")
            End If
        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error deleting row: " & ex.Message)
        Finally
            ' Close the database connection if open
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub RefreshDataGridviewmos()
        Throw New NotImplementedException()
    End Sub

    Private Sub DataGridViewform3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewformm33.CellContentClick

    End Sub




    Private Sub preparebut_Click(sender As Object, e As EventArgs) Handles preparebut.Click
        ' Set tabPage22 as the selected tab page
        TabControl1.SelectedTab = TabPage22
    End Sub



    Private Sub View_Click(sender As Object, e As EventArgs) Handles View.Click
        Try
            conn.Open()

            Dim query As String = "SELECT * FROM `order`"
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridViewformm33.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub



    Private Sub DataGridView155_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView155.CellContentClick

    End Sub

    Private Sub view22_Click(sender As Object, e As EventArgs) Handles view22.Click
        Try
            conn.Open()

            Dim query As String = "SELECT * FROM `costumer`"
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView155.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub







    Private Sub ordersno_TextChanged(sender As Object, e As EventArgs) Handles ordersno.TextChanged

    End Sub

    Private Sub daily_TextChanged(sender As Object, e As EventArgs) Handles daily.TextChanged

    End Sub

    Private Sub SAVEPRE_Click(sender As Object, e As EventArgs) Handles SAVEPRE.Click
        Try
            ' Construct the SQL SELECT query
            Dim query As String = "SELECT * FROM prepare"
            conn.Open()

            ' Create MySqlCommand
            Dim command As New MySqlCommand(query, conn)

            ' Execute the query
            Dim reader As MySqlDataReader = command.ExecuteReader()

            ' Create a new SQL file
            Dim filePath As String = "C:\Users\John Isaac C. Obusan\Downloads\prepare_data.sql"
            Dim writer As New StreamWriter(filePath)

            ' Write INSERT statements to SQL file
            While reader.Read()
                Dim insertStatement As String = $"INSERT INTO prepare (order_id, quantity, preparation_date, product_id, employee_id) VALUES ({reader("order_id")}, {reader("quantity")}, '{reader("preparation_date")}', {reader("product_id")}, {reader("employee_id")});"
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



    Private Sub SAVEEE_Click(sender As Object, e As EventArgs) Handles SAVEEE.Click
        Try
            ' Construct the SQL SELECT query
            Dim query As String = "SELECT * FROM deliver"
            conn.Open()

            ' Create MySqlCommand
            Dim command As New MySqlCommand(query, conn)

            ' Execute the query
            Dim reader As MySqlDataReader = command.ExecuteReader()

            ' Create a new SQL file
            Dim filePath As String = "C:\Users\John Isaac C. Obusan\Downloads\deliver_data.sql"
            Dim writer As New StreamWriter(filePath)

            ' Write INSERT statements to SQL file
            While reader.Read()
                Dim insertStatement As String = $"INSERT INTO deliver (delivery_id, order_id, employee_id, stastatus, customer_id) VALUES ('{reader("delivery_id")}', '{reader("order_id")}', '{reader("employee_id")}', '{reader("stastatus")}', '{reader("customer_id")}');"
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
