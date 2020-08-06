Imports System
Imports System.Threading.Tasks

Module Program
    Sub Main(args As String())


        'Async function to retrieve data from GET request
        Dim t As Task(Of Task(Of String)) = Task.Factory.StartNew(Async Function() As Task(Of String)
                                                                      Dim webClient As New System.Net.WebClient
                                                                      Console.WriteLine("about to begin")
                                                                      Dim url As Uri = New Uri("http://localhost:4500/str")
                                                                      Dim result As String = Await webClient.DownloadStringTaskAsync(url)
                                                                      
                                                                      Return result


                                                                  End Function
                                                                  )

        Try
            t.Wait()
            Console.WriteLine("t Status :{0}", t.Status)
            If (t.IsCompleted.Equals(True)) Then
                Console.WriteLine("Data accuired: {0}", t.Result.Result)


            End If
        Catch e As AggregateException
            Console.WriteLine("Exception is in t")
            Console.WriteLine(e.Message)


        End Try

        Console.WriteLine("hoii")
        Console.WriteLine("hoii")
        Console.WriteLine("hoii")
        Console.WriteLine("hoii")
    End Sub


    Public Function GetNumberCalcResult(var1 As Int16, var2 As Int16)
        Return var1 + var2
    End Function




End Module
#Disable Warning