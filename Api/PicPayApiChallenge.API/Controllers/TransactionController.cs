﻿using Microsoft.AspNetCore.Mvc;
using PicPayApiChallenge.Domain.Contracts.Services;
using PicPayApiChallenge.Domain.DTO;

namespace PicPayApiChallenge.API.Controllers
{
    [ApiController]
    [Route("transactions")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> SendPix(TransactionDTO dto)
        {
            try
            {
                await this._service.SendPix(dto);

                return CreatedAtAction(nameof(SendPix), new { id = 0 });

            } catch (Exception ex) 
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
