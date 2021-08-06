
var commonJS = {
    LanguageCode: "EN",
    /**
    * Hàm định dạng hiển thị tiền
    * @param {number} money

    */
    formatMoney(money) {
        if (money||money==0) {
            return money.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.');
        }
        return null;
    },

    /**
    * Tạo chuỗi HTML checkbox tương ứng với true/false
    * @param {boolean} value true: checked
    */
    buildCheckBoxByValue(value) {
        var checkBoxHTML = $(`<input type="checkbox" disabled/>`);
        if (value) {
            checkBoxHTML = checkBoxHTML.attr("checked", true);
        }
        return checkBoxHTML[0].outerHTML;
    },

    /**
     * Hàm định dạng ngày hiển thị (dd/MM/yyyy)
     * @param {any} date
     */
    formatDate(date) {
        if (date && !isNaN(date.getDate())) {
            var day = date.getDate();
            var month = date.getMonth() + 1;
            var year = date.getFullYear();
            month = (month < 10) ? "0" + month : month;
            day = (day < 10) ? "0" + day : day;
            return day + "/" + month + "/" + year;
        }
        return null;
    }
}