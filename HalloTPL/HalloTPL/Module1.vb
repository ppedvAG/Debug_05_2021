Imports System.Threading

Module Module1

    Sub Main()
        Console.WriteLine("Hallo TPL")

        'Zähle()
        'Zähle()
        'Zähle()
        'Console.WriteLine("------")
        'Parallel.Invoke(AddressOf Zähle, AddressOf Zähle, AddressOf Zähle, AddressOf Zähle)
        'Parallel.For(0, 1000000, AddressOf ZeigeZahl)
        Dim t1 As New Task(Sub()
                               Console.WriteLine("T1 gestartet")
                               Thread.Sleep(1200)
                               Console.WriteLine("T1 fertig")
                           End Sub)

        Dim t2 As New Task(Of Long)(Function()
                                        Console.WriteLine("T2 gestartet")
                                        Thread.Sleep(800)
                                        Console.WriteLine("T2 fertig")
                                        Return 978453978435978435
                                    End Function)

        t1.Start()
        t2.Start()

        Thread.Sleep(10)

        't2.Wait() 'implizit dur zugriff auf Result
        Console.WriteLine($"Result of Task 2: {t2.Result}")

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
