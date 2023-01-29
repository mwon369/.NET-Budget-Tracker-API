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
                Description = "Dinner"
            },
            new Transaction
            {
                Id = 2,
                Value = 3456.78m,
                Date = new DateTime(2023, 1, 13, 11, 45, 23),
                TransactionType = TransactionType.INCOMING,
                Description = "Got bread"
            },
            new Transaction
            {
                Id = 3,
                Value = 15.50m,
                Date = new DateTime(2023, 1, 18, 13, 32, 48),
                TransactionType = TransactionType.OUTGOING,
                Description = "Lunch"
            },
        };

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Transaction>>> GetAllTransactions()
        {
            return Ok(_transactionDummyData);
        }

        [HttpGet("GetAll/FilterByAmount")]
        public async Task<ActionResult<List<Transaction>>> GetAllTransactionsFilteredByAmount(decimal minValue=decimal.MinValue, decimal maxValue=decimal.MaxValue)
        {
            var transactionsBetweenValues = _transactionDummyData.FindAll(t => t.Value >= minValue && t.Value <= maxValue);
            return Ok(transactionsBetweenValues);
        }

        [HttpGet("GetAll/FilterByDate")]
        public async Task<ActionResult<List<Transaction>>> GetAllTransactionsFilteredByDate(string startDate="", string endDate="")
        {
            if (startDate == "" && endDate == "") return BadRequest("Please specify at least either a start date or end date");

            if (startDate == "")
            {
                var transactionsBeforeEndDate = _transactionDummyData.FindAll(t => t.Date <= DateTime.Parse(endDate));
                return Ok(transactionsBeforeEndDate);
            }

            if (endDate == "")
            {
                var transactionsAfterStartDate = _transactionDummyData.FindAll(t => t.Date >= DateTime.Parse(startDate));
                return Ok(transactionsAfterStartDate);
            }

            var transactionsBetweenDates = _transactionDummyData.FindAll(t => t.Date >= DateTime.Parse(startDate) && t.Date <= DateTime.Parse(endDate));
            return Ok(transactionsBetweenDates);
        }

        [HttpGet("GetAll/FilterIncoming")]
        public async Task<ActionResult<List<Transaction>>> GetAllTransactionsThatAreIncoming()
        {
            var incomingTransactions = _transactionDummyData.FindAll(t => t.TransactionType == TransactionType.INCOMING);
            return Ok(incomingTransactions);
        }

        [HttpGet("GetAll/FilterOutgoing")]
        public async Task<ActionResult<List<Transaction>>> GetAllTransactionsThatAreOutgoing()
        {
            var outgoingTransactions = _transactionDummyData.FindAll(t => t.TransactionType == TransactionType.OUTGOING);
            return Ok(outgoingTransactions);
        }

        [HttpGet("GetAll/FilterByDescription/{description}")]
        public async Task<ActionResult<List<Transaction>>> GetAllTransactionsWhichContainSpecifiedDescription(string description)
        {
            var transactionsWithDescription = _transactionDummyData.Where(t => t.Description.ToLower().Contains(description.ToLower()));
            return Ok(transactionsWithDescription);
        }

        [HttpGet("FilterById/{id}")]
        public async Task<ActionResult<Transaction>> GetSingleTransactionById(int id)
        {
            var transaction = _transactionDummyData.Find(t => t.Id == id);
            return Ok(transaction);
        }
    }
}
