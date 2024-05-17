Imports MySql.Data.MySqlClient

Public Class Form1
    Sub kosong()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox1.Focus()
    End Sub

    Sub isi()
        TextBox1.Clear()
        TextBox1.Focus()
    End Sub

    Sub TampilData()
        DataGridView1.Rows.Clear()
        CMD = New MySqlCommand("select * from produk", CONN)
        RD = CMD.ExecuteReader()
        While RD.Read()
            Dim row As New DataGridViewRow()
            row.CreateCells(DataGridView1)
            row.Cells(0).Value = RD("ID")
            row.Cells(1).Value = RD("nama_produk")
            row.Cells(2).Value = RD("kodejenis")
            row.Cells(3).Value = RD("harga_produk")
            row.Cells(4).Value = RD("status_stok")
            row.Cells(5).Value = RD("stok_produk")
            row.Cells(6).Value = RD("tag_pro")
            DataGridView1.Rows.Add(row)
        End While
        RD.Close()
    End Sub

    Sub tampilJenis()
        CMD = New MySqlCommand("select jenis from tbjenis", CONN)
        RD = CMD.ExecuteReader
        Do While RD.Read
            cbJenis.Items.Add(RD.Item(0))
        Loop
        RD.Close()
    End Sub

    Sub aturGrid()
        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 200
        DataGridView1.Columns(0).HeaderText = "ID"
        DataGridView1.Columns(1).HeaderText = "Nama"
        DataGridView1.Columns(2).HeaderText = "Jenis"
        DataGridView1.Columns(3).HeaderText = "Harga"
        DataGridView1.Columns(4).HeaderText = "Status Stok"
        DataGridView1.Columns(5).HeaderText = "Stok"
        DataGridView1.Columns(6).HeaderText = "Tag"
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        TampilData()
        kosong()
        'aturGrid()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = Nothing And TextBox4.Text = Nothing Then
            MsgBox("Data belum lengkap")
            TextBox1.Focus()
        Else
            Dim ID As Integer = Integer.Parse(TextBox1.Text)
            Dim Stok As Integer = Integer.Parse(TextBox4.Text)
            Dim StatusStok As String = ""
            For Each control As Control In GroupBox2.Controls
                If TypeOf control Is RadioButton AndAlso DirectCast(control, 
                RadioButton).Checked Then
                    StatusStok &= control.Text & vbCrLf
                End If
            Next
            Dim tag As String = ""
            For Each control As Control In GroupBox1.Controls
                If TypeOf control Is CheckBox AndAlso DirectCast(control, 
                CheckBox).Checked Then
                    tag &= control.Text & vbCrLf
                End If
            Next
            CMD = New MySqlCommand("Select * from produk where ID = '" & ID & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()

            If Not RD.HasRows Then
                RD.Close()
                CMD = New MySqlCommand("insert into produk values ('" & ID & "','" & TextBox2.Text & "','" & cbJenis.Text & "','" & TextBox3.Text & "','" & StatusStok & "','" & Stok & "','" & tag & "')", CONN)
                CMD.ExecuteNonQuery()
                TampilData()
                kosong()
                MsgBox("Simpan Sukses")
                TextBox1.Focus()
            Else
                RD.Close()
                MsgBox("Data Tersebut sudah ada")
            End If
        End If
    End Sub

    Private Sub txtJenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
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
                cbJenis.Text = row.Cells(2).Value
                TextBox3.Text = row.Cells(3).Value
                TextBox4.Text = row.Cells(5).Value
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox2.Text = Nothing Then
            MsgBox("data belum diisi")
            TextBox1.Focus()
        Else
            Dim StatusStok As String = ""
            For Each control As Control In GroupBox2.Controls
                If TypeOf control Is RadioButton AndAlso DirectCast(control, 
                RadioButton).Checked Then
                    StatusStok &= control.Text & vbCrLf
                End If
            Next
            Dim tag As String = ""
            For Each control As Control In GroupBox1.Controls
                If TypeOf control Is CheckBox AndAlso DirectCast(control, 
                CheckBox).Checked Then
                    tag &= control.Text & vbCrLf
                End If
            Next
            Dim ubah As String = "UPDATE produk SET nama_produk = @nama_produk, kodejenis = @tipe_produk, harga_produk = @harga_produk, status_stok = @status_stok, stok_produk = @stok_produk, tag_pro = @tag_pro WHERE ID = @ID"
            Using CMD As New MySqlCommand(ubah, CONN)
                CMD.Parameters.AddWithValue("@nama_produk", TextBox2.Text)
                CMD.Parameters.AddWithValue("@tipe_produk", cbJenis.Text)
                CMD.Parameters.AddWithValue("@harga_produk", TextBox3.Text)
                CMD.Parameters.AddWithValue("@status_stok", StatusStok)
                CMD.Parameters.AddWithValue("@stok_produk", TextBox4.Text)
                CMD.Parameters.AddWithValue("@tag_pro", tag)
                CMD.Parameters.AddWithValue("@ID", TextBox1.Text)

                CMD.ExecuteNonQuery()
            End Using
            MsgBox("Data berhasil diubah")
            TampilData()
            kosong()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.Text = Nothing Then
            MsgBox("ID belum diisi")
            TextBox1.Focus()
        Else
            Dim ubah As String = "delete from produk where ID = '" &
            TextBox1.Text & "'"
            CMD = New MySqlCommand(ubah, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data berhasil dihapus")
            TampilData()
            kosong()
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            CMD = New MySqlCommand("select * from produk  where ID = '" &
            TextBox1.Text & "'", CONN)
            RD = CMD.ExecuteReader()
            RD.Read()
            If RD.HasRows Then
                TextBox2.Text = RD("produk")
                TextBox2.Focus()
            Else
                isi()
                TextBox2.Focus()
            End If
            RD.Close()
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If Not String.IsNullOrEmpty(TextBox5.Text) Then
            Try
                Using CMD As New MySqlCommand("SELECT * FROM produk WHERE nama_produk LIKE @namapro", CONN)
                    CMD.Parameters.AddWithValue("@namapro", "%" & TextBox5.Text & "%")
                    Using RD = CMD.ExecuteReader()
                        DataGridView1.Rows.Clear()
                        While RD.Read()
                            Dim row As New DataGridViewRow()
                            row.CreateCells(DataGridView1)
                            row.Cells(0).Value = RD("ID")
                            row.Cells(1).Value = RD("nama_produk")
                            row.Cells(2).Value = RD("kodejenis")
                            row.Cells(3).Value = RD("harga_produk")
                            row.Cells(4).Value = RD("status_stok")
                            row.Cells(5).Value = RD("stok_produk")
                            row.Cells(6).Value = RD("tag_pro")
                            DataGridView1.Rows.Add(row)
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            End Try
        Else
            TampilData()
        End If
    End Sub
    

End Class