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
   
    <script type="text/javascript">

        $( document ).ready(function() {
            let searchParams = new URLSearchParams(document.location.search);

            if (searchParams.has("Brand")) {
                $('#txtSearchBrand').val(searchParams.get("Brand"))
            }
            if (searchParams.has("Model")) {
                $('#txtSearchModel').val(searchParams.get("Model"))
            }
        });

        function editCar(carid, brand, model, year, price, isNew) {
            if (carid) {
                $('#lblAddEditModalHeader').text("Edit Car")
                $('#hdnCarId').val(carid)
                $('#txtBrand').val(brand)
                $('#txtModel').val(model)
                $('#txtYear').val(year)
                $('#txtPrice').val(price)
                $('#chkIsNew').prop('checked', isNew)
            }
            else {
                $('#lblAddEditModalHeader').text("Add Car")
                $('#hdnCarId').val('0')
                $('#txtBrand').val('')
                $('#txtModel').val('')
                $('#txtYear').val('')
                $('#txtPrice').val('')
                $('#chkIsNew').prop('checked', true)
            }

            $('#editCarModal').modal('show');
        }

        function searchCar() {
            var url = document.location.search
            url = insertParam(document.location.search, 'Brand', $('#txtSearchBrand').val())
            url = insertParam(url, 'Model', $('#txtSearchModel').val())

            document.location.search = url;
        }

        function insertParam(url,key,value)
        {
            key = encodeURIComponent(key); value = encodeURIComponent(value);

            var s = url;
            var kvp = key+"="+value;

            var r = new RegExp("(&|\\?)"+key+"=[^\&]*");

            s = s.replace(r,"$1"+kvp);

            if(!RegExp.$1) {s += (s.length>0 ? '&' : '?') + kvp;};

            return s;
        }

        function deleteCar(carid) {
            $('#hdnCarId').val(carid)
            $('#deleteCarModal').modal('show');
        }

        function saveCar(e) {
            var data = {
                id: $("#hdnCarId").val(),
                brand: $('#txtBrand').val(),
                model: $('#txtModel').val(),
                year: $('#txtYear').val(),
                price: $('#txtPrice').val(),
                isNew: $('#chkIsNew').prop('checked'),
            };


            $.ajax({
                type: "POST",
                url: "@(Url.Action("SaveCar"))",
                content: "application/json; charset=utf-8",
                dataType: "json",
                data: data,
                success: function (d) {
                    if (d == true)
                        window.location.reload()
                    else { }
                },
                error: function (xhr, textStatus, errorThrown) {
                    // TODO: Show error
                }
            });

            e.preventDefault();
        }

        function deleteRecord(e) {
            var data = {
                id: $("#hdnCarId").val()
            };


            $.ajax({
                type: "POST",
                url: "@(Url.Action("deleteCar"))",
                content: "application/json; charset=utf-8",
                dataType: "json",
                data: data,
                success: function (d) {
                    if (d == true)
                        window.location.reload()
                    else { }
                },
                error: function (xhr, textStatus, errorThrown) {
                    // TODO: Show error
                }
            });

            e.preventDefault();
        }
    </script>
</head>
<body>
    <div class="container">
        <div class="table-wrapper">
            <div class="table-title">
                <div class="row">
                    <div class="col-sm-4">
                        <h2><b>Manage Cars</b></h2>
                    </div>
                    <div class="col-sm-8">
                        Brand:
                        <input type="text" id="txtSearchBrand" class="form-control form-control-search" />
                        Model:
                        <input type="text" id="txtSearchModel" class="form-control form-control-search" />
                        <a href="#" onclick="searchCar()" class="btn btn-success" data-toggle="modal"><span>Search</span></a>
                        <a href="#" onclick="editCar()" class="btn btn-success" data-toggle="modal"><i class="material-icons">&#xE147;</i> <span>Add New Car</span></a>
                        @*<a href="#deleteEmployeeModal" class="btn btn-danger" data-toggle="modl"><i class="material-icons">&#xE15C;</i> <span>Delete</span></a>*@
                    </div>
                </div>
            </div>
            <table class="table table-striped table-hover">
                <thead>
                    <tr>
                        <th>Brand</th>
                        <th>Model</th>
                        <th>Year</th>
                        <th>Price</th>
                        <th>Is New</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    @For Each item In Model
                        @<tr>
                            <td>@item.Brand</td>
                            <td>@item.Model</td>
                            <td>@item.Year</td>
                            <td>@item.Price</td>
                            <td><input type="checkbox" checked="@item.IsNew" disabled></td>
                            <td>
                                <a href="#" onclick="editCar(@item.Id, '@item.Brand', '@item.Model', @item.Year, @item.Price, @item.IsNew.ToString().ToLower())" Class="edit" data-toggle="modal"><i Class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>
                                <a href="#" onclick="deleteCar(@item.Id)" Class="delete" data-toggle="modal"><i Class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>
                            </td>
                        </tr>
                    Next item

                </tbody>
            </table>
        </div>
    </div>

    <!-- Edit Modal HTML -->
    <div id="editCarModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <form onsubmit="saveCar(event)">
                    <div class="modal-header">
                        <h4 class="modal-title"><label id="lblAddEditModalHeader" /></h4>
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label>Brand</label>
                            <input type="text" id="txtBrand" class="form-control" required>
                            <input type="hidden" id="hdnCarId">
                        </div>
                        <div class="form-group">
                            <label>Model</label>
                            <input type="text" id="txtModel" class="form-control" required>
                        </div>
                        <div class="form-group">
                            <label>Year</label>
                            <input type="number" id="txtYear" class="form-control" required>
                        </div>
                        <div class="form-group">
                            <label>Price</label>
                            <input type="number" id="txtPrice" class="form-control" required>
                        </div>
                        <div class="form-group">
                            <label>Is New</label>
                            <input type="checkbox" id="chkIsNew">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <input type="button" class="btn btn-default" data-dismiss="modal" value="Cancel">
                        <input type="submit" class="btn btn-info" value="Save">
                    </div>
                </form>
            </div>
        </div>
    </div>
    <!-- Delete Modal HTML -->
    <div id="deleteCarModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <form onsubmit="deleteRecord(event)">
                    <div class="modal-header">
                        <h4 class="modal-title">Delete Car</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    </div>
                    <div class="modal-body">
                        <p>Are you sure you want to delete this Records?</p>
                        <p class="text-warning"><small>This action cannot be undone.</small></p>
                    </div>
                    <div class="modal-footer">
                        <input type="button" class="btn btn-default" data-dismiss="modal" value="Cancel">
                        <input type="submit" class="btn btn-danger" value="Delete">
                    </div>
                </form>
            </div>
        </div>
    </div>

</body>
</html>
