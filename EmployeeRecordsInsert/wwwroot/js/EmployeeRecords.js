

function saveData() {

    var EmployeeModel = new Object();
    EmployeeModel.EmployeeName = $("#EmployeeName").val(),
    EmployeeModel.DateOfBirth = $("#DateOfBirth").val(),
    EmployeeModel.Gender = $("#Gender").val(),
    EmployeeModel.Department = $("#Department").val(),
    EmployeeModel.Designation = $("#Designation").val(),
    EmployeeModel.BasicSalary = parseFloat($("#BasicSalary").val())

    $.ajax({
        type: "POST",
        url: '/Employee/Save',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
        }
    });
}