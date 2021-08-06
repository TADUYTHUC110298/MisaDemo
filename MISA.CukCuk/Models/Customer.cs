using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Models
{
    public class Customer
    {
        public static List<Customer> CustomerList = new List<Customer>() {
        new Customer() { EmployeeCode = "NV01", EmployeeName = "NVA", Email = "NVA@GMAIL.COM", Mobile = "099999999"} ,
        new Customer() { EmployeeCode = "NV02", EmployeeName = "NVB", Email = "NVB@GMAIL.COM", Mobile = "099999998"} ,
        new Customer() { EmployeeCode = "NV03", EmployeeName = "NVC", Email = "NVC@GMAIL.COM", Mobile = "099999997"} ,
        new Customer() { EmployeeCode = "NV04", EmployeeName = "NVD", Email = "NVD@GMAIL.COM", Mobile = "099999996"} ,
        new Customer() { EmployeeCode = "NV05", EmployeeName = "NVF", Email = "NVF@GMAIL.COM", Mobile = "099999995"}
    };

        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
