using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayDomain.Entities
{
    public class Purpose
    {
        public Purpose()
        {
            providerpurpose = new HashSet<ProviderPurpose>();
        }
        public int PurposeId { get; set; }
        public string PurposeName { get; set; } = string.Empty;
        public string PurposeDescription { get; set; } = string.Empty;
        
        public ICollection<ProviderPurpose>? providerpurpose { get; set; }
    }
}
