﻿<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Bootstrap CRUD Data Table for Database with Modal Form</title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round">
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">

    <style type="text/css">
        body {
            color: #566787;
            background: #f5f5f5;
            font-family: 'Varela Round', sans-serif;
            font-size: 13px;
        }

        .form-control-search {
            display: inline;
            width: auto;
        }

        .table-wrapper {
            background: #fff;
            padding: 20px 25px;
            margin: 30px 0;
            border-radius: 3px;
            box-shadow: 0 1px 1px rgba(0,0,0,.05);
        }

        .table-title {
            padding-bottom: 15px;
            background: #435d7d;
            color: #fff;
            padding: 16px 30px;
            margin: -20px -25px 10px;
            border-radius: 3px 3px 0 0;
        }

            .table-title h2 {
                margin: 5px 0 0;
                font-size: 24px;
            }

            .table-title .btn-group {
                float: right;
            }

            .table-title .btn {
                color: #fff;
                font-size: 13px;
                border: none;
                min-width: 50px;
                border-radius: 2px;
                border: none;
                outline: none !important;
                margin-left: 10px;
            }

                .table-title .btn i {
                    float: left;
                    font-size: 21px;
                    margin-right: 5px;
                }

                .table-title .btn span {
                    float: left;
                    margin-top: 2px;
                }

        table.table tr th, table.table tr td {
            border-color: #e9e9e9;
            padding: 12px 15px;
            vertical-align: middle;
        }

            table.table tr th:first-child {
                width: 60px;
            }

            table.table tr th:last-child {
                width: 100px;
            }

        table.table-striped tbody tr:nth-of-type(odd) {
            background-color: #fcfcfc;
        }

        table.table-striped.table-hover tbody tr:hover {
            background: #f5f5f5;
        }

        table.table th i {
            font-size: 13px;
            margin: 0 5px;
            cursor: pointer;
        }

        table.table td:last-child i {
            opacity: 0.9;
            font-size: 22px;
            margin: 0 5px;
        }

        table.table td a {
            font-weight: bold;
            color: #566787;
            display: inline-block;
            text-decoration: none;
            outline: none !important;
        }

            table.table td a:hover {
                color: #2196F3;
            }

            table.table td a.edit {
                color: #FFC107;
            }

            table.table td a.delete {
                color: #F44336;
            }

        table.table td i {
            font-size: 19px;
        }

        table.table .avatar {
            border-radius: 50%;
            vertical-align: middle;
            margin-right: 10px;
        }

        .pagination {
            float: right;
            margin: 0 0 5px;
        }

            .pagination li a {
                border: none;
                font-size: 13px;
                min-width: 30px;
                min-height: 30px;
                color: #999;
                margin: 0 2px;
                line-height: 30px;
                border-radius: 2px !important;
                text-align: center;
                padding: 0 6px;
            }

                .pagination li a:hover {
                    color: #666;
                }

            .pagination li.active a, .pagination li.active a.page-link {
                background: #03A9F4;
            }

                .pagination li.active a:hover {
                    background: #0397d6;
                }

            .pagination li.disabled i {
                color: #ccc;
            }

            .pagination li i {
                font-size: 16px;
                padding-top: 6px
            }

        .hint-text {
            float: left;
            margin-top: 10px;
            font-size: 13px;
        }
        /* Custom checkbox */
        .custom-checkbox {
            position: relative;
        }

            .custom-checkbox input[type="checkbox"] {
                opacity: 0;
                position: absolute;
                margin: 5px 0 0 3px;
                z-index: 9;
            }

            .custom-checkbox label:before {
                width: 18px;
                height: 18px;
            }

            .custom-checkbox label:before {
                content: '';
                margin-right: 10px;
                display: inline-block;
                vertical-align: text-top;
                background: white;
                border: 1px solid #bbb;
                border-radius: 2px;
                box-sizing: border-box;
                z-index: 2;
            }

            .custom-checkbox input[type="checkbox"]:checked + label:after {
                content: '';
                position: absolute;
                left: 6px;
                top: 3px;
                width: 6px;
                height: 11px;
                border: solid #000;
                border-width: 0 3px 3px 0;
                transform: inherit;
                z-index: 3;
                transform: rotateZ(45deg);
            }

            .custom-checkbox input[type="checkbox"]:checked + label:before {
                border-color: #03A9F4;
                background: #03A9F4;
            }

            .custom-checkbox input[type="checkbox"]:checked + label:after {
                border-color: #fff;
            }

            .custom-checkbox input[type="checkbox"]:disabled + label:before {
                color: #b8b8b8;
                cursor: auto;
                box-shadow: none;
                background: #ddd;
            }
        /* Modal styles */
        .modal .modal-dialog {
            max-width: 400px;
        }

        .modal .modal-header, .modal .modal-body, .modal .modal-footer {
            padding: 20px 30px;
        }

        .modal .modal-content {
            border-radius: 3px;
        }

        .modal .modal-footer {
            background: #ecf0f1;
            border-radius: 0 0 3px 3px;
        }

        .modal .modal-title {
            display: inline-block;
        }

        .modal .form-control {
            border-radius: 2px;
            box-shadow: none;
            border-color: #dddddd;
        }

        .modal textarea.form-control {
            resize: vertical;
        }

        .modal .btn {
            border-radius: 2px;
            min-width: 100px;
        }

        .modal form label {
            font-weight: normal;
        }
    </style>
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
