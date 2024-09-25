using System;
using Domiane.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class AssetDbContext : DbContext
    {
        public AssetDbContext(DbContextOptions<AssetDbContext> options)
            : base(options)
        {
        }
        public DbSet<Asset> Assets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>()
                .HasKey(a => a.AssetId);
        }

        public override int SaveChanges()
        {
            GenerateAssetIds();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            GenerateAssetIds();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void GenerateAssetIds()
        {
            var newAssets = ChangeTracker.Entries<Asset>()
                .Where(e => e.State == EntityState.Added && string.IsNullOrEmpty(e.Entity.AssetId))
                .ToList();

            foreach (var entry in newAssets)
            {
                if (!string.IsNullOrEmpty(entry.Entity.AssetId) && entry.Entity.AssetId.Contains("ASSET"))
                    continue;
                entry.Entity.AssetId = GenerateAssetId();
            }
        }

        private string GenerateAssetId()
        {
            var lastAsset = Assets
                .OrderByDescending(a => a.AssetId)
                .FirstOrDefault();

            if (lastAsset == null)
            {
                return "ASSET001";
            }

            var lastIdNumber = int.Parse(lastAsset.AssetId.Substring(5));
            var newIdNumber = lastIdNumber + 1;
            return $"ASSET{newIdNumber:D3}";
        }
    }


}