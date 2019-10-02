Imports System.Data.Entity
Imports CarsInventory
Imports CarsInventory.CarsInventory

Public Class UnitOfWork
    Implements IUnitOfWork

    Private Property ObjectSetTransaction As DbContextTransaction
    Private ReadOnly entities As CarsInventoryEntities = Nothing

    Public Sub New()
        entities = New CarsInventoryEntities()
    End Sub

    'Public Function Repository(Of T As Class)() Implements IUnitOfWork.Repository(Of T)


    '    Return New Repositories(Of T)(entities)
    'End Function

    Public Sub SaveChanges() Implements IUnitOfWork.SaveChanges

        entities.SaveChanges()
    End Sub

    Public Sub BeginTransaction() Implements IUnitOfWork.BeginTransaction

        ObjectSetTransaction = entities.Database.BeginTransaction()
    End Sub

    Public Sub RollBackTransaction() Implements IUnitOfWork.RollBackTransaction

        ObjectSetTransaction.Rollback()
        ObjectSetTransaction.Dispose()
    End Sub

    Public Sub CommitTransaction() Implements IUnitOfWork.CommitTransaction

        ObjectSetTransaction.Commit()
        ObjectSetTransaction.Dispose()
    End Sub

    Private disposed As Boolean = False

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)

        If Not Me.disposed Then

            If disposing Then
                entities.Dispose()
            End If
        End If

        Me.disposed = True
    End Sub

    Public Sub Dispose() Implements IUnitOfWork.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Function Repository(Of T As Class)() As IGenericRepository(Of T) Implements IUnitOfWork.Repository
        Return New Repositories(Of T)(entities)
    End Function
End Class
