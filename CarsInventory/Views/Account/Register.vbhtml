@Code
    ViewData("Title") = "Register"
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
                        <h2><b>Account Register</b></h2>
                    </div>
                </div>
            </div>
            @If Not ViewData("ErrorMessage") Is Nothing Then
                @<div Class="alert alert-danger" role="alert">
                    @ViewData("ErrorMessage")
                </div>
            End If
            <div Class="table table-striped table-hover">
                <form action="../Account/Register" method="post">
                    <div Class="form-group">
                        <Label> Name :   </Label>
                        <input type="text" id="txtName" name="name" Class="form-control" required>
                    </div>
                    <div Class="form-group">
                        <Label> Email :   </Label>
                        <input type="email" id="txtEmail" name="userName" Class="form-control" required>
                    </div>
                    <div Class="form-group">
                        <Label> Pasword</Label>
                        <input type="password" id="pwd" name="password" Class="form-control" required>
                    </div>
                    <input type="submit" Class="btn btn-info" value="Register">
                    <input type="button" Class="btn btn-default" value="Login" onclick="location.href='../Account/Index'">
                </form>

            </div>
        </div>
    </div>

</body>
</html>


