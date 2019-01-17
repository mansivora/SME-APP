using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_App.Models
{
    public class APIModel
    {
        public int CustomerID { get; set; }
        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        [DisplayName("Company Type")]
        public string CompanyTypeName { get; set; }
        public string IncCountryName { get; set; }
        public string TradeLicUpd { get; set; }
        public string DUNSNo { get; set; }
        public decimal? AnnTurnover { get; set; }
        public int? CurrencyID { get; set; }
        public string CurrencyName { get; set; }
        public string AccessType { get; set; }
        public string NoEmp { get; set; }
        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        [DisplayName("Designation Name")]
        public string DesignationName { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(200)]
        [DataType(DataType.Text)]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(30)]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Mobile Number")]
        public string MobileNo { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid Email ID")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email ID")]
        public string EmailID { get; set; }

        [StringLength(100)]
        [DataType(DataType.Text)]
        [DisplayName("Website")]
        public string Website { get; set; }

      
        public string TradeLicenceNo { get; set; }
        public int CompanyTypeID { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        [DisplayName("Trading Name")]
        public string TradingName { get; set; }

        [Required]
        [DisplayName("Authority Country")]
        public string AuthCountry { get; set; }

        [Required]
        [Range(1, 10000)]
        [DisplayName("IncCountry Name")]
        public int IncCountryID { get; set; }

        [Required]
        [StringLength(30)]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        public string TelNo { get; set; }
        public int DesignationID { get; set; }

        public string BusinessActivity { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        [DisplayName("Licence Exp Date")]
        public string LicenceExpDate { get; set; }
        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        [DisplayName("Inc Date")]
        public string IncDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string OtherCompanyTypeName { get; set; }
        public string OtherDesignationName { get; set; }
     

        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        [DisplayName("Name")]
        public string Name { get; set; }


        [StringLength(100)]
        [DataType(DataType.Text)]
        [DisplayName("Name")]
        public string ContactName { get; set; }


        [StringLength(200)]
        [DataType(DataType.Text)]
        [DisplayName("Designation")]
        public string Designation { get; set; }


        [Required]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid Email ID")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email ID")]
        public string Email { get; set; }

       

        [Required]
        [Range(1, 10000)]
        [DisplayName("IncCountry Name")]
        public int CountryID { get; set; }


        [StringLength(30)]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }

      

        public int ?IndustryID { get; set; }

        [Required]
        [DisplayName("Turn Over Amt")]
        public decimal TurnOverAmt { get; set; }


        [Required]
        [StringLength(200)]
        [DataType(DataType.Text)]
        [DisplayName("Product")]
        public string Product { get; set; }
        [Required]
        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        [DisplayName("Commercial Terms")]
        public string CommTerms { get; set; }
        [Required]
        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        [DisplayName("Commercial Terms")]
        public string OtherCommTerms { get; set; }
        public string[] CommTerms_m { get; set; }
        [StringLength(200)]
        [DataType(DataType.Text)]
        [DisplayName("Industry")]
        public string InsuranceName { get; set; }
        public int CustomerBuyDetID { get; set; }
        public string CountryName { get; set; }
        public string IndustryName { get; set; }
        public string CurrencyCode { get; set; }
        public bool IsCreditIns { get; set; }
        public string OtherDesignation { get; set; }
        public string OtherIndustryName { get; set; }
        public int customertypeid { get; set; }
        public int tempcustomerid { get; set; }
    }
}