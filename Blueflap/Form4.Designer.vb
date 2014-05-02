<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Content = New System.Windows.Forms.TextBox()
        Me.Title = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Gray
        Me.Button1.Location = New System.Drawing.Point(326, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 30)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = " "
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Content
        '
        Me.Content.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Content.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Content.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Blueflap.My.MySettings.Default, "MemoContent", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Content.Font = New System.Drawing.Font("Segoe UI Light", 11.25!)
        Me.Content.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Content.Location = New System.Drawing.Point(12, 48)
        Me.Content.Multiline = True
        Me.Content.Name = "Content"
        Me.Content.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.Content.Size = New System.Drawing.Size(344, 321)
        Me.Content.TabIndex = 2
        Me.Content.Text = Global.Blueflap.My.MySettings.Default.MemoContent
        '
        'Title
        '
        Me.Title.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Title.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Title.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Blueflap.My.MySettings.Default, "MemoTitle", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Title.Font = New System.Drawing.Font("Segoe UI Light", 16.25!)
        Me.Title.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Title.Location = New System.Drawing.Point(12, 13)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(308, 29)
        Me.Title.TabIndex = 1
        Me.Title.Text = Global.Blueflap.My.MySettings.Default.MemoTitle
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(368, 381)
        Me.Controls.Add(Me.Content)
        Me.Controls.Add(Me.Title)
        Me.Controls.Add(Me.Button1)
        Me.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form4"
        Me.Text = "Form4"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Title As System.Windows.Forms.TextBox
    Friend WithEvents Content As System.Windows.Forms.TextBox
End Class
