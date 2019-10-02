Imports System.Data.Entity
Imports CarsInventory
Imports CarsInventory.CarsInventory

Public Class Repositories(Of T As Class)
    Implements IGenericRepository(Of T)

    Friend ReadOnly dbSet As DbSet(Of T) = Nothing
    Friend ReadOnly context As CarsInventoryEntities = Nothing

    Public Sub New(ByVal entities As CarsInventoryEntities)
        Me.context = entities
        Me.dbSet = entities.[Set](Of T)
    End Sub

    'Public Sub New(ByVal objectSet As IDbSet(Of T))
    '    Me.objectSet = objectSet
    'End Sub

    'Function GetAll(ByVal Optional predicate As Func(Of T, Boolean) = Nothing) As IEnumerable(Of T)
    '    If predicate IsNot Nothing Then
    '        Return objectSet.Where(predicate)
    '    End If

    '    Return objectSet.AsEnumerable()
    'End Function

    'Public Function [Get](ByVal predicate As Func(Of T, Boolean)) Implements
    '        IGenericRepository.Get() As T
    '    Return objectSet.FirstOrDefault(predicate)
    'End Function

    'Sub Add(ByVal entity As T) Implements
    '         IGenericRepository.Add(ByVal entity As T)

    '    objectSet.Add(entity)
    'End Sub

    'Sub Attach(ByVal entity As T)
    '    dbSet.Attach(entity)
    'End Sub

    'Sub Delete(ByVal entity As T)
    '    objectSet.Remove(entity)
    'End Sub

    'Public Function GetAll() As IEnumerable Implements IGenericRepository(Of T).GetAll
    '    'Throw New NotImplementedException()
    '    Return objectSet.AsEnumerable()

    'End Function

    Public Function GetAll(Optional predicate As Func(Of T, Boolean) = Nothing) As IEnumerable(Of T) Implements IGenericRepository(Of T).GetAll
        ' Dim query As IQueryable(Of T) = dbSet

        If predicate IsNot Nothing Then
            Return dbSet.Where(predicate).ToList()
        End If

        Return dbSet.ToList()

    End Function

    Sub Add(entity As T) Implements IGenericRepository(Of T).Add
        dbSet.Add(entity)
    End Sub

    Sub Delete(entity As T) Implements IGenericRepository(Of T).Delete
        dbSet.Remove(entity)
    End Sub

    Function [Get](Id As Object) As T Implements IGenericRepository(Of T).Get
        Return dbSet.Find(Id)
    End Function

    Sub Update(entity As T) Implements IGenericRepository(Of T).Update
        dbSet.Attach(entity)
        Me.context.Entry(entity).State = EntityState.Modified
    End Sub


End Class