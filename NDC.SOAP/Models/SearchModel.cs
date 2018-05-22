
namespace NDC.SOAP.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    /// <summary>
    /// Use a data contract as illustrated in the sample below to add composite types to service operations.
    /// </summary>
    [DataContract]
    public class SearchModel
    {
        [DataMember]
        [Required]
        [EmailAddress]
        public string DestinationEmail { get; set; }

        [DataMember]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Names { get; set; }

        [DataMember]
        [Required]
        [Range(5, 100)]
        public int MinAge { get; set; }

        [DataMember]
        [Required]
        [Range(5, 100)]
        public int MaxAge { get; set; }

        [DataMember]
        [Required]
        [StringLength(15)]
        public string Sex { get; set; }

        [DataMember]
        [Range(50, 250)]
        public int MinHeigth { get; set; }

        [DataMember]
        [Range(50, 250)]
        public int MaxHeigth { get; set; }

        [DataMember]
        [Range(50, 150)]
        public double MinWeight { get; set; }

        [DataMember]
        [Range(50, 150)]
        public double MaxWeight { get; set; }

        [DataMember]
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Nationality { get; set; }

    }
}