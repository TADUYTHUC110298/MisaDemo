using System;
using System.Collections.Generic;

namespace MISA.CukCuk.Models
{
    public partial class ViewEmployee
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int? Gender { get; set; }
        public string GenderName
        {
            get {
                if (Gender == 1)
                    return "Nam";
                else
                    return "Nữ";
            }
        }

        public DateTime? DateOfBirth { get; set; }
        public string CitizenIdentityCode { get; set; }
        public string CitizebIdentityPlace { get; set; }
        public DateTime? CitizebIdentityDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? WorkState { get; set; }
        public string WorkStateName
        {
            get
            {
                switch (WorkState)
                {
                    case 0:
                        return "Đã nghỉ việc";
                    case 1:
                        return "Đang làm việc";
                    case 2:
                        return "Đang thử việc";
                    default:
                        return string.Empty;
                }
            }
        }
        public Guid? PositionId { get; set; }
        public Guid? DepartmentId { get; set; }
        public string SelfTaxCode { get; set; }
        public double? Salary { get; set; }
        public DateTime? JoinDate { get; set; }
        public string PositionName { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public Guid? DepartmentParentId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
