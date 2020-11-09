Imports System.Net, System.Text.RegularExpressions, System.IO

Public Class Form1
#Region "Publics"
    Public FullCookie As String : Public Bool As Boolean
    Public G As String = "0" : Public B As String = "0"
#End Region
#Region "Controls"
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Microsoft.VisualBasic.CompilerServices.ProjectData.EndApp() 'Due To We Have Loop And Thread Deamon Started We Must Exit All Opreations
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False 'Analyze Cross Thread Calls In Form :) Caused By Controls
        ServicePointManager.UseNagleAlgorithm = False 'Analyze Internet :)
        ServicePointManager.Expect100Continue = False 'Analyze Internet :)
        Dim DirFolder As New DirectoryInfo("Pics/") 'Get Directory Of The Folder To Get *Pics Names
        Dim Dir2 As FileInfo() = DirFolder.GetFiles()
        For Each FileName In Dir2
            PicListBox.Items.Add("Pics/" + FileName.ToString())
        Next
    End Sub
    Private Sub AllInOne_Click(sender As Object, e As EventArgs) Handles AllInOne.Click
        If AllInOne.Text = "Login" Then
            Dim T As Threading.Thread = New Threading.Thread(Sub()
                                                                 Dim LoginResp As String = Login(UserBox.Text, PassBox.Text)
                                                                 If LoginResp.Contains("""authenticated"": true, """) Then MsgBox("Done Login") : AllInOne.Text = "Start" Else MsgBox($"Error Login Reason Is : {vbCrLf}{LoginResp}")
                                                             End Sub) With {
                                                         .IsBackground = False
                                                         } : T.Start()
        ElseIf AllInOne.Text = "Start" Then
            PicListBox.SelectedIndex = 0 : Me.Bool = False
            Dim T As Threading.Thread = New Threading.Thread(New Threading.ThreadStart(AddressOf Work)) With {
                                                             .IsBackground = False} : T.Start() : AllInOne.Text = "Stop"
        ElseIf AllInOne.Text = "Stop" Then
            AllInOne.Text = "Start" : Me.Bool = True
        End If
    End Sub
    Sub Work()
        While Not Me.Bool
            Dim ImgFile As String = PicListBox.SelectedItem : NewPic.Image = Image.FromFile(ImgFile)
            Dim ImgBytes() As Byte = File.ReadAllBytes(ImgFile)
            If Change(System.Text.Encoding.Default.GetString(ImgBytes)) Then
                G += 1 : Counter.Text = $"{G}|{B}" : Try : PicListBox.SelectedIndex += 1 : Catch ex As Exception : PicListBox.SelectedIndex = 0 : End Try
            Else : B += 1 : Counter.Text = $"{G}|{B}" : Try : PicListBox.SelectedIndex += 1 : Catch ex As Exception : PicListBox.SelectedIndex = 0 : End Try : End If
            Threading.Thread.Sleep(New Random().Next(2, 9))
        End While
    End Sub
#End Region
#Region "AJAX Connections"
    Private Function Login(User As String, Pass As String) As String
        Dim Resp As String = ""
        Try : Net.ServicePointManager.CheckCertificateRevocationList = False : Net.ServicePointManager.DefaultConnectionLimit = 300 : Net.ServicePointManager.UseNagleAlgorithm = False : Net.ServicePointManager.Expect100Continue = False : Net.ServicePointManager.SecurityProtocol = 3072
            Dim Encoding As New Text.UTF8Encoding
            Dim Bytes As Byte() = Encoding.GetBytes("username=" + User + "&enc_password=#PWD_INSTAGRAM_BROWSER:0:0000000000:" + Pass + "&queryParams={}&optIntoOneTap=false")
            Dim AJ As Net.HttpWebRequest = DirectCast(Net.WebRequest.Create("https://www.instagram.com/accounts/login/ajax/"), Net.HttpWebRequest)
            With AJ
                .Method = "POST"
                .Accept = "*/*"
                .AutomaticDecompression = Net.DecompressionMethods.Deflate Or Net.DecompressionMethods.GZip
                .Headers.Add("Accept-Language: en-US,en;q=0.9,ar-EG;q=0.8,ar;q=0.7,bas-CM;q=0.6,bas;q=0.5")
                .KeepAlive = True
                .ContentLength = Bytes.Length
                .ContentType = "application/x-www-form-urlencoded"
                .Headers.Add("Cookie: mid=missing; csrftoken=missing;")
                .Host = "www.instagram.com"
                .UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.183 Safari/537.36"
                .Headers.Add("X-CSRFToken: missing")
                .Headers.Add("X-IG-App-ID: 936619743392459")
                .Headers.Add("X-Instagram-AJAX: b9c0ea6d7d91-hot")
                .Headers.Add("X-Requested-With: XMLHttpRequest")
            End With
            Dim Stream As IO.Stream = AJ.GetRequestStream() : Stream.Write(Bytes, 0, Bytes.Length) : Stream.Dispose() : Stream.Close()
            Dim Reader As New IO.StreamReader(DirectCast(AJ.GetResponse(), Net.HttpWebResponse).GetResponseStream()) : Resp = Reader.ReadToEnd : Reader.Dispose() : Reader.Close()
            Dim CookieGrab As HttpWebResponse = DirectCast(AJ.GetResponse(), HttpWebResponse)
            Dim RegexSetting As String = CookieGrab.GetResponseHeader("Set-Cookie")
            If Resp.Contains("""authenticated"": true, """) Then
