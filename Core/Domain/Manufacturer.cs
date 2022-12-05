using Volo.Abp.Domain.Entities.Auditing;

namespace VinApi31.Core.Domain
{
    /// <summary>
    /// Automotive World Manufacturer
    /// </summary>
    public class Manufacturer : AuditedAggregateRoot<string>
    {
        /// <summary>
        /// Gets or sets the world manufacturer code (identifier)
        /// </summary>
        public string Wmi { get; set; }

        /// <summary>
        /// Gets or sets the world zone
        /// </summary>
        public string Zone { get; set; }

        /// <summary>
        /// Gets or sets the Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer name
        /// </summary>
        public string Name { get; set; }    
    }
}
