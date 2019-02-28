
function SeachUser() {
    $.ajax({
        url: "/User/Seach",
        data: {
            Page: 1,
            FullName: $("#txtSeachNameUser").val(),
            UserName: $("#txtSeachUserName").val(),
            Phone: $("#txtSeachPhoneUser").val(),
            Group: $("#txtSeachGroupUser").val(),
        },
        success: function (result) {
            $("#Table_User").html(result);
        }
    });
}

function GetListGroupUser() {
    $.ajax({
        url: "/GroupUser/GetListGroup",
        success: function (result) {
            $.each(result, function (i, result) {
                $('#txtSeachGroupUser').append($('<option>', {
                    value: result.ID,
                    text: result.GroupName
                }));
            });

            $.each(result, function (i, result) {
                $('#SelectAddGroupIdUser').append($('<option>', {
                    value: result.ID,
                    text: result.GroupName
                }));
            });

            $.each(result, function (i, result) {
                $('#txtEditGroupUser').append($('<option>', {
                    value: result.ID,
                    text: result.GroupName
                }));
            });


            
        }
    });
}



function AddUser() {

    $.ajax({
        url: "/User/AddUser",
        data: $("#FormAdd_User").serialize(),
        success: function (result) {
            if (result) {
                $("#Modal_AdđUser").hide();
                swal("Thông Báo!", "Thêm mới thành công", "success");
            }
            else {

            }
            SeachUser();
        }
    });
}

function EditUser() {

    $.ajax({
        url: "/User/EditUser",
        data: $("#Form_EditUser").serialize(),
        success: function (result) {
            if (result) {
                $("#Modal_EditUser").hide();
                swal("Thông Báo!", "Cập nhập thành công tài khoản", "success");
            }
            else {

            }
            SeachUser();
        }
    });
}


function GetUserById(Id) {
    $.ajax({
        url: "/User/GetUserById",
        data: { Id: Id },
        success: function (result) {
            $("#txtEditIdUser").val(result.ID);
            $("#txtEditNameUser").val(result.Name);
            $("#txtEditUserName").val(result.UserName);
            $("#txtEditEmail").val(result.Email);
            $("#txtEditPhone").val(result.Phone);
            $("#txtEditGroupUser").val(result.GroupId);
            if (result.Status == true) {
                $('#txtEditStatusUser').val('true').prop('selected', true);
            }
            else {
                $('#txtEditStatusUser').val('false').prop('selected', true);
            }
            $("#Modal_EditUser").show();
        }
    });
}


var IDDelete = 0;
function ShowFromDeleteUser(Id) {
    IDDelete = Id;
    $("#Delete_Users").show();
}

function DelUser() {
    $.ajax({
        url: "/User/DeleteUser",
        data: { Id: IDDelete },
        success: function (result) {
            if (result == 1) {
                $("#Delete_Users").hide();
                swal("Thông Báo!", "Xóa tài khoản thành công", "success");
            }

            SeachUser();
        }
    });
}

$(document).ready(function () {
    GetListGroupUser(); 
});