using System;
using System.ComponentModel.DataAnnotations;
using Domiane.Enums;

namespace Domiane.Entities
{
    public class Asset
    {
        [Key]
        public string AssetId { get; set; } = String.Empty;
        public string Name { get; set; } 
        public string Description { get; set; } 
        public FileFormat? FileFormat { get; set; }
        public int? FileSize { get; set; }
        public string Path { get; set; } 
        public string CreatedBy { get; set; } 
        public string Version { get; set; } = "0.1";
        public DateTime TimeStamp { get; set; }
        public string UserName { get; set; }
        public string Comments { get; set; }
        public string Preview { get; set;  }
        public Status Status { get; set; } = Status.Created;

    }
}
