<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.UserBox = New System.Windows.Forms.TextBox()
        Me.PassBox = New System.Windows.Forms.TextBox()
        Me.AllInOne = New System.Windows.Forms.Button()
        Me.NewPic = New System.Windows.Forms.PictureBox()
        Me.Hi = New System.Windows.Forms.Panel()
        Me.P4 = New System.Windows.Forms.Splitter()
        Me.P3 = New System.Windows.Forms.Splitter()
        Me.P2 = New System.Windows.Forms.Splitter()
        Me.P1 = New System.Windows.Forms.Splitter()
        Me.PicListBox = New System.Windows.Forms.ListBox()
        Me.Counter = New System.Windows.Forms.Label()
        CType(Me.NewPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Hi.SuspendLayout()
        Me.SuspendLayout()
        '
        'UserBox
        '
        Me.UserBox.ForeColor = System.Drawing.Color.Gray
        Me.UserBox.Location = New System.Drawing.Point(12, 11)
        Me.UserBox.Name = "UserBox"
        Me.UserBox.Size = New System.Drawing.Size(50, 20)
        Me.UserBox.TabIndex = 0
        Me.UserBox.Text = "User"
        Me.UserBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PassBox
        '
        Me.PassBox.ForeColor = System.Drawing.Color.Gray
        Me.PassBox.Location = New System.Drawing.Point(61, 11)
        Me.PassBox.Name = "PassBox"
        Me.PassBox.Size = New System.Drawing.Size(50, 20)
        Me.PassBox.TabIndex = 1
        Me.PassBox.Text = "Pass"
        Me.PassBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.PassBox.UseSystemPasswordChar = True
        '
        'AllInOne
        '
        Me.AllInOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AllInOne.ForeColor = System.Drawing.Color.Gray
        Me.AllInOne.Location = New System.Drawing.Point(12, 30)
        Me.AllInOne.Name = "AllInOne"
        Me.AllInOne.Size = New System.Drawing.Size(99, 23)
        Me.AllInOne.TabIndex = 2
        Me.AllInOne.Text = "Login"
        Me.AllInOne.UseVisualStyleBackColor = True
        '
        'NewPic
        '
        Me.NewPic.Location = New System.Drawing.Point(0, 0)
        Me.NewPic.Name = "NewPic"
        Me.NewPic.Size = New System.Drawing.Size(145, 97)
        Me.NewPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.NewPic.TabIndex = 4
        Me.NewPic.TabStop = False
        '
        'Hi
        '
        Me.Hi.Controls.Add(Me.Counter)
        Me.Hi.Controls.Add(Me.P4)
        Me.Hi.Controls.Add(Me.P3)
        Me.Hi.Controls.Add(Me.P2)
        Me.Hi.Controls.Add(Me.P1)
        Me.Hi.Controls.Add(Me.NewPic)
        Me.Hi.Location = New System.Drawing.Point(119, 11)
        Me.Hi.Name = "Hi"
        Me.Hi.Size = New System.Drawing.Size(145, 97)
        Me.Hi.TabIndex = 5
        '
        'P4
        '
        Me.P4.BackColor = System.Drawing.Color.Black
        Me.P4.Cursor = System.Windows.Forms.Cursors.Default
        Me.P4.Dock = System.Windows.Forms.DockStyle.Right
        Me.P4.Location = New System.Drawing.Point(144, 1)
        Me.P4.Name = "P4"
        Me.P4.Size = New System.Drawing.Size(1, 95)
        Me.P4.TabIndex = 3
        Me.P4.TabStop = False
        '
        'P3
        '
        Me.P3.BackColor = System.Drawing.Color.Black
        Me.P3.Cursor = System.Windows.Forms.Cursors.Default
        Me.P3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.P3.Location = New System.Drawing.Point(1, 96)
        Me.P3.Name = "P3"
        Me.P3.Size = New System.Drawing.Size(144, 1)
        Me.P3.TabIndex = 2
        Me.P3.TabStop = False
        '
        'P2
        '
        Me.P2.BackColor = System.Drawing.Color.Black
        Me.P2.Cursor = System.Windows.Forms.Cursors.Default
        Me.P2.Dock = System.Windows.Forms.DockStyle.Top
        Me.P2.Location = New System.Drawing.Point(1, 0)
        Me.P2.Name = "P2"
        Me.P2.Size = New System.Drawing.Size(144, 1)
        Me.P2.TabIndex = 1
        Me.P2.TabStop = False
        '
        'P1
        '
        Me.P1.BackColor = System.Drawing.Color.Black
        Me.P1.Cursor = System.Windows.Forms.Cursors.Default
        Me.P1.Location = New System.Drawing.Point(0, 0)
        Me.P1.Name = "P1"
        Me.P1.Size = New System.Drawing.Size(1, 97)
        Me.P1.TabIndex = 0
        Me.P1.TabStop = False
        '
        'PicListBox
        '
        Me.PicListBox.FormattingEnabled = True
        Me.PicListBox.Location = New System.Drawing.Point(12, 52)
        Me.PicListBox.Name = "PicListBox"
        Me.PicListBox.Size = New System.Drawing.Size(99, 56)
        Me.PicListBox.TabIndex = 6
        '
        'Counter
        '
        Me.Counter.AutoSize = True
        Me.Counter.BackColor = System.Drawing.Color.Transparent
        Me.Counter.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Counter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Counter.Location = New System.Drawing.Point(58, 81)
        Me.Counter.Name = "Counter"
        Me.Counter.Size = New System.Drawing.Size(28, 13)
        Me.Counter.TabIndex = 5
        Me.Counter.Text = "0|0"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(277, 121)
        Me.Controls.Add(Me.PicListBox)
        Me.Controls.Add(Me.Hi)
        Me.Controls.Add(Me.AllInOne)
        Me.Controls.Add(Me.PassBox)
        Me.Controls.Add(Me.UserBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IG-Pic-Changer"
        CType(Me.NewPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Hi.ResumeLayout(False)
        Me.Hi.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UserBox As TextBox
    Friend WithEvents PassBox As TextBox
    Friend WithEvents AllInOne As Button
    Friend WithEvents NewPic As PictureBox
    Friend WithEvents Hi As Panel
    Friend WithEvents P4 As Splitter
    Friend WithEvents P3 As Splitter
    Friend WithEvents P2 As Splitter
    Friend WithEvents P1 As Splitter
    Friend WithEvents PicListBox As ListBox
    Friend WithEvents Counter As Label
End Class
