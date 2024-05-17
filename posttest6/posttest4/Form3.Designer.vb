<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FMenu
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AdministrasiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataProdukToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataJenisProdukToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanProdukToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanDataJenisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeluarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdministrasiToolStripMenuItem, Me.LaporanToolStripMenuItem, Me.KeluarToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(666, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AdministrasiToolStripMenuItem
        '
        Me.AdministrasiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataProdukToolStripMenuItem, Me.DataJenisProdukToolStripMenuItem})
        Me.AdministrasiToolStripMenuItem.Name = "AdministrasiToolStripMenuItem"
        Me.AdministrasiToolStripMenuItem.Size = New System.Drawing.Size(103, 24)
        Me.AdministrasiToolStripMenuItem.Text = "Administrasi"
        '
        'DataProdukToolStripMenuItem
        '
        Me.DataProdukToolStripMenuItem.Name = "DataProdukToolStripMenuItem"
        Me.DataProdukToolStripMenuItem.Size = New System.Drawing.Size(195, 24)
        Me.DataProdukToolStripMenuItem.Text = "Data Produk"
        '
        'DataJenisProdukToolStripMenuItem
        '
        Me.DataJenisProdukToolStripMenuItem.Name = "DataJenisProdukToolStripMenuItem"
        Me.DataJenisProdukToolStripMenuItem.Size = New System.Drawing.Size(195, 24)
        Me.DataJenisProdukToolStripMenuItem.Text = "Data Jenis Produk"
        '
        'LaporanToolStripMenuItem
        '
        Me.LaporanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LaporanProdukToolStripMenuItem, Me.LaporanDataJenisToolStripMenuItem})
        Me.LaporanToolStripMenuItem.Name = "LaporanToolStripMenuItem"
        Me.LaporanToolStripMenuItem.Size = New System.Drawing.Size(75, 24)
        Me.LaporanToolStripMenuItem.Text = "Laporan"
        '
        'LaporanProdukToolStripMenuItem
        '
        Me.LaporanProdukToolStripMenuItem.Name = "LaporanProdukToolStripMenuItem"
        Me.LaporanProdukToolStripMenuItem.Size = New System.Drawing.Size(203, 24)
        Me.LaporanProdukToolStripMenuItem.Text = "Laporan Produk"
        '
        'LaporanDataJenisToolStripMenuItem
        '
        Me.LaporanDataJenisToolStripMenuItem.Name = "LaporanDataJenisToolStripMenuItem"
        Me.LaporanDataJenisToolStripMenuItem.Size = New System.Drawing.Size(203, 24)
        Me.LaporanDataJenisToolStripMenuItem.Text = "Laporan Data Jenis"
        '
        'KeluarToolStripMenuItem
        '
        Me.KeluarToolStripMenuItem.Name = "KeluarToolStripMenuItem"
        Me.KeluarToolStripMenuItem.Size = New System.Drawing.Size(63, 24)
        Me.KeluarToolStripMenuItem.Text = "Keluar"
        '
        'FMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.posttest4.My.Resources.Resources._360_F_571827944_kFJaH7hTykPcCBNa6YDwrOGnIDq8Y2jC
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(666, 541)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FMenu"
        Me.Text = "Form3"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AdministrasiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataProdukToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataJenisProdukToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaporanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaporanProdukToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaporanDataJenisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeluarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
