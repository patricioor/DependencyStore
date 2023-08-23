using Dapper;
using DependencyStore.Models;
using DependencyStore.Repositories.Contracts;
using DependencyStore.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DependencyStore.Controllers;

public class OrderController : ControllerBase
{
    readonly ICustomerRepository _customerRepository;
    readonly IDeliveryFeeService _feeService;
    readonly IPromoCodeRepository _promoCodeRepository;

    public OrderController(ICustomerRepository customerRepository, IDeliveryFeeService feeService, IPromoCodeRepository promoCodeRepositoy)
    {
        _customerRepository = customerRepository;
        _feeService = feeService;
        _promoCodeRepository = promoCodeRepositoy;
    }
    [Route("v1/orders")]
    [HttpPost]
    public async Task<IActionResult> Place(string customerId, string zipCode, string promoCode, int[] products)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId);
        if (customer == null)
            return NotFound();

        var deliveryFee = await _feeService.GetDeliveryFeeAsync(zipCode);
        var cupon = await _promoCodeRepository.GetPromoCodeAsync(promoCode); ;
        var discount = cupon?.Value ?? 0m;
        var order = new Order(deliveryFee, discount, new List<Product>());
        return Ok($"Pedido {order.Code} gerado com sucesso!");
    }
}