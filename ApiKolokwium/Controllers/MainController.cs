using ApiKolokwium.Models.DTOs;
using ApiKolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiKolokwium.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IDbService _dbService;

    public ClientsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{idClient}/subscriptions")]
    public async Task<ActionResult<ClientSubscriptionsResponse>> GetClientSubscriptions(int idClient)
    {
        try
        {
            var result = await _dbService.GetClientSubscriptions(idClient);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}