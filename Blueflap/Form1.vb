Public Class Fenetre_Principale
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub MenuBoutton_Click(sender As Object, e As EventArgs) Handles Menu_ShowHide_Button.Click
        If voletlateral.Width = 27 Then
            voletlateral.Width = 160
            voletlateral.BackColor = Color.White
        Else
            voletlateral.Width = 27
            voletlateral.BackColor = Color.Black
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles GoButton.Click
        Dim textArray = SmartAdressbox.Text.Split(" ")
        If (SmartAdressbox.Text.Contains(".") = True And SmartAdressbox.Text.Contains(" ") = False And SmartAdressbox.Text.Contains(" .") = False And SmartAdressbox.Text.Contains(". ") = False) Or textArray(0).Contains(":/") = True Or textArray(0).Contains(":\") Then
            If SmartAdressbox.Text.Contains("http://") Or SmartAdressbox.Text.Contains("https://") Then
                Web.Source = New Uri(SmartAdressbox.Text)
            Else
                Web.Source = New Uri("http://" + SmartAdressbox.Text)
            End If
        Else
            If Stng_MoteurRecherche_URL.Text.Contains("http://") Then
                Web.Source = New Uri(Stng_MoteurRecherche_URL.Text + SmartAdressbox.Text)
            ElseIf Stng_MoteurRecherche_URL.Text.Contains("https://") Then
                Web.Source = New Uri(Stng_MoteurRecherche_URL.Text + SmartAdressbox.Text)
            Else
                MessageBox.Show("Please check settings of the search engine")
            End If

        End If

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles Menu_Settings.Click
        Settings.BringToFront()
        If Stng_MP_confirm.Text = Stng_MP.Text Then
            Stng_MP.Enabled = True
        ElseIf Stng_MP.Text = "" Then
            Stng_MP.Enabled = True
        Else
            Stng_MP.Enabled = False
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Settings_Back.Click
        Navigateur.BringToFront()

        If Home_checkbox.Checked = True Then
            Menu_Home.Visible = True
        Else
            Menu_Home.Visible = False
        End If
        If Sfight_Checkbox.Checked = True Then
            Menu_Fight.Visible = True
        Else
            Menu_Fight.Visible = False
        End If
        If favo_checkbox.Checked = True Then
            Menu_Favos.Visible = True
        Else
            Menu_Favos.Visible = False
        End If
        If share_checkbox.Checked = True Then
            Menu_Share.Visible = True
        Else
            Menu_Share.Visible = False
        End If
        If lock_checkbox.Checked = True Then
            Menu_Lock.Visible = True
        Else
            Menu_Lock.Visible = False
        End If
        If fullscreen_checkbox.Checked = True Then
            Menu_FullScr.Visible = True
        Else
            Menu_FullScr.Visible = False
        End If
        If Stng_Volet_Mousehover_agrandir.Visible = False Then
            Stng_Volet_Mousehover_agrandir.Checked = False
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Stng_MoteurRecherche_choose.SelectedIndexChanged
        If Stng_MoteurRecherche_choose.Text = "Google" Then
            Stng_MoteurRecherche_URL.Text = "http://www.google.fr/#hl=fr&sclient=psy-ab&q="
        ElseIf Stng_MoteurRecherche_choose.Text = "Bing" Then
            Stng_MoteurRecherche_URL.Text = "http://www.bing.com/search?q="

        ElseIf Stng_MoteurRecherche_choose.Text = "Yahoo" Then
            Stng_MoteurRecherche_URL.Text = "http://fr.search.yahoo.com/search;_ylt=Ai38ykBDWJSAxF25NrTnjXxNhJp4?p="

        ElseIf Stng_MoteurRecherche_choose.Text = "Youtube" Then
            Stng_MoteurRecherche_URL.Text = "http://www.youtube.com/results?search_query="

        ElseIf Stng_MoteurRecherche_choose.Text = "DuckDuckGo" Then
            Stng_MoteurRecherche_URL.Text = "http://duckduckgo.com/?q="

        ElseIf Stng_MoteurRecherche_choose.Text = "Wikipedia" Then
            Stng_MoteurRecherche_URL.Text = "http://fr.wikipedia.org/w/index.php?search="
        End If
    End Sub
    Private Sub ActualiserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Menu_Refresh.Click
        Dim ignoreCache As Boolean
        ignoreCache = ignoreCache
        Web.Reload(ignoreCache = True)
    End Sub

    Private Sub ArrêterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Menu_Stop.Click
        Web.Stop()
        Menu_Refresh.Visible = True
        Menu_Stop.Visible = False
        Loader.Visible = False
    End Sub

    Private Sub PrécédentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Menu_Back.Click
        Web.GoBack()
    End Sub

    Private Sub SuivantToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Menu_Forward.Click
        Web.GoForward()
    End Sub

    Private Sub Awesomium_Windows_Forms_WebControl_DocumentReady(sender As Object, e As Awesomium.Core.UrlEventArgs) Handles Web.DocumentReady
        SmartAdressbox.Text = Web.Source.ToString
        Infos_Adresse.Text = Web.Source.ToString
        If Fav_fav_List.Items.Contains(Web.Source.ToString) Then
            AddFavo_Button.BackColor = Color.Azure
        Else
            AddFavo_Button.BackColor = Color.White
        End If

        If Web.CanGoBack = True Then
            Menu_Back.Enabled = True
        Else
            Menu_Back.Enabled = False
        End If
        If Web.CanGoForward = True Then
            Menu_Forward.Enabled = True
        Else
            Menu_Forward.Enabled = False
        End If

        Dim isAvailable As Boolean
        isAvailable = My.Computer.Network.IsAvailable
        If My.Computer.Network.IsAvailable = False Then
            Notif_internet.Visible = True
        Else
            Notif_internet.Visible = False
        End If
        Dim html As String = Web.ExecuteJavascriptWithResult("document.getElementsByTagName('html')[0].innerHTML")
        Infos_code_source.Text = html
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Stng_MPActiv.Checked = True Then
            Verrouillage.BringToFront()
        Else
            If Stng_bluestart_checkbox.Checked = True Then
                Bluestart.Visible = True
                Bluestart.BringToFront()
            Else
                Navigateur.BringToFront()
                Verrouillage.Visible = False
            End If
        End If

        If Stng_HomePage_Url.Text.Contains("http://") Then
            Web.Source = New Uri(Stng_HomePage_Url.Text)
        ElseIf Stng_HomePage_Url.Text.Contains("https://") Then
            Web.Source = New Uri(Stng_HomePage_Url.Text)
        Else
            Web.Source = New Uri("http://google.fr")
            MessageBox.Show("The home page define in the settings aren't valid")
        End If

        If Stng_Volet_reduire.Checked = True Then
            voletlateral.Width = 27
            voletlateral.BackColor = Color.Black
        Else
            voletlateral.Width = 27
            voletlateral.Width = 160
            voletlateral.BackColor = Color.White
        End If

        Dim isAvailable As Boolean
        isAvailable = My.Computer.Network.IsAvailable
        If My.Computer.Network.IsAvailable = False Then
            Notif_internet.Visible = True
        Else
            Notif_internet.Visible = False
        End If

        For Each item As String In My.Settings.Bookmarks
            Fav_fav_List.Items.Add(item)
        Next
        For Each item As String In My.Settings.Bookmarks
            BS_Favlist.Items.Add(item)
        Next

        For Each item As String In My.Settings.Historique
            Fav_Historique_List.Items.Add(item)
        Next

        If Home_checkbox.Checked = True Then
            Menu_Home.Visible = True
        Else
            Menu_Home.Visible = False
        End If
        If Sfight_Checkbox.Checked = True Then
            Menu_Fight.Visible = True
        Else
            Menu_Fight.Visible = False
        End If
        If favo_checkbox.Checked = True Then
            Menu_Favos.Visible = True
        Else
            Menu_Favos.Visible = False
        End If
        If share_checkbox.Checked = True Then
            Menu_Share.Visible = True
        Else
            Menu_Share.Visible = False
        End If
        If lock_checkbox.Checked = True Then
            Menu_Lock.Visible = True
        Else
            Menu_Lock.Visible = False
        End If
        If fullscreen_checkbox.Checked = True Then
            Menu_FullScr.Visible = True
        Else
            Menu_FullScr.Visible = False
        End If
        Label14.Left = (Me.Width - Label14.Width) / 2
        BS_Date.Text = System.DateTime.Now.ToString("dddd dd MMMM yyyy")
        BS_Date.Left = (Me.Width - BS_Date.Width) / 2
        Verr_BlackEffect.Left = (Me.Width - Verr_BlackEffect.Width) / 2
        Verr_Time.Text = System.DateTime.Now.ToString("HH:mm")
        Verr_Date.Text = System.DateTime.Now.ToString("dddd dd MMMM yyyy")
        If Not Bluestart.Tag Is DBNull.Value Then
            If System.IO.File.Exists(Bluestart.Tag) Then
                Dim fileeName As String = System.IO.Path.GetFullPath(Bluestart.Tag)
                Bluestart.BackgroundImage = Image.FromFile(Bluestart.Tag)
                Verrouillage.BackgroundImage = Image.FromFile(Bluestart.Tag)
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Stng_HomePage_Url.TextChanged
        If Stng_HomePage_Url.Text.Contains("http://") Then
            Stng_ErreurURLHomepage.Visible = False
        ElseIf Stng_HomePage_Url.Text.Contains("https://") Then
            Stng_ErreurURLHomepage.Visible = False
        Else
            Stng_ErreurURLHomepage.Visible = True
        End If
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles Menu_Home.Click
        If Stng_bluestart_checkbox.Checked = True Then
            Bluestart.Visible = True
            Bluestart.BringToFront()
        Else
            If Stng_HomePage_Url.Text.Contains("http://") Then
                Web.Source = New Uri(Stng_HomePage_Url.Text)
            ElseIf Stng_HomePage_Url.Text.Contains("https://") Then
                Web.Source = New Uri(Stng_HomePage_Url.Text)
            Else
                Web.Source = New Uri("http://google.fr")
                MessageBox.Show("The home page define in the settings aren't valid")
            End If
        End If
    End Sub

    Private Sub Volet_settings_CheckedChanged(sender As Object, e As EventArgs) Handles Stng_Volet_reduire.CheckedChanged
        If Stng_Volet_reduire.Checked = True Then
            voletlateral.Width = 27
            voletlateral.BackColor = Color.Black
            Stng_Volet_Mousehover_agrandir.Visible = True
        Else
            voletlateral.Width = 27
            voletlateral.Width = 160
            voletlateral.BackColor = Color.White
            voletlateral.SendToBack()
            Stng_Volet_Mousehover_agrandir.Visible = False
        End If
    End Sub

    Private Sub FullScreenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Menu_FullScr.Click
        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Normal
            Me.WindowState = FormWindowState.Maximized
            Menu_FullScr.Text = "Windowed"
        Else
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            Me.WindowState = FormWindowState.Normal
            Menu_FullScr.Text = "Full screen"
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles Stng_MP_confirm.TextChanged
        If Stng_MP_confirm.Text = Stng_MP.Text Then
            Stng_MPActiv.Enabled = True
            Stng_MP.Enabled = True
            Stng_MP_confirm.ForeColor = Color.Green
        Else
            Stng_MPActiv.Enabled = False
            Stng_MP.Enabled = False
            Stng_MP_confirm.ForeColor = Color.Red
        End If
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles Menu_Lock.Click
        Form2.Show()
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles Menu_Share.Click
        Infos.BringToFront()
        Infos_Trident_Browser_Recup_Infos.Navigate(Web.Source)
    End Sub

    Private Sub Back_info_Click(sender As Object, e As EventArgs) Handles Infos_back.Click
        Navigateur.BringToFront()
        Infos_Trident_Browser_Recup_Infos.Navigate("about:blank")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Verr_AcceptButt.Click
        If Verr_Textbox.Text = Stng_MP.Text Then
            Navigateur.BringToFront()
            Verrouillage.Visible = False
        Else
            Verr_WrongMp.Visible = True
        End If

    End Sub
    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles Stng_Volet_Mousehover_agrandir.CheckedChanged
        If Stng_Volet_Mousehover_agrandir.Checked = True Then
            voletlateral.BringToFront()
        Else
            voletlateral.SendToBack()
        End If
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles SrchF_Back.Click
        Navigateur.BringToFront()
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles Menu_Fight.Click
        Fight.BringToFront()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles SrchF_Fightbutton.Click
        If SrchF_ChoixA.Text = "Google" Then
            SrchF_fighter_1.Source = New Uri("http://www.google.fr/#hl=fr&sclient=psy-ab&q=" + SrchF_Searchbox.Text)

        ElseIf SrchF_ChoixA.Text = "Bing" Then
            SrchF_fighter_1.Source = New Uri("http://www.bing.com/search?q=" + SrchF_Searchbox.Text)

        ElseIf SrchF_ChoixA.Text = "Yahoo" Then
            SrchF_fighter_1.Source = New Uri("http://fr.search.yahoo.com/search;_ylt=Ai38ykBDWJSAxF25NrTnjXxNhJp4?p=" + SrchF_Searchbox.Text)

        ElseIf SrchF_ChoixA.Text = "DuckDuckGo" Then
            SrchF_fighter_1.Source = New Uri("http://duckduckgo.com/?q=" + SrchF_Searchbox.Text)
        End If


        If SrchF_ChoixB.Text = "Google" Then
            SrchF_fighter_2.Source = New Uri("http://www.google.fr/#hl=fr&sclient=psy-ab&q=" + SrchF_Searchbox.Text)

        ElseIf SrchF_ChoixB.Text = "Bing" Then
            SrchF_fighter_2.Source = New Uri("http://www.bing.com/search?q=" + SrchF_Searchbox.Text)

        ElseIf SrchF_ChoixB.Text = "Yahoo" Then
            SrchF_fighter_2.Source = New Uri("http://fr.search.yahoo.com/search;_ylt=Ai38ykBDWJSAxF25NrTnjXxNhJp4?p=" + SrchF_Searchbox.Text)

        ElseIf SrchF_ChoixB.Text = "DuckDuckGo" Then
            SrchF_fighter_2.Source = New Uri("http://duckduckgo.com/?q=" + SrchF_Searchbox.Text)

        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles SrchF_Searchbox.TextChanged
        Me.AcceptButton = SrchF_Fightbutton
    End Sub
    Private Sub TextBox5_Leave(sender As Object, e As EventArgs) Handles SrchF_Searchbox.Leave
        Me.AcceptButton = GoButton
    End Sub
    Private Sub Recherche_Leave(sender As Object, e As EventArgs)
        Me.AcceptButton = GoButton
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles Verr_Textbox.TextChanged
        Me.AcceptButton = Verr_AcceptButt
        Verr_WrongMp.Visible = False
    End Sub
    Private Sub TextBox4_Leave(sender As Object, e As EventArgs) Handles Verr_Textbox.Leave
        Me.AcceptButton = GoButton
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Infos_CodeShowHide.Click
        If Infos_code_source.Visible = False Then
            Infos_code_source.Visible = True
        Else
            Infos_code_source.Visible = False
        End If
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles Infos_Trident_Browser_Recup_Infos.DocumentCompleted
        Infos_Loader.Visible = False
        Infos_Loading.Visible = False
        Infos_Save.Visible = True
        Infos_Print.Visible = True
    End Sub
    Private Sub Infoload_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles Infos_Trident_Browser_Recup_Infos.Navigating
        Infos_Loader.Visible = True
        Infos_Loading.Visible = True
        Infos_Save.Visible = False
        Infos_Print.Visible = False
    End Sub

    Private Sub Print_Click(sender As Object, e As EventArgs) Handles Infos_Print.Click
        Infos_Trident_Browser_Recup_Infos.ShowPrintPreviewDialog()
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Infos_Save.Click
        Infos_Trident_Browser_Recup_Infos.ShowSaveAsDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles AddFavo_Button.Click
        Notif_add.Visible = True
        If Fav_fav_List.Items.Contains(Web.Source.ToString) Then
            Textenotif.Text = "Current page already in your favorites"
        Else
            My.Settings.Bookmarks.Add(Web.Source.ToString)
            Fav_fav_List.Items.Clear()
            For Each Item As String In My.Settings.Bookmarks
                Fav_fav_List.Items.Add(Item)
            Next
            AddFavo_Button.BackColor = Color.Azure
            Textenotif.Text = "Current page added in favorites"
        End If
    End Sub

    Private Sub Favoris_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Fav_fav_List.Click
        If Fav_fav_List.SelectedItem = "" Then
        Else
            Web.Source = New Uri(Fav_fav_List.SelectedItem)
        End If
    End Sub
    Private Sub Favoris_Norif(sender As Object, e As EventArgs) Handles Fav_fav_List.DoubleClick
        fav_notif_suppr.Visible = True
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Fav_Cancel.Click
        fav_notif_suppr.Visible = False
    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Fav_Confirm.Click
        My.Settings.Bookmarks.Remove(Fav_fav_List.SelectedItem)
        Fav_fav_List.Items.Clear()
        For Each Item As String In My.Settings.Bookmarks
            Fav_fav_List.Items.Add(Item)
        Next
        fav_notif_suppr.Visible = False
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles Menu_Favos.Click
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

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Notiff_add_OKbutton.Click
        Notif_add.Visible = False
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Fav_Close.Click
        Panel1.Visible = False
    End Sub
    Private Sub Awesomium_Windows_Forms_WebControl_Navig(sender As Object, e As Awesomium.Core.UrlEventArgs) Handles Web.LoadingFrame
        Menu_Stop.Visible = True
        Loader.Visible = True
        Menu_Refresh.Visible = False
    End Sub

    Private Sub Awesomium_Windows_Forms_WebControl_LoadingFrameComplete(sender As Object, e As Awesomium.Core.FrameEventArgs) Handles Web.LoadingFrameComplete
        Menu_Stop.Visible = False
        Loader.Visible = False
        Menu_Refresh.Visible = True
        Infos_Titre.Text = Web.Title

        If Fav_Historique_List.Items.Contains(SmartAdressbox.Text) Then
        Else
            My.Settings.Historique.Add(SmartAdressbox.Text)
            Fav_Historique_List.Items.Clear()
            For Each Item As String In My.Settings.Historique
                Fav_Historique_List.Items.Add(Item)
            Next
        End If

    End Sub

    Private Sub Awesomium_Windows_Forms_WebControl_Crashed(sender As Object, e As Awesomium.Core.CrashedEventArgs) Handles Web.Crashed
        MessageBox.Show("An error has occurred, refresh the page")
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs)
        Process.Start("inetcpl.cpl")
    End Sub
    Private Sub Button13_Click_1(sender As Object, e As EventArgs) Handles Stng_OptionsInternet.Click
        Process.Start("inetcpl.cpl")
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles Stng_TouchUI.CheckedChanged
        If Stng_TouchUI.Checked = True Then
            Form3.Show()
            Menu_Home.Font = New Font("Segoe UI Light", 16)
            Menu_Back.Font = New Font("Segoe UI Light", 16)
            Menu_Forward.Font = New Font("Segoe UI Light", 16)
            Menu_Stop.Font = New Font("Segoe UI Light", 16)
            Menu_Refresh.Font = New Font("Segoe UI Light", 16)
            Menu_Fight.Font = New Font("Segoe UI Light", 16)
            Menu_Settings.Font = New Font("Segoe UI Light", 16)
            Menu_Share.Font = New Font("Segoe UI Light", 16)
            Menu_Favos.Font = New Font("Segoe UI Light", 16)
            Menu_Lock.Font = New Font("Segoe UI Light", 16)
            Menu_FullScr.Font = New Font("Segoe UI Light", 16)
            SmartAdressbox.Font = New Font("Segoe UI Light", 13)
            Barre.Height = 40
            AddFavo_Button.Height = 31
            GoButton.Height = 29
            Menu_ShowHide_Button.Height = 38
        Else
            Form3.Close()
            Menu_Home.Font = New Font("Segoe UI Light", 11)
            Menu_Back.Font = New Font("Segoe UI Light", 11)
            Menu_Forward.Font = New Font("Segoe UI Light", 11)
            Menu_Stop.Font = New Font("Segoe UI Light", 11)
            Menu_Refresh.Font = New Font("Segoe UI Light", 11)
            Menu_Fight.Font = New Font("Segoe UI Light", 11)
            Menu_Settings.Font = New Font("Segoe UI Light", 11)
            Menu_Share.Font = New Font("Segoe UI Light", 11)
            Menu_Favos.Font = New Font("Segoe UI Light", 11)
            Menu_Lock.Font = New Font("Segoe UI Light", 11)
            Menu_FullScr.Font = New Font("Segoe UI Light", 11)
            SmartAdressbox.Font = New Font("Microsoft Sans Serif", 8)
            Barre.Height = 27
            AddFavo_Button.Height = 20
            GoButton.Height = 18
            Menu_ShowHide_Button.Height = 27
        End If
    End Sub

    Private Sub Verrouillage_MouseMove(sender As Object, e As MouseEventArgs) Handles Verrouillage.MouseMove
        Verr_Time.Text = System.DateTime.Now.ToString("HH:mm")
        Verr_Date.Text = System.DateTime.Now.ToString("dddd dd MMMM yyyy")
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles fav_Historique.Click
        Fav_Historique_List.Visible = True
        fav_Historique.Location = New Point(76, 4)
        fav_Historique.Font = New Font("Segoe UI Light", 16)
        fav_Historique.ForeColor = Color.DeepSkyBlue
        Fav_Favoris.Location = New Point(10, 6)
        Fav_Favoris.Font = New Font("Segoe UI Light", 14)
        Fav_Favoris.ForeColor = Color.Gray
    End Sub

    Private Sub Favs_Click(sender As Object, e As EventArgs) Handles Fav_Favoris.Click
        Fav_Historique_List.Visible = False
        fav_Historique.Location = New Point(76, 7)
        fav_Historique.Font = New Font("Segoe UI Light", 14)
        fav_Historique.ForeColor = Color.Gray
        Fav_Favoris.Location = New Point(3, 3)
        Fav_Favoris.Font = New Font("Segoe UI Light", 16)
        Fav_Favoris.ForeColor = Color.DeepSkyBlue
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Stng_SupprHisto.Click
        My.Settings.Historique.Clear()
        Fav_Historique_List.Items.Clear()
    End Sub

    Private Sub Histor_Click(sender As Object, e As EventArgs) Handles Fav_Historique_List.Click
        If Fav_Historique_List.SelectedItem = "" Then
        Else
            Web.Source = New Uri(Fav_Historique_List.SelectedItem)
        End If
    End Sub

    Private Sub Awesomium_Windows_Forms_WebControl_ShowCreatedWebView(sender As Object, e As Awesomium.Core.ShowCreatedWebViewEventArgs) Handles Web.ShowCreatedWebView
        Web.Source = e.TargetURL
    End Sub

    Private Sub Awesomium_Windows_Forms_WebControl_ShowCreatedWebView_1(sender As Object, e As Awesomium.Core.ShowCreatedWebViewEventArgs) Handles SrchF_fighter_1.ShowCreatedWebView
        SrchF_fighter_1.Source = e.TargetURL
    End Sub
    Private Sub Awesomium_Windows_Forms_WebControl_ShowCreatedWebView_2(sender As Object, e As Awesomium.Core.ShowCreatedWebViewEventArgs) Handles SrchF_fighter_2.ShowCreatedWebView
        SrchF_fighter_2.Source = e.TargetURL
    End Sub

    Private Sub CheckBox2_CheckedChanged_1(sender As Object, e As EventArgs) Handles Stng_MaximizedWindow.CheckedChanged
        If Stng_MaximizedWindow.Checked = True Then
            Me.WindowState = FormWindowState.Maximized
        Else
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Stng_SupprCacheCookies.Click
        Web.WebSession.ClearCache()
        Web.WebSession.ClearCookies()
    End Sub

    Private Sub volet_MouseHover(sender As Object, e As EventArgs) Handles voletlateral.MouseHover
        If Stng_Volet_reduire.Checked = True Then
            If Stng_Volet_Mousehover_agrandir.Checked = True Then
                voletlateral.BackColor = Color.White
                voletlateral.Width = 160
            End If
        End If

    End Sub

    Private Sub volet_MouseLeave(sender As Object, e As EventArgs) Handles voletlateral.MouseLeave
        If Stng_Volet_reduire.Checked = True Then
            If Stng_Volet_Mousehover_agrandir.Checked = True Then
                voletlateral.Width = 27
                voletlateral.BackColor = Color.Black
            End If
        End If
    End Sub


    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Stng_Volet_Mousehover_agrandir.Visible = False Then
            Stng_Volet_Mousehover_agrandir.Checked = False
        End If
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs)
        Bluestart.BringToFront()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        BS_Date.Left = (Me.Width - BS_Date.Width) / 2
        Label14.Left = (Me.Width - Label14.Width) / 2
        Verr_BlackEffect.Left = (Me.Width - Verr_BlackEffect.Width) / 2
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles BS_Settings.Click
        If Pop.Visible = True Then
            Pop.Visible = False
        Else
            Pop.Visible = True
        End If
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles Bs_Searchbox.TextChanged
        Me.AcceptButton = BS_Searchbutton
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles BS_Searchbutton.Click
        If Stng_MoteurRecherche_URL.Text.Contains("http://") Then
            Web.Source = New Uri(Stng_MoteurRecherche_URL.Text + Bs_Searchbox.Text)
        ElseIf Stng_MoteurRecherche_URL.Text.Contains("https://") Then
            Web.Source = New Uri(Stng_MoteurRecherche_URL.Text + Bs_Searchbox.Text)
        Else
            MessageBox.Show("Please chek the settings of the search engine")
        End If
        Navigateur.BringToFront()
        Bluestart.Visible = False
    End Sub

    Private Sub TextBox6_Leave(sender As Object, e As EventArgs) Handles Bs_Searchbox.Leave
        Me.AcceptButton = GoButton
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles BS_ImgChoose.Click
        Dim open As New OpenFileDialog()
        open.Filter = "Image Files(*.png; *.jpg; *.bmp)|*.png; *.jpg; *.bmp"
        If open.ShowDialog() = DialogResult.OK Then
            Dim fileName As String = System.IO.Path.GetFullPath(open.FileName)
            Bluestart.BackgroundImage = New Bitmap(open.FileName)
            Bluestart.Tag = fileName
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles BS_DateSetColor.Click
        If BS_Date.ForeColor = Color.White Then
            BS_Date.ForeColor = Color.Black
            BS_DateSetColor.Text = "Date : Light"
        Else
            BS_Date.ForeColor = Color.White
            BS_DateSetColor.Text = "Date : Dark"
        End If
    End Sub
    Private Sub Flop_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BS_Favlist.Click
        If BS_Favlist.SelectedItem = "" Then
        Else
            Web.Source = New Uri(BS_Favlist.SelectedItem)
            Navigateur.BringToFront()
            Bluestart.Visible = False
        End If
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles BS_Fav.Click
        If Bs_Favbulle.Visible = False Then
            Bs_Favbulle.Visible = True
        Else
            Bs_Favbulle.Visible = False
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

    Private Sub Button20_Click_1(sender As Object, e As EventArgs) Handles BS_Browser.Click
        Navigateur.BringToFront()
        Bluestart.Visible = False
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles BS_Searchfight.Click
        Fight.BringToFront()
        Bluestart.Visible = False
    End Sub

    Private Sub Textenotif_Click(sender As Object, e As EventArgs) Handles Textenotif.Click
        Panel1.Visible = True
        Notif_add.Visible = False
    End Sub

    Private Sub Stng_ShowLicense_Click(sender As Object, e As EventArgs) Handles Stng_ShowLicense.Click
        Licence.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Process.Start("http://blueflap.weebly.com/help")
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles stng_simpleworld.Click
        Process.Start("http://simpleworld-website.weebly.com")
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles stng_github.Click
        Process.Start("https://github.com/SimpleSoftwares/Blueflap")
    End Sub

    Private Sub stng_More_Click(sender As Object, e As EventArgs) Handles stng_More.Click
        If Label2.Visible = True Then
            LineShape2.Visible = False
            Label2.Visible = False
            stng_simpleworld.Visible = False
            stng_github.Visible = False
            Label10.Visible = False
            stng_More.Text = "More ..."
        Else
            LineShape2.Visible = True
            Label2.Visible = True
            stng_simpleworld.Visible = True
            stng_github.Visible = True
            Label10.Visible = True
            stng_More.Text = "Less"
        End If
    End Sub

    Private Sub Menu_Memo_Click(sender As Object, e As EventArgs) Handles Menu_Memo.Click
        Form4.Show()
    End Sub
End Class
