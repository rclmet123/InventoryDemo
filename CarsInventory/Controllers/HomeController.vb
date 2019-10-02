Imports CarsInventory.CarsInventory

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(GetType(HomeController))

    'Load Cars data by logged in user
    Function Index(Brand As String, Model As String) As ActionResult

        Try
            If Not Session("UserId") Is Nothing Then

                Dim uom As New UnitOfWork

                Dim data As IEnumerable(Of Car) = Nothing

                If Not String.IsNullOrWhiteSpace(Brand) And Not String.IsNullOrWhiteSpace(Model) Then
                    data = uom.Repository(Of Car).GetAll(Function(x) x.Brand.ToLower().Contains(Brand.ToLower()) AndAlso x.Model.ToLower().Contains(Model.ToLower()) AndAlso x.CreatedBy = CInt(Session("UserId"))).ToList()
                ElseIf Not String.IsNullOrWhiteSpace(Model) And String.IsNullOrWhiteSpace(Brand) Then
                    data = uom.Repository(Of Car).GetAll(Function(x) x.Model.ToLower().Contains(Model.ToLower()) AndAlso x.CreatedBy = CInt(Session("UserId"))).ToList()
                ElseIf Not String.IsNullOrWhiteSpace(Brand) And String.IsNullOrWhiteSpace(Model) Then
                    data = uom.Repository(Of Car).GetAll(Function(x) x.Brand.ToLower().Contains(Brand.ToLower()) AndAlso x.CreatedBy = CInt(Session("UserId"))).ToList()
                Else
                    data = uom.Repository(Of Car).GetAll((Function(x) x.CreatedBy = CInt(Session("UserId"))))
                End If

                Return View(data)
            End If

        Catch ex As Exception
            log.Error(ex)
        End Try

        Return RedirectToAction("Index", "Account")

    End Function

    'Logout Method
    Function Logout() As ActionResult

        Session.Clear()
        Return RedirectToAction("Index", "Account")

    End Function

    'Add/Edit Car
    Function SaveCar(id As Integer, brand As String, model As String, year As Integer, price As Decimal, isNew As Boolean) As ActionResult

        Dim uom As New UnitOfWork

        Try
            uom.BeginTransaction()
            Dim dataModel As New Car
            dataModel.Id = id
            dataModel.Brand = brand
            dataModel.Model = model
            dataModel.Year = year
            dataModel.Price = price
            dataModel.IsNew = isNew
            dataModel.CreatedBy = CInt(Session("UserId"))

            If (id > 0) Then
                uom.Repository(Of Car).Update(dataModel)
            Else
                uom.Repository(Of Car).Add(dataModel)
            End If

            uom.SaveChanges()

            uom.CommitTransaction()

            Return Json(True)

        Catch ex As Exception
            uom.RollBackTransaction()
            log.Error(ex)
        End Try

        Return Json(False)

    End Function

    'Delete Car
    Function DeleteCar(id As Integer) As ActionResult

        Dim uom As New UnitOfWork

        Try
            uom.BeginTransaction()

            If (id > 0) Then
                Dim car = uom.Repository(Of Car).GetAll(Function(e) e.Id = id).FirstOrDefault()
                uom.Repository(Of Car).Delete(car)
            End If

            uom.SaveChanges()

            uom.CommitTransaction()

            Return Json(True)

        Catch ex As Exception
            uom.RollBackTransaction()
            log.Error(ex)
        End Try

        Return Json(False)

    End Function

End Class
