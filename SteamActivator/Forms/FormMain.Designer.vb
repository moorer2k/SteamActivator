<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
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
        Me.components = New System.ComponentModel.Container()
        Dim NsListViewColumnHeader4 As SLCListView.NSListViewColumnHeader = New SLCListView.NSListViewColumnHeader()
        Dim NsListViewColumnHeader5 As SLCListView.NSListViewColumnHeader = New SLCListView.NSListViewColumnHeader()
        Dim NsListViewColumnHeader6 As SLCListView.NSListViewColumnHeader = New SLCListView.NSListViewColumnHeader()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AlreadyOwnedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteFromListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SlcTheme1 = New SLCTheme()
        Me.opCPMon = New SLCCheckbox()
        Me.labelStatus = New SLCLabel()
        Me.OnActivate = New SLCOnOffBox()
        Me.ButtonParse = New SLCbtn()
        Me.SlcClose1 = New SLCClose()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SlcListView1 = New SLCListView()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SlcTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlreadyOwnedToolStripMenuItem, Me.DeleteFromListToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(156, 48)
        '
        'AlreadyOwnedToolStripMenuItem
        '
        Me.AlreadyOwnedToolStripMenuItem.Name = "AlreadyOwnedToolStripMenuItem"
        Me.AlreadyOwnedToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.AlreadyOwnedToolStripMenuItem.Text = "Already Owned"
        '
        'DeleteFromListToolStripMenuItem
        '
        Me.DeleteFromListToolStripMenuItem.Name = "DeleteFromListToolStripMenuItem"
        Me.DeleteFromListToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.DeleteFromListToolStripMenuItem.Text = "Delete from list"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'SlcTheme1
        '
        Me.SlcTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.SlcTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.SlcTheme1.Controls.Add(Me.opCPMon)
        Me.SlcTheme1.Controls.Add(Me.labelStatus)
        Me.SlcTheme1.Controls.Add(Me.OnActivate)
        Me.SlcTheme1.Controls.Add(Me.ButtonParse)
        Me.SlcTheme1.Controls.Add(Me.SlcClose1)
        Me.SlcTheme1.Controls.Add(Me.ListView1)
        Me.SlcTheme1.Controls.Add(Me.SlcListView1)
        Me.SlcTheme1.Customization = "JRIV/zYjIP82IyD/JRIV/w=="
        Me.SlcTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SlcTheme1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SlcTheme1.Image = Nothing
        Me.SlcTheme1.Location = New System.Drawing.Point(0, 0)
        Me.SlcTheme1.Movable = True
        Me.SlcTheme1.Name = "SlcTheme1"
        Me.SlcTheme1.NoRounding = True
        Me.SlcTheme1.Sizable = False
        Me.SlcTheme1.Size = New System.Drawing.Size(505, 285)
        Me.SlcTheme1.SmartBounds = True
        Me.SlcTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.SlcTheme1.TabIndex = 7
        Me.SlcTheme1.Text = "SteamActivat0r"
        Me.SlcTheme1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.SlcTheme1.Transparent = True
        '
        'opCPMon
        '
        Me.opCPMon.Checked = False
        Me.opCPMon.Location = New System.Drawing.Point(398, 12)
        Me.opCPMon.Name = "opCPMon"
        Me.opCPMon.Size = New System.Drawing.Size(69, 23)
        Me.opCPMon.TabIndex = 14
        Me.opCPMon.Text = "ClipMon"
        '
        'labelStatus
        '
        Me.labelStatus.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.labelStatus.Location = New System.Drawing.Point(175, 249)
        Me.labelStatus.Name = "labelStatus"
        Me.labelStatus.Size = New System.Drawing.Size(156, 14)
        Me.labelStatus.TabIndex = 13
        Me.labelStatus.Text = "Status: Load some keys!"
        '
        'OnActivate
        '
        Me.OnActivate.Checked = False
        Me.OnActivate.Location = New System.Drawing.Point(437, 247)
        Me.OnActivate.MaximumSize = New System.Drawing.Size(56, 24)
        Me.OnActivate.MinimumSize = New System.Drawing.Size(56, 24)
        Me.OnActivate.Name = "OnActivate"
        Me.OnActivate.Size = New System.Drawing.Size(56, 24)
        Me.OnActivate.TabIndex = 12
        Me.OnActivate.Text = "SlcOnOffBox1"
        '
        'ButtonParse
        '
        Me.ButtonParse.Colors = New Bloom(-1) {}
        Me.ButtonParse.Customization = ""
        Me.ButtonParse.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonParse.Image = Nothing
        Me.ButtonParse.Location = New System.Drawing.Point(14, 247)
        Me.ButtonParse.Name = "ButtonParse"
        Me.ButtonParse.NoRounding = False
        Me.ButtonParse.Size = New System.Drawing.Size(66, 24)
        Me.ButtonParse.TabIndex = 7
        Me.ButtonParse.Text = "Load Keys"
        Me.ButtonParse.Transparent = False
        '
        'SlcClose1
        '
        Me.SlcClose1.Colors = New Bloom(-1) {}
        Me.SlcClose1.Customization = ""
        Me.SlcClose1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.SlcClose1.Image = Nothing
        Me.SlcClose1.Location = New System.Drawing.Point(473, 12)
        Me.SlcClose1.Name = "SlcClose1"
        Me.SlcClose1.NoRounding = False
        Me.SlcClose1.Size = New System.Drawing.Size(20, 20)
        Me.SlcClose1.TabIndex = 8
        Me.SlcClose1.Text = "SlcClose1"
        Me.SlcClose1.Transparent = False
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(14, 70)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(479, 171)
        Me.ListView1.TabIndex = 5
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "CDKey"
        Me.ColumnHeader1.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Status"
        Me.ColumnHeader2.Width = 110
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Game"
        Me.ColumnHeader3.Width = 214
        '
        'SlcListView1
        '
        NsListViewColumnHeader4.Text = "CDKey"
        NsListViewColumnHeader4.Width = 150
        NsListViewColumnHeader5.Text = "Status"
        NsListViewColumnHeader5.Width = 110
        NsListViewColumnHeader6.Text = "Game"
        NsListViewColumnHeader6.Width = 100
        Me.SlcListView1.Columns = New SLCListView.NSListViewColumnHeader() {NsListViewColumnHeader4, NsListViewColumnHeader5, NsListViewColumnHeader6}
        Me.SlcListView1.Items = New SLCListView.NSListViewItem(-1) {}
        Me.SlcListView1.Location = New System.Drawing.Point(14, 70)
        Me.SlcListView1.MultiSelect = False
        Me.SlcListView1.Name = "SlcListView1"
        Me.SlcListView1.Size = New System.Drawing.Size(479, 171)
        Me.SlcListView1.TabIndex = 11
        Me.SlcListView1.Text = "SlcListView1"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 285)
        Me.Controls.Add(Me.SlcTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SteamActivat0r"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.SlcTheme1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents SlcTheme1 As SLCTheme
    Friend WithEvents SlcClose1 As SLCClose
    Friend WithEvents ButtonParse As SLCbtn
    Friend WithEvents SlcListView1 As SLCListView
    Friend WithEvents OnActivate As SLCOnOffBox
    Friend WithEvents labelStatus As SLCLabel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AlreadyOwnedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteFromListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents opCPMon As SLCCheckbox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
