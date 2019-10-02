Imports System.Data.Entity
Imports CarsInventory.CarsInventory

Public Class Repositories(Of T As Class)
    Implements IGenericRepository(Of T)

    Friend ReadOnly dbSet As DbSet(Of T) = Nothing
    Friend ReadOnly context As CarsInventoryEntities = Nothing

    Public Sub New(ByVal entities As CarsInventoryEntities)
        Me.context = entities
        Me.dbSet = entities.[Set](Of T)
    End Sub

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