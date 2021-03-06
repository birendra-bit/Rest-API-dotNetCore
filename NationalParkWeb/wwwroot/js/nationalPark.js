﻿var dataTable;
$(document).ready(function () {
    //loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').dataTable({
        "ajax": {
            "url": "/nationalPark/GetAllNationalPark",
            "type": "GET",
            "dataType": "json"
        },
        "colums": [
            { "data": "name", "width": "50%" },
            { "data": "state", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/nationalPark/Upsert/${data}" class='btn btn-success text-white'
                                    style='cursor:pointer;'><i class='far fa-edit'></i></a>
                                <a onclick="Delete(/nationalPark/Delete/${data})" class='btn btn-danger text-white'
                                    style='cursor:pointer;'><i class='far fa-trash-alt'></i></a>
                            </div>`;
                }, "width": "30%"
            }
        ]
    });
}