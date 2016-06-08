Public Class folha


    Private _numero As String
    Public Property Numero() As String
        Get
            Return _numero
        End Get
        Set(ByVal value As String)
            _numero = value
        End Set
    End Property


    Private _rota As String
    Public Property Rota() As String
        Get
            Return _rota
        End Get
        Set(ByVal value As String)
            _rota = value
        End Set
    End Property


    Private _zona As String
    Public Property Zona() As String
        Get
            Return _zona
        End Get
        Set(ByVal value As String)
            _zona = value
        End Set
    End Property



    Private _lido As Boolean
    Public Property Lido() As Boolean
        Get
            Return _lido
        End Get
        Set(ByVal value As Boolean)
            _lido = value
        End Set
    End Property


    Sub New(ByVal numero As String, ByVal rota As String, ByVal zona As String)

        _numero = numero
        _rota = rota
        _zona = zona

    End Sub


End Class
