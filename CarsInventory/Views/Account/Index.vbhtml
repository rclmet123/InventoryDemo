@Code
    ViewData("Title") = "Login"
End Code

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Bootstrap CRUD Data Table for Database with Modal Form</title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round">
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <script type="text/javascript"> </script>
</head>
<body>
    <div class="container">
        <div class="table-wrapper">
            <div class="table-title">
                <div class="row">
                    <div class="col-sm-4">
                        <h2><b>Account Login</b></h2>
                    </div>
                </div>
            </div>
            @If Not ViewData("ErrorMessage") Is Nothing Then
                @<div Class="alert alert-danger" role="alert">
                    @ViewData("ErrorMessage")
                </div>
            End If
            <div class="table table-striped table-hover">
                <form action="../Account/Index" method="post">
                    <div class="form-group">
                        <label>Email :</label>
                        <input type="email" id="txtEmail" name="userName" class="form-control" required>
                    </div>
                    <div class="form-group">
                        <label>Pasword</label>
                        <input type="password" id="pwd" name="password" class="form-control" required>
                    </div>
                    <input type="submit" class="btn btn-info" value="Login">
                    <input type="button" class="btn btn-default" value="Register" onclick="location.href='../Account/Register'">
                </form>

            </div>
        </div>
    </div>

</body>
</html>


