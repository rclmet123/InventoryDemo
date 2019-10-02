Interface IUnitOfWork
    Inherits IDisposable

    'Private ReadOnly Property Categories As ICategoryRepository
    'Private ReadOnly Property Products As IProductRepository
    Function Repository(Of T As Class)() As IGenericRepository(Of T)
    Sub SaveChanges()
    Sub BeginTransaction()
    Sub RollBackTransaction()
    Sub CommitTransaction()

End Interface