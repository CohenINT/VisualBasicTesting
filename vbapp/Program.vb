Imports System
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports vbapp.Models

Module Program
    Sub Main(args As String())


        Dim result As String = GetNumberCalcResult()
        Dim User As Models.User
        Console.WriteLine("hoii")
        Console.WriteLine("back to main method, result is {0}", result)
            Console.WriteLine("************** testing json stuff now *******************")
        Dim data As User=GetDataJson()

        
        Console.WriteLine(data.Location)
        Console.WriteLine(data.Username)




    End Sub

    Public Function GetDataJson() As User

        Dim user As User
        Const url As String = "http://localhost:4500/getUser"
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader

        request = DirectCast(WebRequest.Create(url), HttpWebRequest)
        request.Method="POST"
        response = DirectCast(request.GetResponse(),HttpWebResponse)
        reader = New  StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()
        user=JsonConvert.DeserializeObject(Of User)(rawresp)

        Return user

    End Function

    Public Function GetNumberCalcResult()
        Dim resultFinal As String = ""
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
                resultFinal = t.Result.Result


            End If
        Catch e As AggregateException
            Console.WriteLine("Exception is in t")
            Console.WriteLine(e.Message)


        End Try
        Return resultFinal
    End Function




End Module
#Disable Warning