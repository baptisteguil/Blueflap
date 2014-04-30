Public Class Form2

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = Form1.TextBox2.Text Then
            TextBox1.ForeColor = Color.Green
            Accept.Enabled = True
        Else
            TextBox1.ForeColor = Color.Red
            Accept.Enabled = False
        End If
    End Sub

    Private Sub Accept_Click(sender As Object, e As EventArgs) Handles Accept.Click
        Form1.Verrouillage.Visible = True
        Form1.Verrouillage.BringToFront()
        Me.Close()
    End Sub
End Class