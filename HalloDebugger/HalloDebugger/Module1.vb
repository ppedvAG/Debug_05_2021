Imports System.Threading

Module Module1

    Dim titel = "HALLOOOOO WELT"

    Sub Main()

#If DEBUG Then
        Console.WriteLine("DEBUG")
#End If


        Dim eingabe = Console.ReadLine()

        Debug.Assert(Not String.IsNullOrEmpty(eingabe))


        Console.WriteLine("Hallo Welt")

        Debugger.Log(1, "Message", "Hallo debugger")

        Debug.WriteLine("Hallo Debug")



        Log("Hallo Trace")
        Warn("Trace warnung")



        Dim liste As New List(Of Person)

        'While True
        '    liste.Add(New Person())
        '    Thread.Sleep(100)
        'End While


        Zähle()


        Dim eingabe2 = Console.ReadLine()

        Console.ReadLine()
        'todo besseren namen finden
        Zähle()


        Console.WriteLine("Ende")
        Console.ReadLine()
    End Sub

    Dim localelZeug = 5
    Private Sub Zähle()


        For index = 1 To 10
            Console.WriteLine($"index:{index}")

            localelZeug += index

            If index > 7 Then
                Try

                    MachFehler()
                Catch ex As Exception
                    Console.WriteLine("AAAAAAAaaaa")
                End Try

            End If
        Next
    End Sub

    Private Sub MachFehler()

        Throw New InvalidTimeZoneException()
    End Sub
End Module


Class Person
    Property Name As String
    Property Zahl As Integer
End Class