Public Class Form2

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = Fenetre_Principale.Stng_MP.Text Then
            TextBox1.ForeColor = Color.Green
            Accept.Enabled = True
        Else
            TextBox1.ForeColor = Color.Red
            Accept.Enabled = False
        End If
    End Sub

    Private Sub Accept_Click(sender As Object, e As EventArgs) Handles Accept.Click
        Fenetre_Principale.Verrouillage.Visible = True
        Fenetre_Principale.Verrouillage.BringToFront()
        Me.Close()
    End Sub
End Class