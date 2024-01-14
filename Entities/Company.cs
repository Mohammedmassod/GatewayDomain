using GatewayDomain.Common;
using GatewayDomain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace Gateway_Domain.Entities
{
    public class Company:AuditableEntity,IBaseValidation
    {
      

        [Key]
        public int CompanyId { get; set; }//1
        public string CompanyEnglishName { get; set; } = "";
        public string CompanyArabicName { get; set; } = "";
        public string CompanyDescription { get; set; } = string.Empty;
        public string CompanyCode { get; set; } = string.Empty;
        public string CompanyPhone { get; set; } = string.Empty;
        public string CompanyEmail { get; set; } = string.Empty;
        public string? CompanyAddress { get; set; }
        public bool Status { get; set; }
        public IFormFile? Companylogo { get; set; }
        public string LogoUrl { get; set; } = string.Empty;

        
        public ICollection<ProviderCompany>? providercompanies { get; set; }

        public ICollection<ProviderCurrency>? providercurrencies { get; set; }

       
        public ICollection<ServiceProvider>? servicesprovider { get; set; }

      
        public ICollection<ProviderPurpose>? providerpurpose { get; set; }

        public ICollection<ProviderCountry>? providercountrie { get; set; }

    
        public ICollection<ProviderProvince>? providerprovince { get; set; }

   
        public ICollection<ProviderRegion>? providerregion { get; set; }

        public ICollection<Product>? products { get; set; }


        //Validations

        string emailPattern = @"^\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";

        string phoneNumberPattern = @"^(77|78|73|71)\d{9}$";


        public async Task<string> isValid()
        {
            if(string.IsNullOrEmpty(CompanyArabicName))
            {
                return await Task.FromResult<string>("CompanyArabicName field is Required");
            }

            if (string.IsNullOrWhiteSpace(CompanyArabicName))
            {
                return await Task.FromResult<string>("Please Enter a correct CompanyArabicName to be considered");
            }
   
            if (string.IsNullOrWhiteSpace(CompanyEnglishName))
            {
                return await Task.FromResult<string>("Please Enter a correct CompanyEnglishName to be considered");
            }

            if (string.IsNullOrWhiteSpace(CompanyEmail))
            {
                return await Task.FromResult<string>("Please Enter a correct CompanyEmail to be considered");
            }

            if (!Regex.IsMatch(CompanyEmail, emailPattern))
            {
                return await Task.FromResult<string>("Please Enter a correct CompanyEmail to be considered");
            }

            if (string.IsNullOrWhiteSpace(CompanyPhone))
            {
                return await Task.FromResult<string>("Please Enter a correct CompanyPhone to be considered");
            }

            if (!Regex.IsMatch(CompanyPhone, phoneNumberPattern))
            {
                return await Task.FromResult<string>("Please Enter a correct CompanyPhone to be considered");
            }
                

            return await Task.FromResult<string>("");
        }
    }

}
