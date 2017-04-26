Imports System.IO
Public Class Customers
    Private Structure CustomerDetails
        Public CustomerID As Integer 'The text entered into the txtCustomerID should be a number 
        Public FirstName As String
        Public CustomerEmail As String
        Public SecondName As String                  'Creating the structure that will hold the data.
        Public DOB As String
    End Structure

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim CustomerData As New CustomerDetails
        Dim sw As New System.IO.StreamWriter("customerdetails.txt", True) 'This is showing the location of where we are writing to.
        CustomerData.CustomerID = LSet(txtCustomerID.Text, 50) 'This gives a set size to the text that is being entered into the txtFile 
        CustomerData.FirstName = LSet(txtFirstName.Text, 50)
        CustomerData.CustomerEmail = LSet(txtSecondName.Text, 50)
        CustomerData.SecondName = LSet(txtCustomerEmail.Text, 50)   'Filling the structure with data.


        If txtCustomerID.Text = "" Then MsgBox("Please fill in all the boxes") 'Making sure that each textbox has text within it 
        If txtFirstName.Text = "" Then MsgBox("Please fill in all the boxes")
        If txtSecondName.Text = "" Then MsgBox("Please fill in all the boxes")
        If txtCustomerEmail.Text = "" Then MsgBox("Please fill in all the boxes")


        sw.WriteLine(CustomerData.CustomerID & CustomerData.FirstName & CustomerData.CustomerEmail & CustomerData.SecondName)
        sw.Close()                                                                  'Always need to close the txtFile we have been writing to 
        MsgBox("File Saved!") 'The txtFile will be saved before closing



    End Sub

    Private Sub btnRetrieve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetrieve.Click
        MsgBox("Please enter the CustomerID of the person you are looking for")
        txtFirstName.Visible = False
        txtCustomerEmail.Visible = False
        txtSecondName.Visible = False
        DateTimePicker1.Visible = False

        Dim CountGot As Integer
        CountGot = 0
        Dim CustomerCount As Integer
        CustomerCount = 0


        Dim CustomerData() As String = File.ReadAllLines("customerdetails.txt") 'This Reads every line in the text file.
        For i = 0 To UBound(CustomerData)

            CountGot = 0
            If Trim(Mid(CustomerData(i), 1, 50)) = txtCustomerID.Text And Not txtCustomerID.Text = "" Then CountGot = CountGot + 1
            If Trim(Mid(CustomerData(i), 51, 50)) = txtFirstName.Text And Not txtFirstName.Text = "" Then CountGot = CountGot + 1
            If Trim(Mid(CustomerData(i), 101, 50)) = txtCustomerEmail.Text And Not txtCustomerEmail.Text = "" Then CountGot = CountGot + 1
            If Trim(Mid(CustomerData(i), 151, 50)) = txtSecondName.Text And Not txtSecondName.Text = "" Then CountGot = CountGot + 1 'Counting how many attributes follow the search

            If CountGot > 0 Then CustomerCount = CustomerCount + 1 ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''If attributes match, add to the count.
        Next i
        MsgBox("There is : " & CustomerCount & " Customer Found") 'This lets you know if a certain customers details were found 
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Dir$("customerdetails.txt") = "" Then
            Dim sw As New StreamWriter("customerdetails.txt", True)    'This makes sure there is actually a database to enter/read data. If not, it creates a new blank one.
            sw.WriteLine("")
            sw.Close() 'This closes the SteamWriter
            MsgBox("A new file has been created", vbExclamation, "Warning!") 'This tells you that a new text file has been created.
        End If
    End Sub

    Private Sub txtCustomerID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCustomerID.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            MsgBox("This is not a number")
            e.KeyChar = Nothing     'This does not allow a character to be entered into this textbox 
        End If
    End Sub

    Private Sub txtCustomerName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFirstName.KeyPress
        If IsNumeric(e.KeyChar) Then
            MsgBox("You cannot enter a number into here")
            e.KeyChar = Nothing     'This does not allow a number to be entered into this textbox 
        End If
    End Sub

    Private Sub txtSecondName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSecondName.KeyPress, txtSecondName.KeyPress

        If IsNumeric(e.KeyChar) Then
            MsgBox("You cannot enter a number into here")
            e.KeyChar = Nothing
        End If
    End Sub
End Class
