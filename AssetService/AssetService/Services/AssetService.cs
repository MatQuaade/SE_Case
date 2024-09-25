using System;
using API.Services.Contracts;
using Domiane.Entities;
using Domiane.Enums;
using Domiane.Models;
using Domiane.Repositories;

namespace API.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _respository;
        public AssetService(IAssetRepository repository)
        {
            _respository = repository;
        }

        public async Task<AssetModel> CreateAsset(AssetModel asset)
        {
            var assetEntity = await _respository.CreateAsset(asset);
            return new AssetModel(assetEntity);
        }

        public async Task<IList<AssetModel>> CreateFromList(List<AssetModel> createList)
        {
            var assetEntities = await _respository.CreateAssetFromList(createList);
            var assetmodelList = new List<AssetModel>();

            foreach(var entity in assetEntities)
            {
                assetmodelList.Add(new AssetModel(entity));
            }
            return assetmodelList;
        }

        public async Task<AssetModel> FindAsset(string assetId)
        {
            var assetEntity = await _respository.FindAsset(assetId);
            return new AssetModel(assetEntity);
        }

        public async Task SetSatusOnAsset(Status status, string assetId)
        {
            await _respository.SetSatus(status, assetId);
        }

        public async Task<AssetModel> UpdateAsset(AssetModel asset)
        {
            var assetEntity = await _respository.UpdateAsset(asset);
            return new AssetModel(assetEntity);
        }
    }
}

