Public Interface IGenericRepository(Of T As Class)

    Function GetAll(ByVal Optional predicate As Func(Of T, Boolean) = Nothing) As IEnumerable(Of T)

    'Function GetAll() As IEnumerable
    Sub Add(ByVal entity As T)
    Sub Delete(ByVal entity As T)
    Function [Get](ByVal Id As Object) As T
    Sub Update(ByVal entity As T)

End Interface
