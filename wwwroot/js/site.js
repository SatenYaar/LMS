﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
  
    //var table = new DataTable('#tblEmpList');

    new DataTable('#tblEmpList');
        //dom: 'Bfrtip',
        //buttons: ['excel', 'pdf', 'print'],
    
    new DataTable('#tblLeavesList');
});
