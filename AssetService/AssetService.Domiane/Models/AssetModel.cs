using System;
using System.ComponentModel.DataAnnotations;
using Domiane.Entities;
using Domiane.Enums;

namespace Domiane.Models
{
    public class AssetModel
    {
        public AssetModel(Asset assetEntity)
        {
            AssetId = assetEntity.AssetId;
            Name = assetEntity.Name;
            Description = assetEntity.Description;
            FileFormat = assetEntity.FileFormat;
            FileSize = assetEntity.FileSize;
            Path = assetEntity.Path;
            CreatedBy = assetEntity.CreatedBy;
            UserName = assetEntity.UserName;
            Comments = assetEntity.Comments;
            Preview = assetEntity.Preview;
        }
        public AssetModel()
        {

        }

        public string AssetId { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; } 
        public FileFormat? FileFormat { get; set; }
        public int? FileSize { get; set; }
        public string Path { get; set; } 
        public string CreatedBy { get; set; } 
        public string UserName { get; set; }
        public string Comments { get; set; }
        public string Preview { get; set;  }
    }
}
