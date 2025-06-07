namespace ApiKolokwium.Models.DTOs;



public class AddPaymentDto
{
    public int IdClient { get; set; }
    public int IdSubscription { get; set; }
    public double Payment { get; set; }
}

public class PaymentResponseDto
{
    public int IdPayment { get; set; }
}
