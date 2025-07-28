<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        tabcontro = New TabControl()
        TabPage1 = New TabPage()
        adminlogin = New Button()
        adminpass = New TextBox()
        Adminname = New TextBox()
        TabPage2 = New TabPage()
        customerlogin = New Button()
        customerpass = New TextBox()
        TextBox3 = New TextBox()
        TabPage3 = New TabPage()
        emppass = New TextBox()
        empuser = New TextBox()
        emplogin = New Button()
        tabcontro.SuspendLayout()
        TabPage1.SuspendLayout()
        TabPage2.SuspendLayout()
        TabPage3.SuspendLayout()
        SuspendLayout()
        ' 
        ' tabcontro
        ' 
        tabcontro.Controls.Add(TabPage1)
        tabcontro.Controls.Add(TabPage2)
        tabcontro.Controls.Add(TabPage3)
        tabcontro.Location = New Point(12, 7)
        tabcontro.Name = "tabcontro"
        tabcontro.SelectedIndex = 0
        tabcontro.Size = New Size(299, 246)
        tabcontro.TabIndex = 0
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(adminlogin)
        TabPage1.Controls.Add(adminpass)
        TabPage1.Controls.Add(Adminname)
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(291, 218)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Admin"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' adminlogin
        ' 
        adminlogin.Location = New Point(137, 155)
        adminlogin.Name = "adminlogin"
        adminlogin.Size = New Size(75, 23)
        adminlogin.TabIndex = 2
        adminlogin.Text = "Login"
        adminlogin.UseVisualStyleBackColor = True
        ' 
        ' adminpass
        ' 
        adminpass.Location = New Point(85, 96)
        adminpass.Name = "adminpass"
        adminpass.Size = New Size(185, 23)
        adminpass.TabIndex = 1
        ' 
        ' Adminname
        ' 
        Adminname.Location = New Point(85, 50)
        Adminname.Name = "Adminname"
        Adminname.Size = New Size(185, 23)
        Adminname.TabIndex = 0
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(customerlogin)
        TabPage2.Controls.Add(customerpass)
        TabPage2.Controls.Add(TextBox3)
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(291, 218)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Customer"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' customerlogin
        ' 
        customerlogin.Location = New Point(140, 145)
        customerlogin.Name = "customerlogin"
        customerlogin.Size = New Size(75, 23)
        customerlogin.TabIndex = 2
        customerlogin.Text = "Login"
        customerlogin.UseVisualStyleBackColor = True
        ' 
        ' customerpass
        ' 
        customerpass.Location = New Point(85, 96)
        customerpass.Name = "customerpass"
        customerpass.Size = New Size(189, 23)
        customerpass.TabIndex = 1
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(85, 52)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(189, 23)
        TextBox3.TabIndex = 0
        ' 
        ' TabPage3
        ' 
        TabPage3.Controls.Add(emppass)
        TabPage3.Controls.Add(empuser)
        TabPage3.Controls.Add(emplogin)
        TabPage3.Location = New Point(4, 24)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(3)
        TabPage3.Size = New Size(291, 218)
        TabPage3.TabIndex = 2
        TabPage3.Text = "Employee"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' emppass
        ' 
        emppass.Location = New Point(113, 100)
        emppass.Name = "emppass"
        emppass.Size = New Size(148, 23)
        emppass.TabIndex = 2
        ' 
        ' empuser
        ' 
        empuser.Location = New Point(113, 59)
        empuser.Name = "empuser"
        empuser.Size = New Size(148, 23)
        empuser.TabIndex = 1
        ' 
        ' emplogin
        ' 
        emplogin.Location = New Point(147, 161)
        emplogin.Name = "emplogin"
        emplogin.Size = New Size(75, 23)
        emplogin.TabIndex = 0
        emplogin.Text = "Login"
        emplogin.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(317, 261)
        Controls.Add(tabcontro)
        Name = "Form1"
        Text = "Form1"
        tabcontro.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        TabPage3.ResumeLayout(False)
        TabPage3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents tabcontro As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents adminlogin As Button
    Friend WithEvents adminpass As TextBox
    Friend WithEvents Adminname As TextBox
    Friend WithEvents customerlogin As Button
    Friend WithEvents customerpass As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents emppass As TextBox
    Friend WithEvents empuser As TextBox
    Friend WithEvents emplogin As Button

End Class