#Region "Cookies"
                Dim Csrftoken As String = New Regex("csrftoken=(.*?);").Match(RegexSetting).Groups(1).Value
                Dim Mid As String = New Regex("mid=(.*?);").Match(RegexSetting).Groups(1).Value
                Dim Rur As String = New Regex("rur=(.*?);").Match(RegexSetting).Groups(1).Value
                Dim SessionId As String = New Regex("sessionid=(.*?);").Match(RegexSetting).Groups(1).Value
                Dim DsUserId As String = New Regex("ds_user_id=(.*?);").Match(RegexSetting).Groups(1).Value
                Dim DsUser As String = New Regex("ds_user=(.*?);").Match(RegexSetting).Groups(1).Value
                Dim igdid As String = New Regex("ig_did=(.*?);").Match(RegexSetting).Groups(1).Value
#End Region
                FullCookie = "is_starred_enabled=yes; sessionid=" + SessionId + "; mid=" + Mid + "; ds_user=" + DsUser + "; ds_user_id=" + DsUserId + "; csrftoken=" + Csrftoken + "; igfl=" + DsUser + "; ig_direct_region_hint=" + Rur + "; rur=" + Rur + ";"
            End If
        Catch ex As WebException
            Resp = New IO.StreamReader(ex.Response.GetResponseStream()).ReadToEnd()
        End Try
        Return Resp
    End Function
    Private Function Change(PictureBytesConvert As String) As Boolean
        Dim IsPosted As Boolean = False
        Try
#Region "Bytes Solver"
            Dim Boundary As String = DateTime.Now.Ticks.ToString("x") 'Get Form Boundary 
            Dim PostDataSB As New Text.StringBuilder() 'Build The Right Data In Lines Format So Must Use .AppendLine Not .Append
            PostDataSB.AppendLine($"------WebKitFormBoundary{Boundary}") '1st Line
            PostDataSB.AppendLine("Content-Disposition: form-data; name=""profile_pic""; filename=""profilepic.jpg""") '2nd Line
            PostDataSB.AppendLine("Content-Type: image/jpeg") '3rd Line
            PostDataSB.AppendLine(String.Empty) 'Make Space
            PostDataSB.AppendLine(PictureBytesConvert) 'Get PictureBytes In .Default Encoding **If You Use UTF8 Status Code Will Be 408
            PostDataSB.AppendLine($"------WebKitFormBoundary{Boundary}--") 'Append Last Line :)
            Dim Bytes As Byte() = System.Text.Encoding.Default.GetBytes(PostDataSB.ToString()) 'Get All Data Have Appended In StringBuilder
#End Region
            Dim AJ As Net.HttpWebRequest = Net.WebRequest.CreateHttp("https://www.instagram.com/accounts/web_change_profile_picture/")
#Region "Shitty Headers :)"
            With AJ
                .Method = "POST"
                .Host = "www.instagram.com"
                .KeepAlive = True
                .ContentLength = Bytes.Length
                .Headers.Add("X-IG-WWW-Claim: hmac.AR0KX23gPNOJFSnta7iaQcTPPDM622f4k3wBe8LiwnC2AnyT")
                .Headers.Add("X-Instagram-AJAX: b9c0ea6d7d91-hot")
                .ContentType = $"multipart/form-data; boundary=----WebKitFormBoundary{Boundary}"
                .Accept = "*/*"
                .UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.183 Safari/537.36"
                .Headers.Add("X-Requested-With: XMLHttpRequest")
                .Headers.Add(HttpRequestHeader.Cookie, FullCookie)
                .Headers.Add("X-CSRFToken", Regex.Match(FullCookie, "csrftoken=(.*?);").Groups(1).Value)
                .Headers.Add("X-IG-App-ID: 936619743392459")
                .AutomaticDecompression = Net.DecompressionMethods.Deflate Or Net.DecompressionMethods.GZip
                .Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.9,ar-EG;q=0.8,ar;q=0.7,bas-CM;q=0.6,bas;q=0.5")
            End With
#End Region
            Dim Stream As IO.Stream = AJ.GetRequestStream() : Stream.Write(Bytes, 0, Bytes.Length) : Stream.Dispose() : Stream.Close()
            Dim Reader As New IO.StreamReader(DirectCast(AJ.GetResponse(), Net.HttpWebResponse).GetResponseStream()) : Dim Text As String = Reader.ReadToEnd : Reader.Dispose() : Reader.Close()
            If Text.Contains("""changed_profile"": true, """) Then IsPosted = True
        Catch ex As WebException : Dim AJJ As String = New IO.StreamReader(ex.Response.GetResponseStream()).ReadToEnd()
            IsPosted = False
        End Try
        Return IsPosted
    End Function
#End Region
End Class