
$(document).ready(function () {
    //load dữ liệu:
    customerJs = new EmployeeJS();
})

/**
 * Object JS quản lý các sự kiện cho trang danh mục khách hàng.
 * */
class EmployeeJS {
    constructor() {
        try {
            var me = this;
            me.loadData();
            me.initEvent();
            me.FormMode = null;
            $("#frmDialogDetail").show();
        } catch (e) {

        }

    }

    /**
     * Thực hiện gán các sự kiện cho các thành phần trong trang
     * */
    initEvent() {
        //$("#btnAdd").click(this.showDialog);
        $("#btnAdd").on("click", Enum.FormMode.Add, this.toolbarItemOnClick.bind(this));
        $("#btnEdit").on("click", Enum.FormMode.Edit, this.toolbarItemOnClick.bind(this));
        $("#btnDelete").on("click", Enum.FormMode.Delete, this.toolbarItemOnClick.bind(this));
        //$("#btnEdit").click(this.showDialog);
        $("#btnCancelDialog").click(this.btnCloseOnClick);
        $("#btnCloseHeader").click(this.btnCloseHeaderOnClick);
        $("#btnSaveDetail").click(this.saveData.bind(this));
        $("table").on("click", "tbody tr", this.rowOnClick);
        $("table").on("dbclick", "tbody tr", this.rowOnDbClick);
    }

    ///**
    // * Sự kiện khi click button thêm mới
    // * */
    //btnAddToolbarOnClick() {
    //    $("#frmDialogDetail").show();
    //}

    //btnEditToolbarOnClick() {
    //    $("#frmDialogDetail").show();
    //}

    toolbarItemOnClick(sender) {
        try {
            var me = this;
            var formMode = sender.data;
            switch (formMode) {
                case Enum.FormMode.Add:
                    this.FormMode = Enum.FormMode.Add;
                    $("#frmDialogDetail").show();
                    // set giá trị mặc định cho các control nhập liệu"
                    $("#frmDialogDetail input").val("");
                    $("#frmDialogDetail input[type='checkbox']").prop("checked", false);
                    $('#frmDialogDetai input')[0].focus();
                    break;
                case Enum.FormMode.Edit:
                    this.FormMode = Enum.FormMode.Edit;
                    var rowSelected = $('tr.row-selected');
                    if (rowSelected && rowSelected.length == 1) {
                        var customerId = $('tr.row-selected').data('id');
                        this.CustomerId = customerId;
                        $.ajax({
                            url: "/api/v1/employees/" + customerId,
                            method: "GET",
                            //data: {},
                            dataType: "json",
                            contentType: "application/json",
                        }).done(function (res) {
                            // Thực hiện binding dữ liệu lên form chi tiết:
                            var customer = res;
                            $('#txtCustomerCode').val(customer['CustomerCode']);
                            $('#txtCustomerName').val(customer['CustomerName']);
                        }).fail(function () {
                            alert("Lỗi");
                        });
                        $("#frmDialogDetail").show();
                        $('#frmDialogDetai input')[0].focus();
                    }
                case Enum.FormMode.Delete:
                    var rowSelected = $('tr.row-selected');
                    if (rowSelected && rowSelected.length == 1) {
                        var customerId = $('tr.row-selected').data('id');
                        $.ajax({
                            url: "/api/v1/employees/" + customerId,
                            method: "DELETE",
                        }).done(function (res) {
                            // Thực hiện binding dữ liệu lên form chi tiết:
                            me.loadData();
                        }).fail(function () {
                            alert("Lỗi");
                        });
                    }
                    break;
                default:
            }

        } catch (e) {

        }

    }
    /**
    * Sự kiện khi click button đóng dưới footer của Dialog
    * */
    btnCloseOnClick() {
        $("#frmDialogDetail").hide();
    }

    /**
    * Sự kiện khi click Đóng trên tiêu đề của Dialog
    * */
    btnCloseHeaderOnClick() {
        $("#frmDialogDetail").hide();
    }

    /**
    * Sự kiện khi click chọn 1 dòng trong table
    * */
    rowOnClick(sender) {
        this.classList.add("row-selected");
        $(this).siblings().removeClass("row-selected");

    }

    /**
     * 
     * */
    //TODO: rowOnDbClick (Develop in progress)
    rowOnDbClick(sender) {
        $("#frmDialogDetail").show();
    }

