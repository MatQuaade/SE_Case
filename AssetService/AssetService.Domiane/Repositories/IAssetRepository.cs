using System;
using Domiane.Entities;
using Domiane.Enums;
using Domiane.Models;

namespace Domiane.Repositories
{
    public interface IAssetRepository
    {
        public Task<Asset> FindAsset(string assetId);
        public Task<Asset> CreateAsset(AssetModel assetModel);
        public Task<Asset> UpdateAsset(AssetModel assetModel);
        public Task SetSatus(Status status, string assetId);
        public Task<IList<Asset>> CreateAssetFromList(List<AssetModel> createList);
    }
}

