Imports System.Threading

Module Module1

    Sub Main()
        Console.WriteLine("Hallo TPL")

        'Zähle()
        'Zähle()
        'Zähle()
        'Console.WriteLine("------")
        'Parallel.Invoke(AddressOf Zähle, AddressOf Zähle, AddressOf Zähle, AddressOf Zähle)
        Parallel.For(0, 1000000, AddressOf ZeigeZahl)



        Console.WriteLine("Ende")
        Console.ReadLine()
    End Sub

    Sub Zähle()
        For index = 1 To 10
            ZeigeZahl(index)
        Next
    End Sub

    Private Sub ZeigeZahl(index As Integer)
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {index}")
    End Sub
End Module
