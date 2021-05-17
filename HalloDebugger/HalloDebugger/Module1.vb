Module Module1

    Dim titel = "HALLOOOOO WELT"
    Sub Main()
        Console.WriteLine("Hallo Welt")

        Dim liste As New List(Of Person)

        While True
            liste.Add(New Person())
        End While

        Dim eingabe = Console.ReadLine()

        Console.ReadLine()
        'todo besseren namen finden
        Zähle()


        Console.WriteLine("Ende")
        Console.ReadLine()
    End Sub

    Private Sub Zähle()
        Dim localelZeug = 5
        For index = 1 To 10
            Console.WriteLine($"index:{index}")
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