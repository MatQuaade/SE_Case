using System;
using Domiane.Models;

namespace API.DTOs.Responses
{
    public class AssetResponse
    {
        public AssetResponse(AssetModel assetModel)
        {
            AssetId = assetModel.AssetId;
            Name = assetModel.Name;
            Description = assetModel.Description;
            Path = assetModel.Path;
        }

        public string AssetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
    }
}

