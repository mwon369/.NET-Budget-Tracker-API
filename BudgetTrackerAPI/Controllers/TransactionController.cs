using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Transaction>>> GetAllTransactions()
        {
            var result = _transactionService.GetAllTransactions();
            return Ok(result);
        }

        [HttpGet("GetAll/FilterByAmount")]
        public async Task<ActionResult<List<Transaction>>> GetAllTransactionsFilteredByAmount(decimal minValue=decimal.MinValue, decimal maxValue=decimal.MaxValue)
        {
            var result = _transactionService.GetAllTransactionsFilteredByAmount(minValue, maxValue);
            return Ok(result);
        }

        [HttpGet("GetAll/FilterByDate")]
        public async Task<ActionResult<List<Transaction>>> GetAllTransactionsFilteredByDate(string startDate="", string endDate="")
        {
            var result = _transactionService.GetAllTransactionsFilteredByDate(startDate, endDate);
            if (result == null) return BadRequest("Please specify at least either a start date or end date");
            return Ok(result);
        }

        [HttpGet("GetAll/FilterIncoming")]
        public async Task<ActionResult<List<Transaction>>> GetAllTransactionsThatAreIncoming()
        {
            var result = _transactionService.GetAllTransactionsThatAreIncoming();
            return Ok(result);
        }

        [HttpGet("GetAll/FilterOutgoing")]
        public async Task<ActionResult<List<Transaction>>> GetAllTransactionsThatAreOutgoing()
        {
            var result = _transactionService.GetAllTransactionsThatAreOutgoing();
            return Ok(result);
        }

        [HttpGet("GetAll/FilterByDescription/{description}")]
        public async Task<ActionResult<List<Transaction>>> GetAllTransactionsContainingDescription(string description)
        {
            var result = _transactionService.GetAllTransactionsContainingDescription(description);
            return Ok(result);
        }

        [HttpGet("FilterById/{id}")]
        public async Task<ActionResult<Transaction>> GetSingleTransactionById(int id)
        {
            var result = _transactionService.GetSingleTransactionById(id);
            return Ok(result);
        }

        [HttpPost("AddTransaction")]
        public async Task<ActionResult<List<Transaction>>> AddTransaction([FromBody]Transaction transactionToAdd)
        {
            var result = _transactionService.AddTransaction(transactionToAdd);
            return Ok(result);
        }

        [HttpPut("EditTransaction")]
        public async Task<ActionResult<List<Transaction>>> EditTransaction([FromBody]Transaction newTransaction)
        {
            var result = _transactionService.EditTransaction(newTransaction);
            return Ok(result);
        }

        [HttpDelete("DeleteTransaction/{id}")]
        public async Task<ActionResult<List<Transaction>>> DeleteTransaction(int id)
        {
            var result = _transactionService.DeleteTransaction(id);
            return Ok(result);
        }
    }
}
