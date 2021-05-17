Public Module Logger

    Sub New()

        Trace.Listeners.Add(New TextWriterTraceListener("log.txt"))
        Trace.Listeners.Add(New EventLogTraceListener("Application"))
        Trace.AutoFlush = True
    End Sub

    Public Sub Log(msg As String)
        Trace.WriteLine("Hallo Trace")
    End Sub


    Public Sub Warn(msg As String)
        Trace.TraceWarning("Trace warnung")
    End Sub

End Module
