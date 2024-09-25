using System;
using Domiane.Entities;
using Domiane.Enums;
using Domiane.Models;
using Domiane.Repositories;
using Infrastructure.Contexts;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly AssetDbContext _context;
        private readonly ILogger<AssetRepository> _logger;

        public AssetRepository(AssetDbContext context, ILogger<AssetRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Asset> CreateAsset(AssetModel assetModel)
        {
            var asset = new Asset();
            asset.Name = assetModel.Name;
            asset.Description = assetModel.Description;
            asset.FileFormat = assetModel.FileFormat;
            asset.FileSize = assetModel.FileSize;
            asset.Path = assetModel.Path;
            asset.CreatedBy = assetModel.CreatedBy;
            asset.UserName = assetModel.UserName;
            asset.Comments = assetModel.Comments;
            asset.Preview = assetModel.Preview;
            asset.TimeStamp = DateTime.Now;

            await _context.Assets.AddAsync(asset);
            await _context.SaveChangesAsync();

            return asset;
        }

        public async Task<IList<Asset>> CreateAssetFromList(List<AssetModel> createList)
        {
            var assetList = new List<Asset>();
            foreach(var assetModel in createList)
            {
                var asset = new Asset();
                asset.AssetId = assetModel.AssetId;
                asset.Name = assetModel.Name;
                asset.Description = assetModel.Description;
                asset.FileFormat = assetModel.FileFormat;
                asset.FileSize = assetModel.FileSize;
                asset.Path = assetModel.Path;
                asset.CreatedBy = assetModel.CreatedBy;
                asset.UserName = assetModel.UserName;
                asset.Comments = assetModel.Comments;
                asset.Preview = assetModel.Preview;
                asset.TimeStamp = DateTime.Now;

                assetList.Add(asset);
            }

            await _context.AddRangeAsync(assetList);
            await _context.SaveChangesAsync();
            return assetList;
        }

        public async Task<Asset> FindAsset(string assetId)
        {
            var asset = await _context.Assets.FindAsync(assetId);
            if (asset is null)
            {
                var errorMessage = $"There was no Asset entry for id: {assetId}";
                _logger.LogError(errorMessage);
                throw new NullReferenceException(errorMessage);
            }
            return asset;
        }

        public async Task SetSatus(Status status, string assetId)
        {
            var asset = await _context.Assets.FindAsync(assetId);
            if (asset is null)
            {
                var errorMessage = $"There was no Asset entry for id: {assetId}";
                _logger.LogError(errorMessage);
                throw new NullReferenceException(errorMessage);
            }

            asset.Status = status;

            _context.Update(asset);
            await _context.SaveChangesAsync();
        }

        public async Task<Asset> UpdateAsset(AssetModel assetModel)
        {
            var asset = await _context.Assets.FindAsync(assetModel.AssetId);
            if(asset is null)
            {
                var errorMessage = $"There was no Asset entry for id: {assetModel.AssetId}";
                _logger.LogError(errorMessage);
                throw new NullReferenceException(errorMessage);
            }

            asset.Name = assetModel.Name;
            asset.Description = assetModel.Description;
            asset.FileFormat = assetModel.FileFormat;
            asset.FileSize = assetModel.FileSize;
            asset.Path = assetModel.Path;
            asset.CreatedBy = assetModel.CreatedBy;
            asset.UserName = assetModel.UserName;
            asset.Comments = assetModel.Comments;
            asset.Preview = assetModel.Preview;

            _context.Update(asset);
            await _context.SaveChangesAsync();

            return asset;
        }

    }


}
