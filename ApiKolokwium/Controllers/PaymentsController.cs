using ApiKolokwium.Models.DTOs;
using ApiKolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiKolokwium.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IDbService _dbService;

    public PaymentsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> AddPayment([FromBody] AddPaymentDto dto)
    {
        try
        {
            var result = await _dbService.AddPayment(dto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
