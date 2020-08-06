Namespace Models
    Public Class User
      

        Property Username() As String
        Property Age() As String
        Property Location  () As String
        Property Language() As String


        Public Sub New ()
            Username=""
            Location=""
            Age=0
            Language=""
        End Sub

        Public Sub New (user As String,loc As String,age As String,lang As String)
            Username=user
            Location=loc
            Me.Age=age
            Language=lang
        End Sub



    End Class
End NameSpace