    /**
    * Load dữ liệu
    * */
    loadData() {
        try {
            $('table#tbListCustomer tbody').empty();
            $.ajax({
                url: "/api/v1/employees",
                method: "GET",
                //data: {},
                dataType: "json",
                contentType: "application/json",
            }).done(function (response) {
                if (response) {
                    // Đọc dữ liệu và gen dữ liệu từng khách hàng với HTML:
                    $.each(response, function (index, item) {
                        var customerInfoHTML = $(`<tr class='grid-row'>
                                <td class='grid-cell-inner'>`+ item['EmployeeCode'] + `</td>
                                <td class='grid-cell-inner'>`+ item['FullName'] + `</td>
                                <td class='grid-cell-inner'>`+ item['GenderName'] + `</td>
                                <td class="grid-cell-inner align-center">`+ (commonJS.formatDate(new Date(item['DateOfBirth'])) || '') + `</td>
                                <td class='grid-cell-inner'>`+ (item['PhoneNumber'] || '') + `</td>
                                <td class='grid-cell-inner'>`+ (item['Email'] || '') + `</td>
                                <td class='grid-cell-inner'>`+ (item['PositionName'] || '') + `</td>
                                <td class='grid-cell-inner'>`+ (item['DepartmentName'] || '') + `</td>
                                <td class="grid-cell-inner align-right">`+ (commonJS.formatMoney(item['Salary']) || '') + `</td>
                                <td class='grid-cell-inner'>`+ (item['WorkStateName'] || '') + `</td>
                            </tr>`);
                        customerInfoHTML.data("id", item['CustomerID']);
                        $('table#tbListCustomer tbody').append(customerInfoHTML);
                    })
                    // Mặc định chọn bản ghi đầu tiên có trong danh sách:
                    $('table#tbListCustomer tbody tr').first().addClass('row-selected');
                }
            }).fail(function (response) {
                alert("Có lỗi xảy ra vui lòng liên hệ MISA để được trợ giúp");
            })

        } catch (e) {
            console.log(e);
        }

    }

    /**
     * Cất dữ liệu
     * CreatedBy: NVMANH (21/07/2020)
     * */
    saveData(sender, a, b, c) {
        debugger;
        var me = this;
        // Lấy dữ liệu được nhập từ các input:
        var customerCode = $("#txtCustomerCode").val(),
            customerName = $("#txtCustomerName").val(),
            bithday = $("#dtBirthday").val() || null,
            mobile = $("#txtMobile").val(),
            debitAmount = $("#txtDebitAmount").val() || null,
            is5Food = $("#ckIs5FoodMember").is(":checked");

        // Từ các dữ liệu thu thập được thì build thành object khách hàng (customer)
        var customer = {
            CustomerCode: customerCode,
            CustomerName: customerName,
            Birthday: new Date(bithday),
            PhoneNumber: mobile,
            DebitAmount: debitAmount,
            Is5FoodMember: is5Food
        };
        if (me.FormMode == Enum.FormMode.Add) {
            // Lưu dữ liệu vào database:
            $.ajax({
                url: "/api/v1/employees",
                method: "POST",
                data: JSON.stringify(customer),
                dataType: "text",
                contentType: "application/json"
            }).done(function (res) {
                // Hiển thị thông báo cất thành công/ thất bại:
                alert("Cất thành công!")
                // Đóng/ ẩn Form:
                $("#frmDialogDetail").hide();
                // load lại dữ liệu
                me.loadData();
            }).fail(function (res) {
                debugger
            });
        } else if (me.FormMode == Enum.FormMode.Edit) {
            // Lưu dữ liệu vào database:
            $.ajax({
                url: "/api/v1/employees/" + me.CustomerId,
                method: "PUT",
                data: JSON.stringify(customer),
                dataType: "text",
                contentType: "application/json"
            }).done(function (res) {
                // Hiển thị thông báo cất thành công/ thất bại:
                alert("Cất thành công!")
                // Đóng/ ẩn Form:
                $("#frmDialogDetail").hide();
                // load lại dữ liệu
                me.loadData();
            }).fail(function (res) {
                debugger
            });
        }

    }
}

var fakeData = [
    {
        CustomerCode: "KH0001",
        CustomerName: "Nguyễn Văn Mạnh",
        Birthday: new Date(1989, 5, 1),
        PhoneNumber: "0977340334",
        DebitAmount: 10000000,
        Is5FoodMember: false
    },
    {
        CustomerCode: "KH0002",
        CustomerName: "Nguyễn Văn Mạnh",
        Birthday: new Date(1989, 5, 1),
        PhoneNumber: "0977340334",
        DebitAmount: 10000000,
        Is5FoodMember: true
    },
    {
        CustomerCode: "KH0003",
        CustomerName: "Nguyễn Văn Mạnh",
        Birthday: new Date(1989, 5, 1),
        PhoneNumber: "0977340334",
        DebitAmount: 10000000,
        Is5FoodMember: false
    },
    {
        CustomerCode: "KH0004",
        CustomerName: "Nguyễn Văn Mạnh",
        Birthday: new Date(1989, 5, 1),
        PhoneNumber: "0977340334",
        DebitAmount: 10000000,
        Is5FoodMember: true
    },

]
