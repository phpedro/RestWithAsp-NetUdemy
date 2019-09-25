using RestWithAspNetUdemy.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RestWithAspNetUdemy.Models
{
    [DataContract]
    public class BookVO
    {
        [DataMember(Order = 1)]
        public long? id { get; set; }
        [DataMember(Order = 2)]
        public string Title { get; set; }
        [DataMember(Order = 3)]
        public string Author { get; set; }
        [DataMember(Order = 4)]
        public decimal Price { get; set; }
        [DataMember(Order = 5)]
        public DateTime LaunchDate { get; set; }
    }
}
