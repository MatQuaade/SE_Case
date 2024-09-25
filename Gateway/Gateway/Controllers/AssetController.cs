using System.Net.Http;
using Gateway.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AssetController : ControllerBase
{
    private readonly ILogger<AssetController> _logger;
    private readonly HttpClient _assetHttpClient;

    public AssetController(ILogger<AssetController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _assetHttpClient = httpClientFactory.CreateClient("AssetClient");
    }

    [HttpGet(Name = "GetAsset")]
    public async Task<IActionResult> GetAsset(string assetId)
    {
        var response = await _assetHttpClient.GetAsync($"/Asset/Get?assetId={assetId}");
        var content = await response.Content.ReadAsStringAsync();
        return Content(content, response.Content.Headers.ContentType.ToString());

    }


}

