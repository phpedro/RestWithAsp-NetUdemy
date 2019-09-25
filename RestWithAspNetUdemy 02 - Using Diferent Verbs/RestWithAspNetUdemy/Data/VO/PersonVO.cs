using RestWithAspNetUdemy.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Tapioca.HATEOAS;

namespace RestWithAspNetUdemy.Data.VO
{
    [DataContract]
    public class PersonVO : ISupportsHyperMedia
    {
        [DataMember(Order = 1)]
        public long? id { get; set; }
        [DataMember(Order = 2)]
        public string FirstName { get; set; }
        [DataMember(Order = 3)]
        public string LastName { get; set; }
        [DataMember(Order = 4)]
        public string Address { get; set; }
        [DataMember(Order = 5)]
        public string Gender { get; set; }
        [DataMember(Order = 6)]
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>(); 
    }
}
