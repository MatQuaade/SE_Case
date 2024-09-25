using System.Xml.Linq;
using API.DTOs.Requests;
using API.DTOs.Responses;
using API.Services.Contracts;
using Domiane.Enums;
using Domiane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AssetController : ControllerBase
{

    private readonly ILogger<AssetController> _logger;
    private readonly IAssetService _assetServie;

    public AssetController(ILogger<AssetController> logger, IAssetService assetService)
    {
        _logger = logger;
        _assetServie = assetService;
    }

    [HttpGet(Name = "GetAsset")]
    public async Task<AssetResponse> Get([FromQuery] string assetId)
    {
        var assetModel = await _assetServie.FindAsset(assetId);
        return new AssetResponse(assetModel);
    }

    [HttpPost(Name = "CreateAsset")]
    public async Task<AssetResponse> Create([FromBody] CreateAssetRequest request)
    {
        var assetModel = new AssetModel
        {
            Name = request.Name,
            Description = request.Description,
            FileFormat = request.FileFormat,
            FileSize = request.FileSize,
            Path = request.Path,
            CreatedBy = request.CreatedBy,
            UserName = request.UserName,
            Comments = request.Comments,
            Preview = request.Preview
        };

        var assetModelNew = await _assetServie.CreateAsset(assetModel);
        return new AssetResponse(assetModelNew);
    }
    [HttpPost(Name = "CreateAssetFromList")]
    public async Task<IList<AssetResponse>> CreateFromList([FromBody] CreateManyAssetRequest request)
    {
        var createList = new List<AssetModel>();
        foreach(var model in request.ListOfAssetsToCreate)
        {
            var assetModel = new AssetModel
            {
                AssetId = model.AssetId,
                Name = model.Name,
                Description = model.Description,
                FileFormat = model.FileFormat,
                FileSize = model.FileSize,
                Path = model.Path,
                CreatedBy = model.CreatedBy,
                UserName = model.UserName,
                Comments = model.Comments,
                Preview = model.Preview
            };

            createList.Add(assetModel);
            
        }
        var newAssets = await _assetServie.CreateFromList(createList);
        var assetResponseList = new List<AssetResponse>();

        foreach (var model in newAssets)
        {
            assetResponseList.Add(new AssetResponse(model));
        }
        return assetResponseList;
    }

    [HttpPut(Name = "UpdateAsset")]
    public async Task<AssetResponse> Update([FromBody] UpdateAssetRequest request)
    {
        var assetModel = new AssetModel
        {
            AssetId = request.AssetId,
            Name = request.Name,
            Description = request.Description,
            FileFormat = request.FileFormat,
            FileSize = request.FileSize,
            Path = request.Path,
            CreatedBy = request.CreatedBy,
            UserName = request.UserName,
            Comments = request.Comments,
            Preview = request.Preview
        };

        var assetModelNew = await _assetServie.UpdateAsset(assetModel);
        return new AssetResponse(assetModelNew);
    }
    [HttpPut(Name = "SetStatus")]
    public async Task SetStatus([FromQuery] Status status, [FromQuery]string assetId)
    {
        await _assetServie.SetSatusOnAsset(status, assetId);
    }
}

