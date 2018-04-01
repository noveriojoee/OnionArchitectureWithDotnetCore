using System;
namespace ResvCo.Models
{
    public class Band : BaseEntity
    {
        public int Id { get; set; }  
        public string Name { get; set; }  
        public string Genre { get; set; }  
    }
}
