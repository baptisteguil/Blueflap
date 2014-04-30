Public Class Form1
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub MenuBoutton_Click(sender As Object, e As EventArgs) Handles MenuBoutton.Click
        If volet.Width = 27 Then
            volet.Width = 160
            volet.BackColor = Color.White
        Else
            volet.Width = 27
            volet.BackColor = Color.Black
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim textArray = Adresse.Text.Split(" ")
        If (Adresse.Text.Contains(".") = True And Adresse.Text.Contains(" ") = False And Adresse.Text.Contains(" .") = False And Adresse.Text.Contains(". ") = False) Or textArray(0).Contains(":/") = True Or textArray(0).Contains(":\") Then
            If Adresse.Text.Contains("http://") Or Adresse.Text.Contains("https://") Then
                Web.Source = New Uri(Adresse.Text)
            Else
                Web.Source = New Uri("http://" + Adresse.Text)
            End If
        Else
            If Moteur.Text.Contains("http://") Then
                Web.Source = New Uri(Moteur.Text + Adresse.Text)
            ElseIf Moteur.Text.Contains("https://") Then
                Web.Source = New Uri(Moteur.Text + Adresse.Text)
            Else
                MessageBox.Show("Veuillez vérifier les paramètres du moteur de recherche")
            End If

        End If

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Settings.BringToFront()
        If TextBox3.Text = TextBox2.Text Then
            TextBox2.Enabled = True
        ElseIf TextBox2.Text = "" Then
            TextBox2.Enabled = True
        Else
            TextBox2.Enabled = False
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Navigateur.BringToFront()

        If a.Checked = True Then
            Homee.Visible = True
        Else
            Homee.Visible = False
        End If
        If b.Checked = True Then
            Fighty.Visible = True
        Else
            Fighty.Visible = False
        End If
        If c.Checked = True Then
            Favos.Visible = True
        Else
            Favos.Visible = False
        End If
        If d.Checked = True Then
            Infoss.Visible = True
        Else
            Infoss.Visible = False
        End If
        If el.Checked = True Then
            Locky.Visible = True
        Else
            Locky.Visible = False
        End If
        If f.Checked = True Then
            FullScr.Visible = True
        Else
            FullScr.Visible = False
        End If
        If CheckBox3.Visible = False Then
            CheckBox3.Checked = False
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles label1.SelectedIndexChanged
        If label1.Text = "Google" Then
            Moteur.Text = "http://www.google.fr/#hl=fr&sclient=psy-ab&q="
        ElseIf label1.Text = "Bing" Then
            Moteur.Text = "http://www.bing.com/search?q="

        ElseIf label1.Text = "Yahoo" Then
            Moteur.Text = "http://fr.search.yahoo.com/search;_ylt=Ai38ykBDWJSAxF25NrTnjXxNhJp4?p="

        ElseIf label1.Text = "Youtube" Then
            Moteur.Text = "http://www.youtube.com/results?search_query="

        ElseIf label1.Text = "DuckDuckGo" Then
            Moteur.Text = "http://duckduckgo.com/?q="

        ElseIf label1.Text = "Wikipedia" Then
            Moteur.Text = "http://fr.wikipedia.org/w/index.php?search="
        End If
    End Sub
    Private Sub ActualiserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Refresha.Click
        Dim ignoreCache As Boolean
        ignoreCache = ignoreCache
        Web.Reload(ignoreCache = True)
    End Sub

    Private Sub ArrêterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Stopi.Click
        Web.Stop()
        Refresha.Visible = True
        Stopi.Visible = False
        Loader.Visible = False
    End Sub

    Private Sub PrécédentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrécédentToolStripMenuItem.Click
        Web.GoBack()
    End Sub

    Private Sub SuivantToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuivantToolStripMenuItem.Click
        Web.GoForward()
    End Sub

    Private Sub Awesomium_Windows_Forms_WebControl_DocumentReady(sender As Object, e As Awesomium.Core.UrlEventArgs) Handles Web.DocumentReady
        Adresse.Text = Web.Source.ToString
        Adresse_info.Text = Web.Source.ToString
        If Favoris.Items.Contains(Web.Source.ToString) Then
            Button3.BackColor = Color.Azure
        Else
            Button3.BackColor = Color.White
        End If

        If Web.CanGoBack = True Then
            PrécédentToolStripMenuItem.Enabled = True
        Else
            PrécédentToolStripMenuItem.Enabled = False
        End If
        If Web.CanGoForward = True Then
            SuivantToolStripMenuItem.Enabled = True
        Else
            SuivantToolStripMenuItem.Enabled = False
        End If

        Dim isAvailable As Boolean
        isAvailable = My.Computer.Network.IsAvailable
        If My.Computer.Network.IsAvailable = False Then
            Notif_internet.Visible = True
        Else
            Notif_internet.Visible = False
        End If
        Dim html As String = Web.ExecuteJavascriptWithResult("document.getElementsByTagName('html')[0].innerHTML")
        code_source.Text = html
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CheckBox1.Checked = True Then
            Verrouillage.BringToFront()
        Else
            If bluestart.Checked = True Then
                Homestart.Visible = True
                Homestart.BringToFront()
            Else
                Navigateur.BringToFront()
                Verrouillage.Visible = False
            End If
        End If

        If TextBox1.Text.Contains("http://") Then
            Web.Source = New Uri(TextBox1.Text)
        ElseIf TextBox1.Text.Contains("https://") Then
            Web.Source = New Uri(TextBox1.Text)
        Else
            Web.Source = New Uri("http://google.fr")
            MessageBox.Show("La page d'accueil définie dans les paramètres n'est pas valide")
        End If

        If Volet_settings.Checked = True Then
            volet.Width = 27
            volet.BackColor = Color.Black
        Else
            volet.Width = 27
            volet.Width = 160
            volet.BackColor = Color.White
        End If

        Dim isAvailable As Boolean
        isAvailable = My.Computer.Network.IsAvailable
        If My.Computer.Network.IsAvailable = False Then
            Notif_internet.Visible = True
        Else
            Notif_internet.Visible = False
        End If

        For Each item As String In My.Settings.Bookmarks
            Favoris.Items.Add(item)
        Next
        For Each item As String In My.Settings.Bookmarks
            flop.Items.Add(item)
        Next

        For Each item As String In My.Settings.Historique
            Histor.Items.Add(item)
        Next

        If a.Checked = True Then
            Homee.Visible = True
        Else
            Homee.Visible = False
        End If
        If b.Checked = True Then
            Fighty.Visible = True
        Else
            Fighty.Visible = False
        End If
        If c.Checked = True Then
            Favos.Visible = True
        Else
            Favos.Visible = False
        End If
        If d.Checked = True Then
            Infoss.Visible = True
        Else
            Infoss.Visible = False
        End If
        If el.Checked = True Then
            Locky.Visible = True
        Else
            Locky.Visible = False
        End If
        If f.Checked = True Then
            FullScr.Visible = True
        Else
            FullScr.Visible = False
        End If
        Label14.Left = (Me.Width - Label14.Width) / 2
        loll.Text = System.DateTime.Now.ToString("dddd dd MMMM yyyy")
        loll.Left = (Me.Width - loll.Width) / 2
        Panel4.Left = (Me.Width - Panel4.Width) / 2
        Timess.Text = System.DateTime.Now.ToString("HH:mm")
        Dates.Text = System.DateTime.Now.ToString("dddd dd MMMM yyyy")
        If Not Homestart.Tag = "" Then
            If System.IO.File.Exists(Homestart.Tag) Then
                Dim fileeName As String = System.IO.Path.GetFullPath(Homestart.Tag)
                Homestart.BackgroundImage = Image.FromFile(Homestart.Tag)
                Verrouillage.BackgroundImage = Image.FromFile(Homestart.Tag)
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Contains("http://") Then
            Erreur.Visible = False
        ElseIf TextBox1.Text.Contains("https://") Then
            Erreur.Visible = False
        Else
            Erreur.Visible = True
        End If
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles Homee.Click
        If TextBox1.Text.Contains("http://") Then
            Web.Source = New Uri(TextBox1.Text)
        ElseIf TextBox1.Text.Contains("https://") Then
            Web.Source = New Uri(TextBox1.Text)
        Else
            Web.Source = New Uri("http://google.fr")
            MessageBox.Show("La page d'accueil définie dans les paramètres n'est pas valide")
        End If
    End Sub

    Private Sub Volet_settings_CheckedChanged(sender As Object, e As EventArgs) Handles Volet_settings.CheckedChanged
        If Volet_settings.Checked = True Then
            volet.Width = 27
            volet.BackColor = Color.Black
            CheckBox3.Visible = True
        Else
            volet.Width = 27
            volet.Width = 160
            volet.BackColor = Color.White
            volet.SendToBack()
            CheckBox3.Visible = False
        End If
    End Sub

    Private Sub FullScreenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FullScr.Click
        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Normal
            Me.WindowState = FormWindowState.Maximized
            FullScr.Text = "Mode fenêtre"
        Else
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            Me.WindowState = FormWindowState.Normal
            FullScr.Text = "Plein écran"
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text = TextBox2.Text Then
            CheckBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.ForeColor = Color.Green
        Else
            CheckBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.ForeColor = Color.Red
        End If
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles Locky.Click
        Form2.Show()
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles Infoss.Click
        Page.BringToFront()
        Infoload.Navigate(Web.Source)
    End Sub

    Private Sub Back_info_Click(sender As Object, e As EventArgs) Handles Back_info.Click
        Navigateur.BringToFront()
        Infoload.Navigate("about:blank")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox4.Text = TextBox2.Text Then
            Navigateur.BringToFront()
            Verrouillage.Visible = False
        Else
            WrongMp.Visible = True
        End If

    End Sub
    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            volet.BringToFront()
        Else
            volet.SendToBack()
        End If
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Navigateur.BringToFront()
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles Fighty.Click
        Fight.BringToFront()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If ComboBox1.Text = "Google" Then
            fighter_1.Source = New Uri("http://www.google.fr/#hl=fr&sclient=psy-ab&q=" + TextBox5.Text)

        ElseIf ComboBox1.Text = "Bing" Then
            fighter_1.Source = New Uri("http://www.bing.com/search?q=" + TextBox5.Text)

        ElseIf ComboBox1.Text = "Yahoo" Then
            fighter_1.Source = New Uri("http://fr.search.yahoo.com/search;_ylt=Ai38ykBDWJSAxF25NrTnjXxNhJp4?p=" + TextBox5.Text)

        ElseIf ComboBox1.Text = "DuckDuckGo" Then
            fighter_1.Source = New Uri("http://duckduckgo.com/?q=" + TextBox5.Text)
        End If


        If ComboBox2.Text = "Google" Then
            fighter_2.Source = New Uri("http://www.google.fr/#hl=fr&sclient=psy-ab&q=" + TextBox5.Text)

        ElseIf ComboBox2.Text = "Bing" Then
            fighter_2.Source = New Uri("http://www.bing.com/search?q=" + TextBox5.Text)

        ElseIf ComboBox2.Text = "Yahoo" Then
            fighter_2.Source = New Uri("http://fr.search.yahoo.com/search;_ylt=Ai38ykBDWJSAxF25NrTnjXxNhJp4?p=" + TextBox5.Text)

        ElseIf ComboBox2.Text = "DuckDuckGo" Then
            fighter_2.Source = New Uri("http://duckduckgo.com/?q=" + TextBox5.Text)

        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Me.AcceptButton = Button8
    End Sub
    Private Sub TextBox5_Leave(sender As Object, e As EventArgs) Handles TextBox5.Leave
        Me.AcceptButton = Button1
    End Sub
    Private Sub Recherche_Leave(sender As Object, e As EventArgs)
        Me.AcceptButton = Button1
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Me.AcceptButton = Button6
        WrongMp.Visible = False
    End Sub
    Private Sub TextBox4_Leave(sender As Object, e As EventArgs) Handles TextBox4.Leave
        Me.AcceptButton = Button1
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Code_info.Click
        If code_source.Visible = False Then
            code_source.Visible = True
        Else
            code_source.Visible = False
        End If
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles Infoload.DocumentCompleted
        obtload.Visible = False
        obtlabel.Visible = False
        Save.Visible = True
        Print.Visible = True
    End Sub
    Private Sub Infoload_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles Infoload.Navigating
        obtload.Visible = True
        obtlabel.Visible = True
        Save.Visible = False
        Print.Visible = False
    End Sub

    Private Sub Print_Click(sender As Object, e As EventArgs) Handles Print.Click
        Infoload.ShowPrintPreviewDialog()
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        Infoload.ShowSaveAsDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Notif_add.Visible = True
        If Favoris.Items.Contains(Web.Source.ToString) Then
            Textenotif.Text = "Page déjà dans vos favoris"
        Else
            My.Settings.Bookmarks.Add(Web.Source.ToString)
            Favoris.Items.Clear()
            For Each Item As String In My.Settings.Bookmarks
                Favoris.Items.Add(Item)
            Next
            Button3.BackColor = Color.Azure
            Textenotif.Text = "Page ajoutée aux favoris"
        End If
    End Sub

    Private Sub Favoris_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Favoris.Click
        If Favoris.SelectedItem = "" Then
        Else
            Web.Source = New Uri(Favoris.SelectedItem)
        End If
    End Sub
    Private Sub Favoris_Norif(sender As Object, e As EventArgs) Handles Favoris.DoubleClick
        notif_suppr.Visible = True
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        notif_suppr.Visible = False
    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Button9.Click
        My.Settings.Bookmarks.Remove(Favoris.SelectedItem)
        Favoris.Items.Clear()
        For Each Item As String In My.Settings.Bookmarks
            Favoris.Items.Add(Item)
        Next
        notif_suppr.Visible = False
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles Favos.Click
        If Panel1.Visible = True Then
            Panel1.Visible = False
        Else
            Panel1.Visible = True
        End If
    End Sub

    Private Sub Notif_add_Click(sender As Object, e As EventArgs) Handles Notif_add.Click
        Panel1.Visible = True
        Notif_add.Visible = False
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Notif_add.Visible = False
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Panel1.Visible = False
    End Sub
    Private Sub Awesomium_Windows_Forms_WebControl_Navig(sender As Object, e As Awesomium.Core.UrlEventArgs) Handles Web.LoadingFrame
        Stopi.Visible = True
        Loader.Visible = True
        Refresha.Visible = False
    End Sub

    Private Sub Awesomium_Windows_Forms_WebControl_LoadingFrameComplete(sender As Object, e As Awesomium.Core.FrameEventArgs) Handles Web.LoadingFrameComplete
        Stopi.Visible = False
        Loader.Visible = False
        Refresha.Visible = True
        Titre_info.Text = Web.Title

        If Histor.Items.Contains(Adresse.Text) Then
        Else
            My.Settings.Historique.Add(Adresse.Text)
            Histor.Items.Clear()
            For Each Item As String In My.Settings.Historique
                Histor.Items.Add(Item)
            Next
        End If

    End Sub

    Private Sub Awesomium_Windows_Forms_WebControl_Crashed(sender As Object, e As Awesomium.Core.CrashedEventArgs) Handles Web.Crashed
        MessageBox.Show("Une erreur est survenue, actualisez la page")
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs)
        Process.Start("inetcpl.cpl")
    End Sub
    Private Sub Button13_Click_1(sender As Object, e As EventArgs) Handles Button13.Click
        Process.Start("inetcpl.cpl")
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles Touchkeyb.CheckedChanged
        If Touchkeyb.Checked = True Then
            Form3.Show()
            Homee.Font = New Font("Segoe UI Light", 16)
            PrécédentToolStripMenuItem.Font = New Font("Segoe UI Light", 16)
            SuivantToolStripMenuItem.Font = New Font("Segoe UI Light", 16)
            Stopi.Font = New Font("Segoe UI Light", 16)
            Refresha.Font = New Font("Segoe UI Light", 16)
            Fighty.Font = New Font("Segoe UI Light", 16)
            ToolStripMenuItem3.Font = New Font("Segoe UI Light", 16)
            Infoss.Font = New Font("Segoe UI Light", 16)
            Favos.Font = New Font("Segoe UI Light", 16)
            Locky.Font = New Font("Segoe UI Light", 16)
            FullScr.Font = New Font("Segoe UI Light", 16)
            Adresse.Font = New Font("Segoe UI Light", 13)
            Barre.Height = 40
            Button3.Height = 31
            Button1.Height = 29
            MenuBoutton.Height = 38
        Else
            Form3.Close()
            Homee.Font = New Font("Segoe UI Light", 11)
            PrécédentToolStripMenuItem.Font = New Font("Segoe UI Light", 11)
            SuivantToolStripMenuItem.Font = New Font("Segoe UI Light", 11)
            Stopi.Font = New Font("Segoe UI Light", 11)
            Refresha.Font = New Font("Segoe UI Light", 11)
            Fighty.Font = New Font("Segoe UI Light", 11)
            ToolStripMenuItem3.Font = New Font("Segoe UI Light", 11)
            Infoss.Font = New Font("Segoe UI Light", 11)
            Favos.Font = New Font("Segoe UI Light", 11)
            Locky.Font = New Font("Segoe UI Light", 11)
            FullScr.Font = New Font("Segoe UI Light", 11)
            Adresse.Font = New Font("Microsoft Sans Serif", 8)
            Barre.Height = 27
            Button3.Height = 20
            Button1.Height = 18
            MenuBoutton.Height = 27
        End If
    End Sub

    Private Sub Verrouillage_MouseMove(sender As Object, e As MouseEventArgs) Handles Verrouillage.MouseMove
        Timess.Text = System.DateTime.Now.ToString("HH:mm")
        Dates.Text = System.DateTime.Now.ToString("dddd dd MMMM yyyy")
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        Histor.Visible = True
        Label15.Location = New Point(76, 4)
        Label15.Font = New Font("Segoe UI Light", 16)
        Label15.ForeColor = Color.DeepSkyBlue
        Favs.Location = New Point(10, 6)
        Favs.Font = New Font("Segoe UI Light", 14)
        Favs.ForeColor = Color.Gray
    End Sub

    Private Sub Favs_Click(sender As Object, e As EventArgs) Handles Favs.Click
        Histor.Visible = False
        Label15.Location = New Point(76, 7)
        Label15.Font = New Font("Segoe UI Light", 14)
        Label15.ForeColor = Color.Gray
        Favs.Location = New Point(3, 3)
        Favs.Font = New Font("Segoe UI Light", 16)
        Favs.ForeColor = Color.DeepSkyBlue
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        My.Settings.Historique.Clear()
        Histor.Items.Clear()
    End Sub

    Private Sub Histor_Click(sender As Object, e As EventArgs) Handles Histor.Click
        If Histor.SelectedItem = "" Then
        Else
            Web.Source = New Uri(Histor.SelectedItem)
        End If
    End Sub

    Private Sub Awesomium_Windows_Forms_WebControl_ShowCreatedWebView(sender As Object, e As Awesomium.Core.ShowCreatedWebViewEventArgs) Handles Web.ShowCreatedWebView
        Web.Source = e.TargetURL
    End Sub

    Private Sub Awesomium_Windows_Forms_WebControl_ShowCreatedWebView_1(sender As Object, e As Awesomium.Core.ShowCreatedWebViewEventArgs) Handles fighter_1.ShowCreatedWebView
        fighter_1.Source = e.TargetURL
    End Sub
    Private Sub Awesomium_Windows_Forms_WebControl_ShowCreatedWebView_2(sender As Object, e As Awesomium.Core.ShowCreatedWebViewEventArgs) Handles fighter_2.ShowCreatedWebView
        fighter_2.Source = e.TargetURL
    End Sub

    Private Sub CheckBox2_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Me.WindowState = FormWindowState.Maximized
        Else
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Web.WebSession.ClearCache()
        Web.WebSession.ClearCookies()
    End Sub

    Private Sub volet_MouseHover(sender As Object, e As EventArgs) Handles volet.MouseHover
        If Volet_settings.Checked = True Then
            If CheckBox3.Checked = True Then
                volet.BackColor = Color.White
                volet.Width = 160
            End If
        End If

    End Sub

    Private Sub volet_MouseLeave(sender As Object, e As EventArgs) Handles volet.MouseLeave
        If Volet_settings.Checked = True Then
            If CheckBox3.Checked = True Then
                volet.Width = 27
                volet.BackColor = Color.Black
            End If
        End If
    End Sub


    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If CheckBox3.Visible = False Then
            CheckBox3.Checked = False
        End If
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs)
        Homestart.BringToFront()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        loll.Left = (Me.Width - loll.Width) / 2
        Label14.Left = (Me.Width - Label14.Width) / 2
        Panel4.Left = (Me.Width - Panel4.Width) / 2
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Pop.Visible = True Then
            Pop.Visible = False
        Else
            Pop.Visible = True
        End If
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        Me.AcceptButton = Button15
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        If Moteur.Text.Contains("http://") Then
            Web.Source = New Uri(Moteur.Text + TextBox6.Text)
        ElseIf Moteur.Text.Contains("https://") Then
            Web.Source = New Uri(Moteur.Text + TextBox6.Text)
        Else
            MessageBox.Show("Veuillez vérifier les paramètres du moteur de recherche")
        End If
        Navigateur.BringToFront()
        Homestart.Visible = False
    End Sub

    Private Sub TextBox6_Leave(sender As Object, e As EventArgs) Handles TextBox6.Leave
        Me.AcceptButton = Button1
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim open As New OpenFileDialog()
        open.Filter = "Image Files(*.png; *.jpg; *.bmp)|*.png; *.jpg; *.bmp"
        If open.ShowDialog() = DialogResult.OK Then
            Dim fileName As String = System.IO.Path.GetFullPath(open.FileName)
            Homestart.BackgroundImage = New Bitmap(open.FileName)
            Homestart.Tag = fileName
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        If loll.ForeColor = Color.White Then
            loll.ForeColor = Color.Black
            Button17.Text = "Date : Claire"
        Else
            loll.ForeColor = Color.White
            Button17.Text = "Date : Sombre"
        End If
    End Sub
    Private Sub Flop_SelectedIndexChanged(sender As Object, e As EventArgs) Handles flop.Click
        If flop.SelectedItem = "" Then
        Else
            Web.Source = New Uri(flop.SelectedItem)
            Navigateur.BringToFront()
            Homestart.Visible = False
        End If
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        If Panel5.Visible = False Then
            Panel5.Visible = True
        Else
            Panel5.Visible = False
        End If
    End Sub
    Private Sub AMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub
    Private Sub AMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub
    Private Sub AMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Button20_Click_1(sender As Object, e As EventArgs) Handles Button20.Click
        Navigateur.BringToFront()
        Homestart.Visible = False
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Fight.BringToFront()
        Homestart.Visible = False
    End Sub

    Private Sub Textenotif_Click(sender As Object, e As EventArgs) Handles Textenotif.Click
        Panel1.Visible = True
        Notif_add.Visible = False
    End Sub
End Class
