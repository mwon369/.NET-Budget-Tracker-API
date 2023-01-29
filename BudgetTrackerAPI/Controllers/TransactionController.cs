using BudgetTrackerAPI.Models;
using BudgetTrackerAPI.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private static List<Transaction> _transactionDummyData = new List<Transaction>
        {
            new Transaction
            {
                Id = 1,
                Value = 32.80m,
                Date = DateTime.Now,
                TransactionType = TransactionType.OUTGOING,
                Details = "Dinner"
            },
            new Transaction
            {
                Id = 2,
                Value = 3456.78m,
                Date = new DateTime(2023, 1, 13, 11, 45, 23),
                TransactionType = TransactionType.INCOMING,
                Details = "Got bread"
            },
            new Transaction
            {
                Id = 3,
                Value = 15.50m,
                Date = new DateTime(2023, 1, 18, 13, 32, 48),
                TransactionType = TransactionType.OUTGOING,
                Details = "Lunch"
            },
        };

        [HttpGet]
        public async Task<ActionResult<List<Transaction>>> GetAllTransactions()
        {
            return Ok(_transactionDummyData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Transaction>>> GetSingleTransactionById(int id)
        {
            var transaction = _transactionDummyData.Find(t => t.Id == id);
            return Ok(transaction);
        }
    }
}
