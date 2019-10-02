Imports CarsInventory.CarsInventory

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index(Brand As String, Model As String) As ActionResult
        If Not Session("UserId") Is Nothing Then

            Dim uom As New UnitOfWork

            Dim data = uom.Repository(Of Car).GetAll().Where(Function(x) x.CreatedBy = CInt(Session("UserId")))

            'Check if filter exist then filter records
            If Not Brand Is Nothing Then
                data = data.Where(Function(x) x.Brand.ToLower().Contains(Brand.ToLower())).ToList()
            End If
            If Not Model Is Nothing Then
                data = data.Where(Function(x) x.Model.ToLower().Contains(Model.ToLower())).ToList()
            End If

            Return View(data)
        End If

        Return RedirectToAction("Index", "Account")
    End Function

    Function Logout() As ActionResult

        Session.Clear()
        Return RedirectToAction("Index", "Account")

    End Function

    Function SaveCar(id As Integer, brand As String, model As String, year As Integer, price As Decimal, isNew As Boolean) As ActionResult

        Dim uom As New UnitOfWork

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
    End Function

    Function DeleteCar(id As Integer) As ActionResult

        Dim uom As New UnitOfWork

        uom.BeginTransaction()

        If (id > 0) Then
            Dim car = uom.Repository(Of Car).GetAll().Where(Function(e) e.Id = id).FirstOrDefault()
            uom.Repository(Of Car).Delete(car)
        End If

        uom.SaveChanges()

        uom.CommitTransaction()

        Return Json(True)
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
