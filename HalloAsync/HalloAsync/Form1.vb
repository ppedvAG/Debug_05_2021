Imports System.Net.Http
Imports System.Threading

Public Class Form1
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        For index = 1 To 100
            ProgressBar1.Value = index
            Thread.Sleep(30)
            Application.DoEvents() 'pfusch!
            Label1.Text = $"{index}%"
        Next
        Label1.Text = $"Fertig"

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Button7.Enabled = False

        Task.Run(Sub()
                     For index = 1 To 100
                         Dim i = index
                         Me.Invoke(Sub()
                                       ProgressBar2.Value = i
                                       Label2.Text = $"{i}%"
                                   End Sub)
                         Thread.Sleep(1)
                     Next

                 End Sub)
        Label2.Text = $"Fertig"

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Button7.Enabled = False

        tokenSrc = New CancellationTokenSource()

        Dim uiThread = TaskScheduler.FromCurrentSynchronizationContext()
        Task.Run(Sub()
                     For index = 1 To 100
                         Dim i = index

                         Dim t = Task.Factory.StartNew(Sub()
                                                           ProgressBar3.Value = i
                                                           Label3.Text = $"{i}%"
                                                           'If index > 30 Then
                                                           '    Throw New ExecutionEngineException()
                                                           'End If
                                                       End Sub, tokenSrc.Token, TaskCreationOptions.None, uiThread)
                         t.ContinueWith(Sub(tt)
                                            MessageBox.Show(tt.Exception.InnerException.Message)
                                        End Sub, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, uiThread)

                         Thread.Sleep(10)

                         If tokenSrc.IsCancellationRequested Then
                             'cleanup
                             Exit For
                         End If
                     Next
                 End Sub).ContinueWith(Sub(t)

                                           Label3.Text = $"Fertig"
                                           Button7.Enabled = Not False
                                       End Sub, CancellationToken.None, TaskContinuationOptions.None, uiThread)



    End Sub
    Dim tokenSrc As CancellationTokenSource
    Dim tokenSrcAA As CancellationTokenSource

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tokenSrc?.Cancel()
        tokenSrcAA?.Cancel()
    End Sub

    Private Async Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        tokenSrcAA = New CancellationTokenSource()
        Try
            Button8.Enabled = False
            For index = 1 To 100
                ProgressBar4.Value = index

                Await Task.Delay(10, tokenSrcAA.Token)

                Label4.Text = $"{index}%"
            Next
            Label4.Text = $"Fertig"
            Button8.Enabled = Not False

        Catch ex As TaskCanceledException
            'MessageBox.Show($"Abbruch erfolreich:{ex.Message}")
            Label4.Text = $"Abgebrochen"
            Button8.Enabled = Not False
        Catch ex As Exception
            MessageBox.Show($"Fehler:{ex.Message}")
        End Try

    End Sub

    Private Async Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        TextBox1.Text = ""
        Dim url = "http://www.ppedv.de"

        Dim webClient = New HttpClient()

        Dim htmlSrc = Await webClient.GetStringAsync(url)

        TextBox1.Text = htmlSrc.Trim()

    End Sub


    Private Function AltUndLangsam(value As Integer) As Long
        Thread.Sleep(5000)
        Return 43580743 * value
    End Function

    Private Function AltUndLangsamAsync(value As Integer) As Task(Of Long)
        Return Task.Run(Function() AltUndLangsam(value))
    End Function

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        MessageBox.Show(AltUndLangsam(12).ToString())
    End Sub

    Private Async Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

        Button11.Enabled = False
        PictureBox1.Visible = Not False

        ProgressBar5.Style = ProgressBarStyle.Marquee
        MessageBox.Show((Await AltUndLangsamAsync(12)).ToString())
        ProgressBar5.Style = ProgressBarStyle.Continuous
        PictureBox1.Visible = False
        Button11.Enabled = Not False

    End Sub
End Class
