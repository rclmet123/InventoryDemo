Interface IUnitOfWork
    Inherits IDisposable
    Function Repository(Of T As Class)() As IGenericRepository(Of T)
    Sub SaveChanges()
    Sub BeginTransaction()
    Sub RollBackTransaction()
    Sub CommitTransaction()

End Interface