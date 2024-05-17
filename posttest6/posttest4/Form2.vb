Imports MySql.Data.MySqlClient
Public Class Form2
    Sub Kosong()
        TextBox2.Clear()
        TextBox1.Clear()
        TextBox2.Focus()
    End Sub

    Sub isi()
        TextBox2.Clear()
        TextBox2.Focus()
    End Sub

    Sub tampilJenis()
        DataGridView1.Rows.Clear()
        If DataGridView1.Columns.Count = 0 Then
            DataGridView1.Columns.Add("kodeJenisColumn", "Kode Jenis")
            DataGridView1.Columns.Add("jenisColumn", "Jenis")
        End If
        CMD = New MySqlCommand("select * from tbjenis", CONN)
        RD = CMD.ExecuteReader()
        While RD.Read()
            Dim row As New DataGridViewRow()
            row.CreateCells(DataGridView1)
            row.Cells(0).Value = RD("kodeJenis")
            row.Cells(1).Value = RD("jenis")
            DataGridView1.Rows.Add(row)
        End While
        RD.Close()
    End Sub

    Sub aturGrid()
        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 200
        DataGridView1.Columns(0).HeaderText = "Kode Jenis"
        DataGridView1.Columns(1).HeaderText = "Nama Jenis"
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        tampilJenis()
        Kosong()
        'aturGrid()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = Nothing And TextBox1.Text = Nothing Then
            MsgBox("Data Belum Lengkap")
            TextBox1.Focus()
        Else
            CMD = New MySqlCommand("Select * from tbjenis where kodeJenis ='" & TextBox1.Text & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()
            If Not RD.HasRows Then
                RD.Close()
                CMD = New MySqlCommand("insert into tbjenis values('" & TextBox1.Text & "', '" & TextBox2.Text & "')", CONN)
                CMD.ExecuteNonQuery()
                tampilJenis()
                Kosong()
                MsgBox("Simpan Data Sukses!")
                TextBox1.Focus()
            Else
                RD.Close()
                MsgBox("Data Tersebut Sudah Ada")
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        TextBox2.MaxLength = 50
        If e.KeyChar = Chr(13) Then
            TextBox2.Text = UCase(TextBox2.Text)
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = DataGridView1.SelectedRows(0)
            If row.Index < DataGridView1.RowCount And row.Index >= 0 Then
                TextBox1.Text = row.Cells(0).Value
                TextBox2.Text = row.Cells(1).Value
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.Text = Nothing Then
            MsgBox("Kode Jenis belum diisi")
            TextBox1.Focus()
        Else
            Dim ubah As String = "update tbjenis set jenis = '" &
            TextBox2.Text & "' where kodeJenis = '" & TextBox1.Text & "'"
            CMD = New MySqlCommand(ubah, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data berhasil diubah")
            tampilJenis()
            Kosong()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox2.Text = Nothing Then
            MsgBox("Kode Jenis belum diisi")
            TextBox1.Focus()
        Else
            Dim ubah As String = "delete from tbjenis where kodeJenis = '" &
            TextBox1.Text & "'"
            CMD = New MySqlCommand(ubah, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data berhasil dihapus")
            tampilJenis()
            Kosong()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Kosong()
        tampilJenis()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            CMD = New MySqlCommand("select * from tbjenis  where kodeJenis = '" &
            TextBox1.Text & "'", CONN)
            RD = CMD.ExecuteReader()
            RD.Read()
            If RD.HasRows Then
                TextBox2.Text = RD("jenis")
                TextBox2.Focus()
            Else
                isi()
                TextBox2.Focus()
            End If
            RD.Close()
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text <> Nothing Then
            CMD = New MySqlCommand("select * from tbjenis where kodeJenis like '%" & TextBox3.Text & "%'", CONN)
            RD = CMD.ExecuteReader()
            If RD.HasRows Then
                DataGridView1.Rows.Clear()
                While RD.Read()
                    Dim row As New DataGridViewRow()
                    row.CreateCells(DataGridView1)
                    row.Cells(0).Value = RD("kodeJenis")
                    row.Cells(1).Value = RD("jenis")
                    DataGridView1.Rows.Add(row)
                End While
            Else
                MsgBox("Data tidak ditemukan")
            End If
            RD.Close()
        Else
            tampilJenis()
        End If
    End Sub
End Class