using System;
using Domiane.Enums;
using Domiane.Models;

namespace API.Services.Contracts
{
    public interface IAssetService
    {
        public Task<AssetModel> CreateAsset(AssetModel asset);
        public Task<AssetModel> FindAsset(string assetId);
        public Task<AssetModel> UpdateAsset(AssetModel asset);
        public Task SetSatusOnAsset(Status status, string assetId);
        public Task<IList<AssetModel>> CreateFromList(List<AssetModel> createList);
    }
}

