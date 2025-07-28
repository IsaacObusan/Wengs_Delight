Imports System.Globalization
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports MySqlConnector
Imports MySqlConnection = MySql.Data.MySqlClient.MySqlConnection

Public Class Form3
    Private conn As MySqlConnection

    ' Constructor for Form3
    Public Sub New()
        ' Initialize the MySqlConnection object
        conn = New MySqlConnection("server=localhost;username=root;password=;database=wengs_delights2024")
        InitializeComponent()



        ' Load data initially
        LoadData()
    End Sub



    Private Sub LoadData()
        Try
            ' Open the database connection if it's closed
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            ' Query to retrieve costumer IDs from the costumer table
            Dim costumerQuery As String = "SELECT costumer_id FROM costumer"

            ' Clear existing items in custobox1 ComboBox
            custobox132.Items.Clear()

            ' Create a command to execute the costumer query
            Using costumerCommand As New MySql.Data.MySqlClient.MySqlCommand(costumerQuery, conn)
                ' Create a reader to read the results
                Using costumerReader As MySql.Data.MySqlClient.MySqlDataReader = costumerCommand.ExecuteReader()
                    ' Check if there are any rows to read
                    While costumerReader.Read()
                        ' Access the "costumer_id" field and add it to custobox1 ComboBox
                        custobox132.Items.Add(costumerReader("costumer_id").ToString())
                    End While
                End Using
            End Using

            ' Query to retrieve product_id from the product table
            Dim productQuery As String = "SELECT product_id FROM product"

            ' Clear existing items in proidddd ComboBox
            proidddd.Items.Clear()

            ' Create a command to execute the product query
            Using productCommand As New MySql.Data.MySqlClient.MySqlCommand(productQuery, conn)
                ' Create a reader to read the results
                Using productReader As MySql.Data.MySqlClient.MySqlDataReader = productCommand.ExecuteReader()
                    ' Check if there are any rows to read
                    While productReader.Read()
                        ' Access the "product_id" field and add it to proidddd ComboBox
                        proidddd.Items.Add(productReader("product_id").ToString())
                    End While
                End Using
            End Using





            ' Now, let's retrieve the stock information based on a specific product_id
            Dim productId As String = "123456" ' Change this to the desired product ID


            ' Query to retrieve the stock of the specific product ID
            Dim stockQuery As String = "SELECT stock FROM product WHERE product_id = @productId"

            ' Create a command to execute the stock query
            Using stockCommand As New MySql.Data.MySqlClient.MySqlCommand(stockQuery, conn)
                ' Add parameter for productId
                stockCommand.Parameters.AddWithValue("@productId", productId)

                ' Execute the command and retrieve the stock
                Dim stock As Object = stockCommand.ExecuteScalar()

                ' Display the stock in the corresponding TextBox (pasta1)
                pasta1.Text = If(stock IsNot Nothing, stock.ToString(), "Product not found")
            End Using

            ' Retrieve stock information for product ID: 234567 and display it in pasta2 TextBox
            Dim productId2 As String = "234567"
            Dim stockQuery2 As String = "SELECT stock FROM product WHERE product_id = @productId2"
            Using stockCommand2 As New MySql.Data.MySqlClient.MySqlCommand(stockQuery2, conn)
                stockCommand2.Parameters.AddWithValue("@productId2", productId2)
                Dim stock2 As Object = stockCommand2.ExecuteScalar()
                pasta2.Text = If(stock2 IsNot Nothing, stock2.ToString(), "Product not found")
            End Using

            ' Retrieve stock information for product ID: 345678 and display it in pasta3 TextBox
            Dim productId3 As String = "345678"
            Dim stockQuery3 As String = "SELECT stock FROM product WHERE product_id = @productId3"
            Using stockCommand3 As New MySql.Data.MySqlClient.MySqlCommand(stockQuery3, conn)
                stockCommand3.Parameters.AddWithValue("@productId3", productId3)
                Dim stock3 As Object = stockCommand3.ExecuteScalar()
                pasta3.Text = If(stock3 IsNot Nothing, stock3.ToString(), "Product not found")
            End Using

            ' Retrieve stock information for product ID: 456789 and display it in pasta4 TextBox
            Dim productId4 As String = "456789"
            Dim stockQuery4 As String = "SELECT stock FROM product WHERE product_id = @productId4"
            Using stockCommand4 As New MySql.Data.MySqlClient.MySqlCommand(stockQuery4, conn)
                stockCommand4.Parameters.AddWithValue("@productId4", productId4)
                Dim stock4 As Object = stockCommand4.ExecuteScalar()
                pasta4.Text = If(stock4 IsNot Nothing, stock4.ToString(), "Product not found")
            End Using

            ' Retrieve stock information for product ID: 567890 and display it in meal1 TextBox
            Dim productId5 As String = "567890"
            Dim stockQuery5 As String = "SELECT stock FROM product WHERE product_id = @productId5"
            Using stockCommand5 As New MySql.Data.MySqlClient.MySqlCommand(stockQuery5, conn)
                stockCommand5.Parameters.AddWithValue("@productId5", productId5)
                Dim stock5 As Object = stockCommand5.ExecuteScalar()
                meal1.Text = If(stock5 IsNot Nothing, stock5.ToString(), "Product not found")
            End Using

            ' Retrieve stock information for product ID: 678901 and display it in meal2 TextBox
            Dim productId6 As String = "678901"
            Dim stockQuery6 As String = "SELECT stock FROM product WHERE product_id = @productId6"
            Using stockCommand6 As New MySql.Data.MySqlClient.MySqlCommand(stockQuery6, conn)
                stockCommand6.Parameters.AddWithValue("@productId6", productId6)
                Dim stock6 As Object = stockCommand6.ExecuteScalar()
                meal2.Text = If(stock6 IsNot Nothing, stock6.ToString(), "Product not found")
            End Using

            ' Retrieve stock information for product ID: 789012 and display it in meal3 TextBox
            Dim productId7 As String = "789012"
            Dim stockQuery7 As String = "SELECT stock FROM product WHERE product_id = @productId7"
            Using stockCommand7 As New MySql.Data.MySqlClient.MySqlCommand(stockQuery7, conn)
                stockCommand7.Parameters.AddWithValue("@productId7", productId7)
                Dim stock7 As Object = stockCommand7.ExecuteScalar()
                meal3.Text = If(stock7 IsNot Nothing, stock7.ToString(), "Product not found")
            End Using

            ' Retrieve stock information for product ID: 890123 and display it in meal4 TextBox
            Dim productId8 As String = "890123"
            Dim stockQuery8 As String = "SELECT stock FROM product WHERE product_id = @productId8"
            Using stockCommand8 As New MySql.Data.MySqlClient.MySqlCommand(stockQuery8, conn)
                stockCommand8.Parameters.AddWithValue("@productId8", productId8)
                Dim stock8 As Object = stockCommand8.ExecuteScalar()
                meal4.Text = If(stock8 IsNot Nothing, stock8.ToString(), "Product not found")
            End Using

            ' Retrieve stock information for product ID: 901234 and display it in snack1 TextBox
            Dim productId9 As String = "901234"
            Dim stockQuery9 As String = "SELECT stock FROM product WHERE product_id = @productId9"
            Using stockCommand9 As New MySql.Data.MySqlClient.MySqlCommand(stockQuery9, conn)
                stockCommand9.Parameters.AddWithValue("@productId9", productId9)
                Dim stock9 As Object = stockCommand9.ExecuteScalar()
                snack1.Text = If(stock9 IsNot Nothing, stock9.ToString(), "Product not found")
            End Using

            ' Retrieve stock information for product ID: 012345 and display it in snack2 TextBox
            Dim productId10 As String = "012345"
            Dim stockQuery10 As String = "SELECT stock FROM product WHERE product_id = @productId10"
            Using stockCommand10 As New MySql.Data.MySqlClient.MySqlCommand(stockQuery10, conn)
                stockCommand10.Parameters.AddWithValue("@productId10", productId10)
                Dim stock10 As Object = stockCommand10.ExecuteScalar()
                snack2.Text = If(stock10 IsNot Nothing, stock10.ToString(), "Product not found")
            End Using

            ' Retrieve stock information for product ID: 123456 and display it in snack3 TextBox
            Dim productId11 As String = "123450"
            Dim stockQuery11 As String = "SELECT stock FROM product WHERE product_id = @productId11"
            Using stockCommand11 As New MySql.Data.MySqlClient.MySqlCommand(stockQuery11, conn)
                stockCommand11.Parameters.AddWithValue("@productId11", productId11)
                Dim stock11 As Object = stockCommand11.ExecuteScalar()
                snack3.Text = If(stock11 IsNot Nothing, stock11.ToString(), "Product not found")
            End Using

            ' Retrieve stock information for product ID: 234567 and display it in snack4 TextBox
            Dim productId12 As String = "234501"
            Dim stockQuery12 As String = "SELECT stock FROM product WHERE product_id = @productId12"
            Using stockCommand12 As New MySql.Data.MySqlClient.MySqlCommand(stockQuery12, conn)
                stockCommand12.Parameters.AddWithValue("@productId12", productId12)
                Dim stock12 As Object = stockCommand12.ExecuteScalar()
                snack4.Text = If(stock12 IsNot Nothing, stock12.ToString(), "Product not found")
            End Using



        Catch ex As Exception
            ' Handle any exceptions that occur
            MessageBox.Show("Error loading data: " & ex.Message)
        Finally
            ' Close the database connection
            conn.Close()
        End Try

    End Sub





    Private Function productId() As Object
        Throw New NotImplementedException()
    End Function

    Private Sub Orderrr_Click(sender As Object, e As EventArgs) Handles Orderrr.Click


        ' Check if all required textboxes are filled
        If String.IsNullOrEmpty(idorderpasta.Text) OrElse
   custobox132.SelectedItem Is Nothing OrElse
   String.IsNullOrEmpty(quantityyyy.Text) OrElse
   Datedatedatepick.Value = DateTime.MinValue OrElse
   proidddd.SelectedItem Is Nothing OrElse
   methoood.SelectedItem Is Nothing OrElse
   String.IsNullOrEmpty(TextBox23.Text) Then
            MessageBox.Show("Please fill in all required fields.")
            Exit Sub
        End If

        Dim query As String = "INSERT INTO `order` (order_id, customer_id, quantity, order_date, product_id, delivery_method, total_amount) VALUES (@order_id, @customer_id, @quantity, @order_date, @product_id, @delivery_method, @total_amount)"

        Try
            conn.Open()
            Dim command As New MySql.Data.MySqlClient.MySqlCommand(query, conn)

            command.Parameters.AddWithValue("@order_id", Integer.Parse(idorderpasta.Text))
            command.Parameters.AddWithValue("@customer_id", custobox132.SelectedItem.ToString())
            Dim quantityOrdered As Integer = Integer.Parse(quantityyyy.Text)
            command.Parameters.AddWithValue("@quantity", quantityOrdered)
            command.Parameters.AddWithValue("@order_date", Datedatedatepick.Value)
            command.Parameters.AddWithValue("@product_id", proidddd.SelectedItem.ToString())
            command.Parameters.AddWithValue("@delivery_method", methoood.SelectedItem.ToString())
            Dim totalAmount As Decimal = Decimal.Parse(TextBox23.Text)
            command.Parameters.AddWithValue("@total_amount", totalAmount)

            ' Execute the query
            command.ExecuteNonQuery()

            ' Update the stock of the selected product
            Dim updateQuery As String = "UPDATE product SET stock = stock - @quantity WHERE product_id = @product_id"
            Dim updateCommand As New MySql.Data.MySqlClient.MySqlCommand(updateQuery, conn)
            updateCommand.Parameters.AddWithValue("@quantity", quantityOrdered)
            updateCommand.Parameters.AddWithValue("@product_id", proidddd.SelectedItem.ToString())

            updateCommand.ExecuteNonQuery()

            MessageBox.Show("Data inserted successfully!")

            ' Refresh Form3
            RefreshForm3()

        Catch ex As Exception
            MessageBox.Show("Error inserting data: " & ex.Message)
        Finally
            conn.Close()
        End Try
        LoadData()
    End Sub



    Private Sub RefreshForm3()


    End Sub










    Private Sub idorderpasta_TextChanged(sender As Object, e As EventArgs) Handles idorderpasta.TextChanged

    End Sub



    Private Sub proidddd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles proidddd.SelectedIndexChanged

    End Sub

    Private Sub quantityyyy_TextChanged(sender As Object, e As EventArgs) Handles quantityyyy.TextChanged

    End Sub

    Private Sub Datedatedatepick_ValueChanged(sender As Object, e As EventArgs) Handles Datedatedatepick.ValueChanged

    End Sub



    Private Sub methoood_SelectedIndexChanged(sender As Object, e As EventArgs) Handles methoood.SelectedIndexChanged

    End Sub



    Private Sub custoid_TextChanged(sender As Object, e As EventArgs) Handles custoid.TextChanged

    End Sub

    Private Sub lnamecus_TextChanged(sender As Object, e As EventArgs) Handles lnamecus.TextChanged

    End Sub

    Private Sub fnamecus_TextChanged(sender As Object, e As EventArgs) Handles fnamecus.TextChanged

    End Sub

    Private Sub mnamecus_TextChanged(sender As Object, e As EventArgs) Handles mnamecus.TextChanged

    End Sub

    Private Sub Addresscus_TextChanged(sender As Object, e As EventArgs) Handles Addresscus.TextChanged

    End Sub

    Private Sub numbercus_TextChanged(sender As Object, e As EventArgs) Handles numbercus.TextChanged

    End Sub

    Private Sub SAVEY_Click(sender As Object, e As EventArgs) Handles SAVEY.Click

        Try
            If Not String.IsNullOrWhiteSpace(custoid.Text) AndAlso
           Not String.IsNullOrWhiteSpace(lnamecus.Text) AndAlso
           Not String.IsNullOrWhiteSpace(fnamecus.Text) AndAlso
           Not String.IsNullOrWhiteSpace(mnamecus.Text) AndAlso
           Not String.IsNullOrWhiteSpace(Addresscus.Text) AndAlso
           Not String.IsNullOrWhiteSpace(numbercus.Text) Then

                conn.Open()
                Dim query As String = "INSERT INTO costumer (costumer_id, lname, fname, mname, address, contact_num) VALUES (@costumer_id, @lname, @fname, @mname, @address, @contact_num)"
                Dim command As New MySql.Data.MySqlClient.MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@costumer_id", custoid.Text)
                command.Parameters.AddWithValue("@lname", lnamecus.Text)
                command.Parameters.AddWithValue("@fname", fnamecus.Text)
                command.Parameters.AddWithValue("@mname", mnamecus.Text)
                command.Parameters.AddWithValue("@address", Addresscus.Text)
                command.Parameters.AddWithValue("@contact_num", numbercus.Text)
                command.ExecuteNonQuery()

                MessageBox.Show("Data added successfully!")
                custoid.Clear()
                lnamecus.Clear()
                fnamecus.Clear()
                mnamecus.Clear()
                Addresscus.Clear()
                numbercus.Clear()
            Else
                MessageBox.Show("Please fill in all textboxes.")
            End If



        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
        LoadData()
    End Sub



    Private Sub pasta1_TextChanged(sender As Object, e As EventArgs) Handles pasta1.TextChanged
        ' Refresh Form3
        RefreshForm3()
    End Sub

    Private Sub custobox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles custobox132.SelectedIndexChanged

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CALCULATE_Click(sender As Object, e As EventArgs) Handles CALCULATE.Click
        ' Check if a product is selected in proidddd ComboBox before calculating
        If proidddd.SelectedItem IsNot Nothing Then
            Dim productId As String = proidddd.SelectedItem.ToString()

            ' Retrieve the price of the selected product from the database
            Dim price As Decimal = GetProductPrice(productId)

            If price > 0 Then
                ' Parse the quantity entered in quantityyy TextBox
                Dim quantity As Integer
                If Integer.TryParse(quantityyyy.Text, quantity) Then
                    ' Calculate the total
                    Dim total As Decimal = price * quantity
                    ' Show the total in TextBox23
                    TextBox23.Text = total.ToString()
                Else
                    MessageBox.Show("Please enter a valid quantity.")
                End If
            Else
                MessageBox.Show("Price not found for the selected product.")
            End If
        Else
            MessageBox.Show("Please select a product.")
        End If
    End Sub

    Private Function GetProductPrice(productId As String) As Decimal
        Dim price As Decimal = 0
        ' Query to retrieve the price of the selected product
        Dim query As String = "SELECT price FROM product WHERE product_id = @product_id"
        Try
            conn.Open()
            Dim command As New MySql.Data.MySqlClient.MySqlCommand(query, conn)
            command.Parameters.AddWithValue("@product_id", productId)
            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = command.ExecuteReader()
            If reader.Read() Then
                ' Retrieve the price from the database
                price = reader.GetDecimal("price")
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error retrieving price: " & ex.Message)
        Finally
            conn.Close()
        End Try
        Return price
    End Function


    Private Sub TextBox23_TextChanged(sender As Object, e As EventArgs) Handles TextBox23.TextChanged

    End Sub

    Private Sub pstaa_Click(sender As Object, e As EventArgs) Handles pstaa.Click

    End Sub

    Private Sub pasta2_TextChanged(sender As Object, e As EventArgs) Handles pasta2.TextChanged
        ' Refresh Form3
        RefreshForm3()
    End Sub

    Private Sub pasta3_TextChanged(sender As Object, e As EventArgs) Handles pasta3.TextChanged
        ' Refresh Form3
        RefreshForm3()
    End Sub

    Private Sub pasta4_TextChanged(sender As Object, e As EventArgs) Handles pasta4.TextChanged
        ' Refresh Form3
        RefreshForm3()
    End Sub

    Private Sub meal1_TextChanged(sender As Object, e As EventArgs) Handles meal1.TextChanged
        ' Refresh Form3
        RefreshForm3()
    End Sub

    Private Sub meal2_TextChanged(sender As Object, e As EventArgs) Handles meal2.TextChanged
        ' Refresh Form3
        RefreshForm3()
    End Sub

    Private Sub meal4_TextChanged(sender As Object, e As EventArgs) Handles meal4.TextChanged
        ' Refresh Form3
        RefreshForm3()
    End Sub

    Private Sub snack1_TextChanged(sender As Object, e As EventArgs) Handles snack1.TextChanged
        ' Refresh Form3
        RefreshForm3()
    End Sub

    Private Sub snack2_TextChanged(sender As Object, e As EventArgs) Handles snack2.TextChanged
        ' Refresh Form3
        RefreshForm3()
    End Sub

    Private Sub snack3_TextChanged(sender As Object, e As EventArgs) Handles snack3.TextChanged
        ' Refresh Form3
        RefreshForm3()
    End Sub

    Private Sub snack4_TextChanged(sender As Object, e As EventArgs) Handles snack4.TextChanged
        ' Refresh Form3
        RefreshForm3()
    End Sub
End Class
