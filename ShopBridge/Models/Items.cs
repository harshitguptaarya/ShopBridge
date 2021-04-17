#region Namespace
using System;
using System.ComponentModel.DataAnnotations;
#endregion

namespace ShopBridge.Models
{
    public class Items
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Descriprion { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
