Public Class LinkConverter
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ED2KLink As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OldMagnet As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NewMagnet As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ConvertMagnet As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ED2KLink = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.OldMagnet = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.NewMagnet = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ConvertMagnet = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ED2KLink
        '
        Me.ED2KLink.Location = New System.Drawing.Point(0, 24)
        Me.ED2KLink.Name = "ED2KLink"
        Me.ED2KLink.Size = New System.Drawing.Size(632, 20)
        Me.ED2KLink.TabIndex = 0
        Me.ED2KLink.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(624, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ED2K Link"
        '
        'OldMagnet
        '
        Me.OldMagnet.Location = New System.Drawing.Point(0, 64)
        Me.OldMagnet.Name = "OldMagnet"
        Me.OldMagnet.Size = New System.Drawing.Size(632, 20)
        Me.OldMagnet.TabIndex = 2
        Me.OldMagnet.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(0, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(624, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Existing Magnet (Optional)"
        '
        'NewMagnet
        '
        Me.NewMagnet.Location = New System.Drawing.Point(0, 112)
        Me.NewMagnet.Name = "NewMagnet"
        Me.NewMagnet.Size = New System.Drawing.Size(632, 20)
        Me.NewMagnet.TabIndex = 4
        Me.NewMagnet.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(0, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(624, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "New Magnet"
        '
        'ConvertMagnet
        '
        Me.ConvertMagnet.Location = New System.Drawing.Point(472, 136)
        Me.ConvertMagnet.Name = "ConvertMagnet"
        Me.ConvertMagnet.Size = New System.Drawing.Size(160, 24)
        Me.ConvertMagnet.TabIndex = 6
        Me.ConvertMagnet.Text = "Convert Magnet"
        '
        'LinkConverter
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(632, 159)
        Me.Controls.Add(Me.ConvertMagnet)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NewMagnet)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.OldMagnet)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ED2KLink)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "LinkConverter"
        Me.Text = "Convert ED2K Links to Magnet"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ConvertMagnet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConvertMagnet.Click
        ED2KLink.Text = Trim(ED2KLink.Text)
        OldMagnet.Text = Trim(OldMagnet.Text)
        Dim OldMagnetTiers() As String
        Dim ED2KTiers() As String = Split(ED2KLink.Text, "|")
        If Not OldMagnet.Text = "" Then
            OldMagnetTiers = Split(OldMagnet.Text, "&")
        End If
        Dim ED2KMagnet As String
        ED2KMagnet = "xt=urn:ed2k:" + ED2KTiers(4)
        If OldMagnet.Text = "" Then
            NewMagnet.Text = "magnet:?" + ED2KMagnet + "&dn=" + ED2KTiers(2)
        Else
            If Microsoft.VisualBasic.Left(OldMagnetTiers(OldMagnetTiers.GetLength(0) - 1), 3) = "dn=" Then
                NewMagnet.Text = OldMagnetTiers(0) + "&" + ED2KMagnet + "&dn=" + ED2KTiers(2)
            Else
                NewMagnet.Text = OldMagnetTiers(0) + "&" + ED2KMagnet + "&dn=" + ED2KTiers(2) + "&" + OldMagnetTiers(OldMagnetTiers.GetLength(0) - 1)
            End If
        End If
    End Sub
End Class
