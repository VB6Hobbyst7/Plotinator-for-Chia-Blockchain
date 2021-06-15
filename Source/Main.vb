Imports System.IO
Imports System.Text

Public Class Main

    Private WithEvents myProcess As Process

    '### Check empty Folder
    Private WithEvents myTimer As New System.Windows.Forms.Timer()

    '### Plots Counter
    Public Counter1 As Integer
    Public Counter2 As Integer

    '### Next Plot Start
    Public Ampel1 As Boolean = False
    Public Ampel2 As Boolean = False
    Public Ampel3 As Boolean = False
    Public Ampel4 As Boolean = False
    Public Ampel5 As Boolean = False
    Public Ampel6 As Boolean = False
    Public Ampel7 As Boolean = False
    Public Ampel8 As Boolean = False
    Public Ampel9 As Boolean = False
    Public Ampel10 As Boolean = False
    Public Ampel11 As Boolean = False

    Public SleepSec As String

    Public TempV2 As String


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        TextBox6.Text = My.Settings.ChiaV1
        TextBox3.Text = My.Settings.Temp1
        TextBox7.Text = My.Settings.Temp2
        TextBox4.Text = My.Settings.End1
        TextBox1.Text = My.Settings.Ram1
        TextBox2.Text = My.Settings.T1
        TextBox5.Text = My.Settings.Plot1
        TextBox17.Text = My.Settings.Version

        Ampel2 = False
        Ampel3 = False
        Ampel4 = False
        Ampel5 = False
        Ampel6 = False
        Ampel7 = False
        Ampel8 = False
        Ampel9 = False
        Ampel10 = False
        Ampel11 = False


        'Delete old files
        Try

            For Each a As String In IO.Directory.GetFiles(Application.StartupPath & "\Batchjob\Batch")
                IO.File.Delete(a)
            Next

            For Each a As String In IO.Directory.GetFiles(Application.StartupPath & "\Batchjob\Logs")
                IO.File.Delete(a)
            Next

        Catch ex As Exception

        End Try

        'Window to front
        Me.TextBox43.BringToFront()

        'First Plot-Windows activate
        RadioButton1.Checked = True

        'Parameters
        If My.Settings.Plot1 = "" Then
            TextBox5.Text = "10"
        End If

        If My.Settings.Ram1 = "" Then
            TextBox1.Text = "4000"
        End If

        If My.Settings.T1 = "" Then
            TextBox2.Text = "2"
        End If

        If My.Settings.Version = "" Then
            TextBox17.Text = "1.1.7"
        End If

        'Start the chain
        Ampel1 = True

        'New start the chain
        If My.Settings.Status = True Then
            My.Settings.Status = False
            TextBox37.Text = My.Settings.Neustart
            Counter1 = TextBox37.Text
            Button5.PerformClick()
        End If



    End Sub




    'START#########################

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim RAM As String = TextBox1.Text
        Dim Threads As String = TextBox2.Text
        Dim Temp As String = TextBox3.Text
        Dim EndV As String = TextBox4.Text
        Dim Plots As String = TextBox5.Text
        Dim Chia As String = TextBox6.Text

        My.Settings.ChiaV1 = TextBox6.Text
        My.Settings.Temp1 = TextBox3.Text
        My.Settings.Temp2 = TextBox7.Text
        My.Settings.End1 = TextBox4.Text
        My.Settings.Ram1 = TextBox1.Text
        My.Settings.T1 = TextBox2.Text
        My.Settings.Plot1 = TextBox5.Text
        My.Settings.Version = TextBox17.Text

        My.Settings.Save()
        My.Settings.Reload()


        ' Second Temp-Folder
        If TextBox7.Text <> "" Then
            TempV2 = " -2 " & TextBox7.Text
        End If

        'Counters
        Counter1 += 1
        TextBox37.Text = Counter1

        Counter2 += 1
        TextBox12.Text = Counter2



        'Create Batch
        Dim Pfadbatch As String = (Application.StartupPath & "\Batchjob\Batch\Ploter_" & TextBox12.Text & ".bat")
        Dim fs As New FileStream(Pfadbatch, FileMode.Create, FileAccess.Write)
        Dim s As New StreamWriter(fs)
        s.WriteLine("CD /d " & Chia & vbNewLine &
                     "Chia.exe plots create -k 32 -b " & RAM & " -u 128 -r " & Threads & " -t " & Temp & TempV2 & " -d " & EndV & " -n 1" & " > " & Application.StartupPath & "\Batchjob\Logs\Log_Ploter_" & TextBox12.Text & ".txt" & vbNewLine)
        s.Close()


        'Start batchfile
        Dim start_info As New ProcessStartInfo()
        Dim proc As New Process

        My.Settings.Reload()

        start_info.FileName = ("cmd.exe")
        start_info.WindowStyle = ProcessWindowStyle.Minimized
        start_info.WorkingDirectory = Application.StartupPath & "\Batchjob\Batch"
        start_info.Arguments = ("/c " & Pfadbatch)
        proc.StartInfo = start_info
        proc.Start()


        If TextBox43.Text = "" Then
            TextBox43.Text = "Chianator was started ... "
        End If

        System.Threading.Thread.Sleep(1500)
        Call timerstart()


    End Sub



    Public Sub timerstart()

        myTimer.Interval = 10000
        myTimer.Start()

    End Sub



    Private Sub TimerEventProcessor(myObject As Object,
                                           ByVal myEventArgs As EventArgs) _
                                       Handles myTimer.Tick


        Try

            Dim Plot1 As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_1.txt"
            Dim Plot1Temp As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_1_Temp.txt"
            Dim Plot2 As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_2.txt"
            Dim Plot2Temp As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_2_Temp.txt"
            Dim Plot3 As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_3.txt"
            Dim Plot3Temp As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_3_Temp.txt"
            Dim Plot4 As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_4.txt"
            Dim Plot4Temp As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_4_Temp.txt"
            Dim Plot5 As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_5.txt"
            Dim Plot5Temp As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_5_Temp.txt"
            Dim Plot6 As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_6.txt"
            Dim Plot6Temp As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_6_Temp.txt"
            Dim Plot7 As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_7.txt"
            Dim Plot7Temp As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_7_Temp.txt"
            Dim Plot8 As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_8.txt"
            Dim Plot8Temp As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_8_Temp.txt"
            Dim Plot9 As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_9.txt"
            Dim Plot9Temp As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_9_Temp.txt"
            Dim Plot10 As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_10.txt"
            Dim Plot10Temp As String = Application.StartupPath & "\Batchjob\Logs\Log_Ploter_10_Temp.txt"





            If Ampel1 = True Then


                My.Computer.FileSystem.CopyFile(Plot1, Plot1Temp, True)


                Using strm As New StreamReader(Plot1Temp)
                    Dim res As New StringBuilder()

                    While Not strm.EndOfStream
                        res.AppendLine(strm.ReadLine)
                    End While

                    Me.TextBox43.Text = res.ToString()
                End Using


                Dim Wort2 As String
                Wort2 = "1/4:"
                For Each line As String In TextBox43.Lines
                    If line.Contains(Wort2) And TextBox8.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox8.Text = (time.ToString(format))


                    End If
                Next


                Dim Wort3 As String
                Wort3 = "2/4:"
                For Each line As String In TextBox43.Lines
                    If line.Contains(Wort3) And TextBox9.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox9.Text = (time.ToString(format))


                        'Vorgang abbrechen wenn max. Plots erreicht
                        If TextBox5.Text <> TextBox37.Text Then

                            myTimer.Stop()

                            Ampel2 = True
                            Button5.PerformClick()

                        End If

                    End If
                Next

                Dim Wort4 As String
                Wort4 = "3/4:"
                For Each line As String In TextBox43.Lines
                    If line.Contains(Wort4) And TextBox10.Text = "" Then

                        Dim time3 As DateTime = DateTime.Now
                        Dim format3 As String = "dd.MM. HH:mm"
                        TextBox10.Text = (time3.ToString(format3))

                    End If
                Next


                Dim Wort5 As String
                Wort5 = "Copy time"
                For Each line As String In TextBox43.Lines
                    If line.Contains(Wort5) And TextBox11.Text = "" Then

                        Dim time5 As DateTime = DateTime.Now
                        Dim format5 As String = "dd.MM. HH:mm"
                        TextBox11.Text = (time5.ToString(format5))



                    End If
                Next
            End If





            '2_##############################################################################################################################



            If Ampel2 = True Then




                My.Computer.FileSystem.CopyFile(Plot2, Plot2Temp, True)


                Using strm As New StreamReader(Plot2Temp)
                    Dim res As New StringBuilder()

                    While Not strm.EndOfStream
                        res.AppendLine(strm.ReadLine)
                    End While

                    Me.TextBox60.Text = res.ToString()
                End Using


                Dim Wort2 As String
                Wort2 = "1/4:"
                For Each line As String In TextBox60.Lines

                    If line.Contains(Wort2) And TextBox13.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox13.Text = (time.ToString(format))

                    End If
                Next


                Dim Wort3 As String
                Wort3 = "2/4:"
                For Each line As String In TextBox60.Lines
                    If line.Contains(Wort3) And TextBox14.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox14.Text = (time.ToString(format))

                        'Vorgang abbrechen wenn max. Plots erreicht
                        If TextBox5.Text <> TextBox37.Text Then

                            myTimer.Stop()
                            Ampel3 = True
                            Button5.PerformClick()

                        End If

                    End If
                Next

                Dim Wort4 As String
                Wort4 = "3/4:"
                For Each line As String In TextBox60.Lines
                    If line.Contains(Wort4) And TextBox15.Text = "" Then

                        Dim time3 As DateTime = DateTime.Now
                        Dim format3 As String = "dd.MM. HH:mm"
                        TextBox15.Text = (time3.ToString(format3))

                    End If
                Next


                Dim Wort5 As String
                Wort5 = "Copy time"
                For Each line As String In TextBox60.Lines
                    If line.Contains(Wort5) And TextBox16.Text = "" Then

                        Dim time5 As DateTime = DateTime.Now
                        Dim format5 As String = "dd.MM. HH:mm"
                        TextBox16.Text = (time5.ToString(format5))




                    End If
                Next
            End If




            '3_##############################################################################################################################


            If Ampel3 = True Then



                My.Computer.FileSystem.CopyFile(Plot3, Plot3Temp, True)


                Using strm As New StreamReader(Plot3Temp)
                    Dim res As New StringBuilder()

                    While Not strm.EndOfStream
                        res.AppendLine(strm.ReadLine)
                    End While

                    Me.TextBox61.Text = res.ToString()
                End Using


                Dim Wort2 As String
                Wort2 = "1/4:"
                For Each line As String In TextBox61.Lines
                    If line.Contains(Wort2) And TextBox18.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox18.Text = (time.ToString(format))

                    End If
                Next


                Dim Wort3 As String
                Wort3 = "2/4:"
                For Each line As String In TextBox61.Lines
                    If line.Contains(Wort3) And TextBox19.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox19.Text = (time.ToString(format))

                        'Vorgang abbrechen wenn max. Plots erreicht
                        If TextBox5.Text <> TextBox37.Text Then

                            myTimer.Stop()
                            Ampel4 = True
                            Button5.PerformClick()

                        End If


                    End If
                Next

                Dim Wort4 As String
                Wort4 = "3/4:"
                For Each line As String In TextBox61.Lines
                    If line.Contains(Wort4) And TextBox20.Text = "" Then

                        Dim time3 As DateTime = DateTime.Now
                        Dim format3 As String = "dd.MM. HH:mm"
                        TextBox20.Text = (time3.ToString(format3))

                    End If
                Next


                Dim Wort5 As String
                Wort5 = "Copy time"
                For Each line As String In TextBox61.Lines
                    If line.Contains(Wort5) And TextBox21.Text = "" Then


                        Dim time5 As DateTime = DateTime.Now
                        Dim format5 As String = "dd.MM. HH:mm"
                        TextBox21.Text = (time5.ToString(format5))



                    End If
                Next
            End If


            '4_##############################################################################################################################


            If Ampel4 = True Then



                My.Computer.FileSystem.CopyFile(Plot4, Plot4Temp, True)


                Using strm As New StreamReader(Plot4Temp)
                    Dim res As New StringBuilder()

                    While Not strm.EndOfStream
                        res.AppendLine(strm.ReadLine)
                    End While

                    Me.TextBox62.Text = res.ToString()
                End Using


                Dim Wort2 As String
                Wort2 = "1/4:"
                For Each line As String In TextBox62.Lines
                    If line.Contains(Wort2) And TextBox23.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox23.Text = (time.ToString(format))


                    End If
                Next


                Dim Wort3 As String
                Wort3 = "2/4:"
                For Each line As String In TextBox62.Lines
                    If line.Contains(Wort3) And TextBox24.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox24.Text = (time.ToString(format))

                        'Vorgang abbrechen wenn max. Plots erreicht
                        If TextBox5.Text <> TextBox37.Text Then

                            myTimer.Stop()
                            Ampel5 = True
                            Button5.PerformClick()


                        End If

                    End If
                Next

                Dim Wort4 As String
                Wort4 = "3/4:"
                For Each line As String In TextBox62.Lines
                    If line.Contains(Wort4) And TextBox25.Text = "" Then

                        Dim time3 As DateTime = DateTime.Now
                        Dim format3 As String = "dd.MM. HH:mm"
                        TextBox25.Text = (time3.ToString(format3))

                    End If
                Next


                Dim Wort5 As String
                Wort5 = "Copy time"
                For Each line As String In TextBox62.Lines
                    If line.Contains(Wort5) And TextBox26.Text = "" Then


                        Dim time5 As DateTime = DateTime.Now
                        Dim format5 As String = "dd.MM. HH:mm"
                        TextBox26.Text = (time5.ToString(format5))

                    End If
                Next
            End If



            '5_##############################################################################################################################


            If Ampel5 = True Then



                My.Computer.FileSystem.CopyFile(Plot5, Plot5Temp, True)


                Using strm As New StreamReader(Plot5Temp)
                    Dim res As New StringBuilder()

                    While Not strm.EndOfStream
                        res.AppendLine(strm.ReadLine)
                    End While

                    Me.TextBox63.Text = res.ToString()
                End Using


                Dim Wort2 As String
                Wort2 = "1/4:"
                For Each line As String In TextBox63.Lines
                    If line.Contains(Wort2) And TextBox28.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox28.Text = (time.ToString(format))


                    End If
                Next


                Dim Wort3 As String
                Wort3 = "2/4:"
                For Each line As String In TextBox63.Lines
                    If line.Contains(Wort3) And TextBox29.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox29.Text = (time.ToString(format))

                        'Vorgang abbrechen wenn max. Plots erreicht
                        If TextBox5.Text <> TextBox37.Text Then

                            myTimer.Stop()
                            Ampel6 = True
                            Button5.PerformClick()

                        End If

                    End If
                Next

                Dim Wort4 As String
                Wort4 = "3/4:"
                For Each line As String In TextBox63.Lines
                    If line.Contains(Wort4) And TextBox30.Text = "" Then

                        Dim time3 As DateTime = DateTime.Now
                        Dim format3 As String = "dd.MM. HH:mm"
                        TextBox30.Text = (time3.ToString(format3))

                    End If
                Next


                Dim Wort5 As String
                Wort5 = "Copy time"
                For Each line As String In TextBox63.Lines
                    If line.Contains(Wort5) And TextBox31.Text = "" Then


                        Dim time5 As DateTime = DateTime.Now
                        Dim format5 As String = "dd.MM. HH:mm"
                        TextBox31.Text = (time5.ToString(format5))

                    End If
                Next
            End If



            '6_##############################################################################################################################


            If Ampel6 = True Then



                My.Computer.FileSystem.CopyFile(Plot6, Plot6Temp, True)


                Using strm As New StreamReader(Plot6Temp)
                    Dim res As New StringBuilder()

                    While Not strm.EndOfStream
                        res.AppendLine(strm.ReadLine)
                    End While

                    Me.TextBox64.Text = res.ToString()
                End Using


                Dim Wort2 As String
                Wort2 = "1/4:"
                For Each line As String In TextBox64.Lines
                    If line.Contains(Wort2) And TextBox33.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox33.Text = (time.ToString(format))


                    End If
                Next


                Dim Wort3 As String
                Wort3 = "2/4:"
                For Each line As String In TextBox64.Lines
                    If line.Contains(Wort3) And TextBox34.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox34.Text = (time.ToString(format))

                        'Vorgang abbrechen wenn max. Plots erreicht
                        If TextBox5.Text <> TextBox37.Text Then

                            myTimer.Stop()
                            Ampel7 = True
                            Button5.PerformClick()

                        End If

                    End If
                Next

                Dim Wort4 As String
                Wort4 = "3/4:"
                For Each line As String In TextBox64.Lines
                    If line.Contains(Wort4) And TextBox35.Text = "" Then

                        Dim time3 As DateTime = DateTime.Now
                        Dim format3 As String = "dd.MM. HH:mm"
                        TextBox35.Text = (time3.ToString(format3))

                    End If
                Next


                Dim Wort5 As String
                Wort5 = "Copy time"
                For Each line As String In TextBox64.Lines
                    If line.Contains(Wort5) And TextBox36.Text = "" Then


                        Dim time5 As DateTime = DateTime.Now
                        Dim format5 As String = "dd.MM. HH:mm"
                        TextBox36.Text = (time5.ToString(format5))


                    End If
                Next
            End If



            '7_##############################################################################################################################


            If Ampel7 = True Then



                My.Computer.FileSystem.CopyFile(Plot7, Plot7Temp, True)


                Using strm As New StreamReader(Plot7Temp)
                    Dim res As New StringBuilder()

                    While Not strm.EndOfStream
                        res.AppendLine(strm.ReadLine)
                    End While

                    Me.TextBox65.Text = res.ToString()
                End Using


                Dim Wort2 As String
                Wort2 = "1/4:"
                For Each line As String In TextBox65.Lines
                    If line.Contains(Wort2) And TextBox39.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox39.Text = (time.ToString(format))


                    End If
                Next


                Dim Wort3 As String
                Wort3 = "2/4:"
                For Each line As String In TextBox65.Lines
                    If line.Contains(Wort3) And TextBox40.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox40.Text = (time.ToString(format))

                        'Vorgang abbrechen wenn max. Plots erreicht
                        If TextBox5.Text <> TextBox37.Text Then

                            myTimer.Stop()
                            Ampel8 = True
                            Button5.PerformClick()

                        End If

                    End If
                Next

                Dim Wort4 As String
                Wort4 = "3/4:"
                For Each line As String In TextBox65.Lines
                    If line.Contains(Wort4) And TextBox41.Text = "" Then

                        Dim time3 As DateTime = DateTime.Now
                        Dim format3 As String = "dd.MM. HH:mm"
                        TextBox41.Text = (time3.ToString(format3))

                    End If
                Next


                Dim Wort5 As String
                Wort5 = "Copy time"
                For Each line As String In TextBox65.Lines
                    If line.Contains(Wort5) And TextBox42.Text = "" Then


                        Dim time5 As DateTime = DateTime.Now
                        Dim format5 As String = "dd.MM. HH:mm"
                        TextBox42.Text = (time5.ToString(format5))

                    End If
                Next
            End If




            '8_##############################################################################################################################


            If Ampel8 = True Then



                My.Computer.FileSystem.CopyFile(Plot8, Plot8Temp, True)


                Using strm As New StreamReader(Plot8Temp)
                    Dim res As New StringBuilder()

                    While Not strm.EndOfStream
                        res.AppendLine(strm.ReadLine)
                    End While

                    Me.TextBox66.Text = res.ToString()
                End Using


                Dim Wort2 As String
                Wort2 = "1/4:"
                For Each line As String In TextBox66.Lines
                    If line.Contains(Wort2) And TextBox45.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox45.Text = (time.ToString(format))


                    End If
                Next


                Dim Wort3 As String
                Wort3 = "2/4:"
                For Each line As String In TextBox66.Lines
                    If line.Contains(Wort3) And TextBox46.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox46.Text = (time.ToString(format))

                        'Vorgang abbrechen wenn max. Plots erreicht
                        If TextBox5.Text <> TextBox37.Text Then

                            myTimer.Stop()
                            Ampel9 = True
                            Button5.PerformClick()

                        End If

                    End If
                Next

                Dim Wort4 As String
                Wort4 = "3/4:"
                For Each line As String In TextBox66.Lines
                    If line.Contains(Wort4) And TextBox47.Text = "" Then

                        Dim time3 As DateTime = DateTime.Now
                        Dim format3 As String = "dd.MM. HH:mm"
                        TextBox47.Text = (time3.ToString(format3))

                    End If
                Next


                Dim Wort5 As String
                Wort5 = "Copy time"
                For Each line As String In TextBox66.Lines
                    If line.Contains(Wort5) And TextBox48.Text = "" Then


                        Dim time5 As DateTime = DateTime.Now
                        Dim format5 As String = "dd.MM. HH:mm"
                        TextBox48.Text = (time5.ToString(format5))

                    End If
                Next
            End If


            '9_##############################################################################################################################


            If Ampel9 = True Then



                My.Computer.FileSystem.CopyFile(Plot9, Plot9Temp, True)


                Using strm As New StreamReader(Plot9Temp)
                    Dim res As New StringBuilder()

                    While Not strm.EndOfStream
                        res.AppendLine(strm.ReadLine)
                    End While

                    Me.TextBox67.Text = res.ToString()
                End Using


                Dim Wort2 As String
                Wort2 = "1/4:"
                For Each line As String In TextBox67.Lines
                    If line.Contains(Wort2) And TextBox50.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox50.Text = (time.ToString(format))


                    End If
                Next


                Dim Wort3 As String
                Wort3 = "2/4:"
                For Each line As String In TextBox67.Lines
                    If line.Contains(Wort3) And TextBox51.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox51.Text = (time.ToString(format))

                        'Vorgang abbrechen wenn max. Plots erreicht
                        If TextBox5.Text <> TextBox37.Text Then

                            myTimer.Stop()
                            Ampel10 = True
                            Button5.PerformClick()

                        End If

                    End If
                Next

                Dim Wort4 As String
                Wort4 = "3/4:"
                For Each line As String In TextBox67.Lines
                    If line.Contains(Wort4) And TextBox52.Text = "" Then

                        Dim time3 As DateTime = DateTime.Now
                        Dim format3 As String = "dd.MM. HH:mm"
                        TextBox52.Text = (time3.ToString(format3))

                    End If
                Next


                Dim Wort5 As String
                Wort5 = "Copy time"
                For Each line As String In TextBox67.Lines
                    If line.Contains(Wort5) And TextBox53.Text = "" Then


                        Dim time5 As DateTime = DateTime.Now
                        Dim format5 As String = "dd.MM. HH:mm"
                        TextBox53.Text = (time5.ToString(format5))

                    End If
                Next
            End If


            '10_##############################################################################################################################


            If Ampel10 = True Then



                My.Computer.FileSystem.CopyFile(Plot10, Plot10Temp, True)


                Using strm As New StreamReader(Plot10Temp)
                    Dim res As New StringBuilder()

                    While Not strm.EndOfStream
                        res.AppendLine(strm.ReadLine)
                    End While

                    Me.TextBox68.Text = res.ToString()
                End Using


                Dim Wort2 As String
                Wort2 = "1/4:"
                For Each line As String In TextBox68.Lines
                    If line.Contains(Wort2) And TextBox55.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox55.Text = (time.ToString(format))


                    End If
                Next


                Dim Wort3 As String
                Wort3 = "2/4:"
                For Each line As String In TextBox68.Lines
                    If line.Contains(Wort3) And TextBox56.Text = "" Then

                        Dim time As DateTime = DateTime.Now
                        Dim format As String = "dd.MM. HH:mm"
                        TextBox56.Text = (time.ToString(format))

                        'Vorgang abbrechen wenn max. Plots erreicht
                        If TextBox5.Text <> TextBox37.Text Then


                            My.Settings.Status = True
                            My.Settings.Neustart = TextBox37.Text
                            My.Settings.Save()
                            My.Settings.Reload()

                            Application.Restart()

                        End If



                    End If
                Next

                Dim Wort4 As String
                Wort4 = "3/4:"
                For Each line As String In TextBox68.Lines
                    If line.Contains(Wort4) And TextBox57.Text = "" Then

                        Dim time3 As DateTime = DateTime.Now
                        Dim format3 As String = "dd.MM. HH:mm"
                        TextBox57.Text = (time3.ToString(format3))

                    End If
                Next


                Dim Wort5 As String
                Wort5 = "Copy time"
                For Each line As String In TextBox68.Lines
                    If line.Contains(Wort5) And TextBox58.Text = "" Then


                        Dim time5 As DateTime = DateTime.Now
                        Dim format5 As String = "dd.MM. HH:mm"
                        TextBox58.Text = (time5.ToString(format5))


                    End If
                Next
            End If

        Catch ex As Exception
        End Try


    End Sub


    'Clear Textboxes
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox17.Text = ""


        My.Settings.ChiaV1 = TextBox6.Text
        My.Settings.End1 = TextBox4.Text
        My.Settings.Plot1 = TextBox5.Text
        My.Settings.Ram1 = TextBox1.Text
        My.Settings.T1 = TextBox2.Text
        My.Settings.Temp1 = TextBox3.Text
        My.Settings.Version = TextBox17.Text

        My.Settings.Save()
        My.Settings.Reload()

    End Sub

    Private Sub Textbox43_Change(ByVal sender As System.Object,
 ByVal e As System.EventArgs) _
 Handles TextBox43.TextChanged
        TextBox43.SelectionStart = TextBox43.Text.Length
        TextBox43.ScrollToCaret()
    End Sub

    Private Sub Textbox60_Change(ByVal sender As System.Object,
 ByVal e As System.EventArgs) _
 Handles TextBox60.TextChanged
        TextBox60.SelectionStart = TextBox60.Text.Length
        TextBox60.ScrollToCaret()
    End Sub

    Private Sub Textbox61_Change(ByVal sender As System.Object,
 ByVal e As System.EventArgs) _
 Handles TextBox61.TextChanged
        TextBox61.SelectionStart = TextBox61.Text.Length
        TextBox61.ScrollToCaret()
    End Sub


    Private Sub Textbox62_Change(ByVal sender As System.Object,
 ByVal e As System.EventArgs) _
 Handles TextBox62.TextChanged
        TextBox62.SelectionStart = TextBox62.Text.Length
        TextBox62.ScrollToCaret()
    End Sub


    Private Sub Textbox63_Change(ByVal sender As System.Object,
 ByVal e As System.EventArgs) _
 Handles TextBox63.TextChanged
        TextBox63.SelectionStart = TextBox63.Text.Length
        TextBox63.ScrollToCaret()
    End Sub


    Private Sub Textbox64_Change(ByVal sender As System.Object,
 ByVal e As System.EventArgs) _
 Handles TextBox64.TextChanged
        TextBox64.SelectionStart = TextBox64.Text.Length
        TextBox64.ScrollToCaret()
    End Sub


    Private Sub Textbox65_Change(ByVal sender As System.Object,
 ByVal e As System.EventArgs) _
 Handles TextBox65.TextChanged
        TextBox65.SelectionStart = TextBox65.Text.Length
        TextBox65.ScrollToCaret()
    End Sub

    Private Sub Textbox66_Change(ByVal sender As System.Object,
 ByVal e As System.EventArgs) _
 Handles TextBox66.TextChanged
        TextBox66.SelectionStart = TextBox66.Text.Length
        TextBox66.ScrollToCaret()
    End Sub

    Private Sub Textbox67_Change(ByVal sender As System.Object,
 ByVal e As System.EventArgs) _
 Handles TextBox67.TextChanged
        TextBox67.SelectionStart = TextBox67.Text.Length
        TextBox67.ScrollToCaret()
    End Sub

    Private Sub Textbox68_Change(ByVal sender As System.Object,
 ByVal e As System.EventArgs) _
 Handles TextBox68.TextChanged
        TextBox68.SelectionStart = TextBox68.Text.Length
        TextBox68.ScrollToCaret()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TextBox6.Text = FolderBrowserDialog1.SelectedPath
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TextBox3.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TextBox7.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TextBox4.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Me.TextBox43.BringToFront()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Me.TextBox60.BringToFront()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Me.TextBox61.BringToFront()
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        Me.TextBox62.BringToFront()
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        Me.TextBox63.BringToFront()
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        Me.TextBox64.BringToFront()
    End Sub

    Private Sub RadioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton7.CheckedChanged
        Me.TextBox65.BringToFront()
    End Sub

    Private Sub RadioButton8_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton8.CheckedChanged
        Me.TextBox66.BringToFront()
    End Sub

    Private Sub RadioButton9_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton9.CheckedChanged
        Me.TextBox67.BringToFront()
    End Sub

    Private Sub RadioButton10_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton10.CheckedChanged
        Me.TextBox68.BringToFront()
    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles TextBox17.TextChanged

        TextBox6.Text = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\chia-blockchain\app-" & TextBox17.Text & "\resources\app.asar.unpacked\daemon"

    End Sub
End Class
