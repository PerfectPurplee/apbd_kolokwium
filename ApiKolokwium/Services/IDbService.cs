using ApiKolokwium.Models.DTOs;


namespace ApiKolokwium.Services;

public interface IDbService
{
    Task<ClientSubscriptionsResponse> GetClientSubscriptions(int clientId);
    Task<PaymentResponseDto> AddPayment(AddPaymentDto dto);
}