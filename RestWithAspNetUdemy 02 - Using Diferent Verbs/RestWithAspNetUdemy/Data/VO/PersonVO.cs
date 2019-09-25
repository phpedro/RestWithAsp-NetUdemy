using RestWithAspNetUdemy.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Tapioca.HATEOAS;

namespace RestWithAspNetUdemy.Data.VO
{
    public class PersonVO : ISupportsHyperMedia
    {
        public long? id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>(); 
    }
}
