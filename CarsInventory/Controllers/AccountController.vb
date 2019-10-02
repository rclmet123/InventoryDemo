Imports System.Web.Mvc
Imports CarsInventory.CarsInventory

Namespace Controllers
    Public Class AccountController
        Inherits Controller

        Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(GetType(AccountController))

        ' GET: Account
        Function Index() As ActionResult
            Return View()
        End Function

        <AcceptVerbs(HttpVerbs.Post)>
        Function Index(user As User) As ActionResult

            Try
                If ModelState.IsValid Then

                    Dim uom As New UnitOfWork
                    Dim userExist = uom.Repository(Of User).GetAll(Function(x) x.Username = user.Username AndAlso x.Password = user.Password).FirstOrDefault()

                    If Not userExist Is Nothing Then
                        Session("UserId") = userExist.Id
                        Session("UserName") = userExist.Username
                        Return RedirectToAction("Index", "Home")
                    End If
                End If

                ViewData("ErrorMessage") = "User name and password are incorrect."

            Catch ex As Exception
                log.Error(ex)
            End Try

            Return View()

        End Function

        Function Register() As ActionResult
            Return View()
        End Function

        <AcceptVerbs(HttpVerbs.Post)>
        Function Register(user As User) As ActionResult

            Try

                If ModelState.IsValid Then

                    Dim uom As New UnitOfWork

                    Dim IsUserExists = uom.Repository(Of User).GetAll(Function(x) x.Username = user.Username).FirstOrDefault()

                    If Not IsUserExists Is Nothing Then
                        ViewData("ErrorMessage") = "Email already registred."
                        Return View()
                    End If
                    'Dim userExist = uom.Repository(Of User).Get(user)
                    'If Not userExist Is Nothing Then

                    'End If
                    uom.BeginTransaction()
                    uom.Repository(Of User).Add(user)
                    uom.SaveChanges()

                    uom.CommitTransaction()

                    Session("UserId") = user.Id
                    Session("UserName") = user.Username

                    Return RedirectToAction("Index", "Home")

                End If

                ViewData("ErrorMessage") = "Some error occured while creating user."


            Catch ex As Exception
                log.Error(ex)
            End Try

            Return View()

        End Function

    End Class
End Namespace